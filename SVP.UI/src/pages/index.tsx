import React, {useContext} from 'react';
import {BrowserRouter as Router, Route} from "react-router-dom";
import {AppContext} from "../contexts/AppContext";
import PatientPage from "./patient/PatientPage";
import DoctorPage from "./doctor/DoctorPage";

const PageRouter = () => {

    const {baseUrl} = useContext(AppContext);
    return (
        <Router>

            <Route path={baseUrl + "patient"}>
                <PatientPage/>
            </Route>

            <Route path={baseUrl + "doctor"}>
                <DoctorPage/>
            </Route>

        </Router>
    );
};

export default PageRouter;
