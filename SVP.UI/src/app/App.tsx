import React, {useState} from 'react';
import './App.css';
import {AppContext} from "../contexts/AppContext";
import {ServiceContext} from "../contexts/ServiceContext";
import PageRouter from "../pages";
import {PatientService} from "../services/patient.service";
import {IllnessService} from "../services/illness.service";
import {DoctorService} from "../services/doctor.service";
import AuthPage from "../pages/auth/AuthPage";

const App = () => {

    const baseUrl = "/", apiUrl = "/";
    const [userAuthorizedId, setUserAuthorizedId] = useState(0);

    if (!userAuthorizedId) {
        return <AuthPage setAuthorizedId={setUserAuthorizedId}/>
    }

    return <AppContext.Provider value={{
        apiUrl: apiUrl,
        baseUrl: baseUrl,
        userId: 0
    }}>
        <ServiceContext.Provider value={{
            patientApi: new PatientService(apiUrl),
            doctorApi: new DoctorService(apiUrl),
            illnessApi: new IllnessService(apiUrl),
        }}>
            <PageRouter />
        </ServiceContext.Provider>
    </AppContext.Provider>
};

export default App;
