import React from 'react';
import './App.css';
import {AppContext} from "../contexts/AppContext";
import {ServiceContext} from "../contexts/ServiceContext";
import PageRouter from "../pages";
import {PatientService} from "../services/patient.service";
import {IllnessService} from "../services/illness.service";
import {DoctorService} from "../services/doctor.service";
import {AuthService} from "../services/auth.service";
import {loadMessages, locale as localeDevexpress} from "devextreme/localization";
import ruMessages from "devextreme/localization/messages/ru.json";
import 'devextreme/dist/css/dx.light.css';

const App = () => {

    const baseUrl = "/", apiUrl = "/api/SVP/";

    loadMessages(ruMessages);
    localeDevexpress("ru-RU");

    // useEffect(() => {
    //     type localStorageObj = { value: boolean, timestamp: Date };
    //     const obj: localStorageObj = JSON.parse(window.localStorage.getItem("isAuthUser") || "");
    //     const currentDate = new Date();
    //     if (!obj.value || obj.timestamp < currentDate) {
    //         const obj: localStorageObj = {
    //             value: false,
    //             timestamp: new Date()
    //         }
    //         window.localStorage.setItem("isAuthUser", JSON.stringify(obj));
    //     }
    // }, [])

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
