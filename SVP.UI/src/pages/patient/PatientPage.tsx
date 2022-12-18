import React from 'react';
import useAuthRedirect from "../../hooks/useAuthRedirect";

const PatientPage = () => {

    useAuthRedirect();

    return (
        <div>
            Patient page
        </div>
    );
};

export default PatientPage;
