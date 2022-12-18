import React, {useState} from 'react';
import {Button} from "antd";
import AuthForm from "./authForm";
import {MedicineBoxOutlined, UserOutlined} from "@ant-design/icons";
import {AuthModel} from "../../models/auth.model";
import {useHistory} from "react-router-dom";

const AuthPage = (props: AuthModel.PageProps) => {


    const [choseAuthRole, setChoseAuthRole] = useState(false);
    const [isPatient, setIsPatient] = useState(true);
    const history = useHistory();

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

    const setAuthId = (id: number) => {
        let currentDate = new Date();
        currentDate.setHours(currentDate.getHours() + 3);
        const obj = {
            value: true,
            timestamp: currentDate
        }
        window.localStorage.setItem("isAuthUser", JSON.stringify(obj))
        if (isPatient) {
            history.push(`patient/${id}`);
        } else {
            history.push(`doctor/${id}`);
        }
    }

    return (
        <AuthForm setUserAuthorizedId={setAuthId} isPatient={isPatient}/>
    );
};

export default AuthPage;
