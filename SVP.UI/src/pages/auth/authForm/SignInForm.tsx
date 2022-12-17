import React from 'react';
import {AuthModel} from "../../../models/auth.model";
import {Button, Form, Input} from "antd";

const SignInForm: React.FC<AuthModel.SignInFormProps> = (props) => {

    const onFinish = (data: any) => {
        console.log(data)
        props.onFinishForm(data.login, data.password);
    }

    return (
        <Form onFinish={onFinish}>
            <Form.Item label={"Логин"} name={"login"} required>
                <Input placeholder="Введите логин"/>
            </Form.Item>

            <Form.Item label={"Пароль"} name={"password"} required>
                <Input type="password" placeholder="Введите пароль"/>
            </Form.Item>

            <Form.Item>
                <Button type="primary" htmlType={"submit"}>
                    Войти
                </Button>
            </Form.Item>
        </Form>
    );
};

export default SignInForm;
