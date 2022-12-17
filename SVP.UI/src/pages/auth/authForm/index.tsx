import React, {useMemo} from 'react';
import {AuthModel} from "../../../models/auth.model";
import {Tabs} from "antd";
import SignInForm from "./SignInForm";
import RegistrationForm from "./RegistrationForm";

const TAB_KEY_SIGN_IN = "signIn";
const TAB_KEY_REGISTRATION = "reg";

const AuthForm = (props: AuthModel.FormProps): React.ReactElement => {

    const onFinishSignInForm = (login: string, password: string) => {
        console.log(`onFinishSignInForm \n login: ${login}, password: ${password}`);
        // TODO: сделать запрос на бэк, вернуть пользователя, изменить url
        props.setAuthorizedId(0)
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
