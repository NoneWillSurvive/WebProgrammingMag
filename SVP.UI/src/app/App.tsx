import React, {useEffect} from 'react';
import './App.css';
import {AppContext} from "../contexts/AppContext";
import {ServiceContext} from "../contexts/ServiceContext";
import PageRouter from "../pages";
import {PatientService} from "../services/patient.service";
import {IllnessService} from "../services/illness.service";
import {DoctorService} from "../services/doctor.service";
import {AuthService} from "../services/auth.service";

const App = () => {

    const baseUrl = "/", apiUrl = "/";

    useEffect(() => {
        type localStorageObj = { value: boolean, timestamp: Date };
        const obj: localStorageObj = JSON.parse(window.localStorage.getItem("isAuthUser") || "");
        const currentDate = new Date();
        if (!obj.value || obj.timestamp < currentDate) {
            const obj: localStorageObj = {
                value: false,
                timestamp: new Date()
            }
            window.localStorage.setItem("isAuthUser", JSON.stringify(obj));
        }
    }, [])

    return <AppContext.Provider value={{
        apiUrl: apiUrl,
        baseUrl: baseUrl,
    }}>
        <ServiceContext.Provider value={{
            patientApi: new PatientService(apiUrl),
            doctorApi: new DoctorService(apiUrl),
            illnessApi: new IllnessService(apiUrl),
            authApi: new AuthService(apiUrl)
        }}>
            <PageRouter/>
        </ServiceContext.Provider>
    </AppContext.Provider>
};

export default App;
