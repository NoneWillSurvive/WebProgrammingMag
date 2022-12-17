import React from 'react';
import './App.css';
import {AppContext} from "../context/AppContext";
import {ServiceContext} from "../context/ServiceContext";
import PageRouter from "../pages";
import {PatientService} from "../service/patient.service";
import {IllnessService} from "../service/illness.service";
import {DoctorService} from "../service/doctor.service";

const App = () => {

    const baseUrl = "/", apiUrl = "/";

    return <AppContext.Provider value={{
        apiUrl: apiUrl,
        baseUrl: baseUrl
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
