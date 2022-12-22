import React, {useContext} from 'react';
import {BrowserRouter as Router, Route, Switch} from "react-router-dom";
import {AppContext} from "../contexts/AppContext";
import PatientPage from "./patient/PatientPage";
import DoctorPage from "./doctor/DoctorPage";
import IllnessPage from "./illness/IllnessPage";


const PageRouter = () => {

    const {baseUrl} = useContext(AppContext);

    return (
        <Router>
            <Switch>
                {/*<Route exact path={baseUrl + "auth"}>*/}
                {/*    <AuthPage/>*/}
                {/*</Route>*/}

                {/*<Route exact path={baseUrl}>*/}
                {/*    <AuthPage/>*/}
                {/*</Route>*/}

                <Route exact path={baseUrl + "patient/:id"}>
                    <PatientPage/>
                </Route>

                <Route exact path={baseUrl + "patient"}>
                    <PatientPage/>
                </Route>

                <Route exact path={baseUrl + "doctor/:id"}>
                    <DoctorPage/>
                </Route>
                <Route exact path={baseUrl + "doctor"}>
                    <DoctorPage/>
                </Route>

                <Route exact path={baseUrl + "illness/:id"}>
                    <IllnessPage/>
                </Route>
                <Route exact path={baseUrl + "illness"}>
                    <IllnessPage/>
                </Route>
            </Switch>
        </Router>
    );
};

export default PageRouter;
