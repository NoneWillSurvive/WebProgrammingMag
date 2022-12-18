import React, {useContext, useMemo} from 'react';
import {AuthModel} from "../../../models/auth.model";
import {message, Tabs} from "antd";
import SignInForm from "./SignInForm";
import RegistrationForm from "./RegistrationForm";
import {ServiceContext} from "../../../contexts/ServiceContext";

const TAB_KEY_SIGN_IN = "signIn";
const TAB_KEY_REGISTRATION = "reg";

const AuthForm = (props: AuthModel.FormProps): React.ReactElement => {

    const {authApi} = useContext(ServiceContext);
    const onFinishSignInForm = async (login: string, password: string) => {

        console.log(`onFinishSignInForm \n login: ${login}, password: ${password}`);

        try {
            const response = await authApi.CheckAuthUser(props.isPatient, login, password);
            props.setUserAuthorizedId(response)
        } catch (e) {
            message.error("Неверный логин или пароль.")
        }
    }

    const tabsItems = useMemo(() => [
        {
            label: `Войти`,
            key: TAB_KEY_SIGN_IN,
            children: <SignInForm onFinishForm={onFinishSignInForm}/>,
        },
        {
            label: `Зарегистрироваться`,
            key: TAB_KEY_REGISTRATION,
            children: <RegistrationForm/>,
        }
    ], []);

    return (
        <Tabs
            defaultActiveKey={TAB_KEY_SIGN_IN}
            items={tabsItems}
        />
    );
};

export default AuthForm;
