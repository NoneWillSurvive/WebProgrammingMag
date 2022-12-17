import React, {useState} from 'react';
import {Button} from "antd";
import AuthForm from "./authForm";
import {MedicineBoxOutlined, UserOutlined} from "@ant-design/icons";

interface AuthProps {
    setAuthorizedId: (id: number) => void
}

const AuthPage = (props: AuthProps) => {

    const [choseAuthRole, setChoseAuthRole] = useState(false);
    const [isPatient, setIsPatient] = useState(true);

    const chooseRolePatient = () => {
        setIsPatient(true)
        setChoseAuthRole(true)
    }
    const chooseRoleDoctor = () => {
        setIsPatient(false)
        setChoseAuthRole(true)
    }

    if (!choseAuthRole) {
        return <div>
            Вы пациент или врач?
            <Button icon={<UserOutlined/>} onClick={chooseRolePatient}>
                Пациент
            </Button>
            <Button icon={<MedicineBoxOutlined/>} onClick={chooseRoleDoctor}>
                Врач
            </Button>
        </div>
    }

    return (
        <AuthForm setAuthorizedId={props.setAuthorizedId} isPatient={isPatient}/>
    );
};

export default AuthPage;
