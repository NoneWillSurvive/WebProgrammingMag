import React, {useContext, useEffect, useState} from 'react';
import useAuthRedirect from "../../hooks/useAuthRedirect";
import {Button, Form, Input, message, Radio, Skeleton} from "antd";
import {PatientModel} from "../../models/patient.model";
import {useParams} from "react-router-dom";
import {ServiceContext} from "../../contexts/ServiceContext";
import {DeleteOutlined, EditOutlined, SaveOutlined, UndoOutlined} from "@ant-design/icons";
import s from "./style.module.css";

const PatientPage = () => {

    useAuthRedirect();
    const [form] = Form.useForm();
    const {patientApi} = useContext(ServiceContext);
    const [patient, setPatient] = useState<PatientModel.IPatient>({
        id: 0,
        gender: true,
        age: 0,
        name: "",
        illness: null,
        levelAnxiety: 0,
        levelDepression: 0,
        levelHopelessness: 0,
        levelAsthenicSyndrome: 0,
        hasAddiction: false,
        needHospitalization: false,
        recommendedDoctor: null
    });
    const [loading, setLoading] = useState(true);
    const [editMode, setEditMode] = useState(false);
    const params = useParams<{ id: string }>();

    console.log("params: ", params);
    useEffect(() => {

        const fetch = async () => {
            try {
                const _patient = await patientApi.GetPatientById(+params.id);
                setLoading(false);
                form.setFieldsValue({
                    ..._patient,
                    illnessName: _patient.illness?.name || "",
                    recommendedDoctorName: _patient.recommendedDoctor?.name || ""
                });
                setPatient(_patient)
            } catch (e) {
                message.error("Не удалось получить данные о пациенте")
            }
        }
        fetch()
    }, [])

    const deleteUser = () => {

    }

    const setFormFieldsBeforeChanges = () => {
        form.setFieldsValue({
            ...patient,
            illnessName: patient.illness?.name || "",
            recommendedDoctorName: patient.recommendedDoctor?.name || ""
        });
    }

    if (loading) {
        return <Skeleton/>
    }
    return (
        <div className={s.container}>
            <Form
                form={form}
                disabled={!editMode}
                labelAlign={"left"}
                labelCol={{
                    xxl: {
                        span: 9
                    },
                    xl: {
                        span: 9
                    },
                    lg: {
                        span: 10
                    },
                    md: {
                        span: 14
                    },
                    sm: {
                        span: 18
                    }
                }}
                wrapperCol={{
                    xxl: {
                        span: 15
                    },
                    xl: {
                        span: 15
                    },
                    lg: {
                        span: 14
                    },
                    md: {
                        span: 10
                    },
                    sm: {
                        span: 6
                    }
                }}
            >
                <Form.Item label={"Имя"} name={"name"} rules={[{required: true, message: 'Введите значение'}]}>
                    <Input
                        placeholder={"Укажите имя"}
                        // value={patient.name}
                    />
                </Form.Item>

                <Form.Item label={"Пол"} name={"gender"} rules={[{required: true, message: 'Введите значение'}]}>
                    <Radio.Group>
                        <Radio value={true}>М</Radio>
                        <Radio value={false}>Ж</Radio>
                    </Radio.Group>
                </Form.Item>

                <Form.Item label={"Возраст"} name={"age"} rules={[{required: true, message: 'Введите значение'}]}>
                    <Input
                        type="number"
                        placeholder={"Укажите возраст"}
                    />
                </Form.Item>

                <Form.Item label={"Уровень тревоги"} name={"levelAnxiety"}
                           rules={[{required: true, message: 'Введите значение'}]}>
                    <Input
                        type="number"
                        placeholder={"Укажите уровень тревоги"}
                    />
                </Form.Item>

                <Form.Item label={"Уровень депрессии"} name={"levelDepression"}
                           rules={[{required: true, message: 'Введите значение'}]}>
                    <Input
                        type="number"
                        placeholder={"Укажите уровень депрессии"}
                    />
                </Form.Item>

                <Form.Item label={"Уровень безнадежности"} name={"levelHopelessness"}
                           rules={[{required: true, message: 'Введите значение'}]}>
                    <Input
                        type="number"
                        placeholder={"Укажите уровень безнадежности"}
                    />
                </Form.Item>

                <Form.Item label={"Уровень астенического синдрома"} name={"levelAsthenicSyndrome"}
                           rules={[{required: true, message: 'Введите значение'}]}>
                    <Input
                        type="number"
                        placeholder={"Укажите уровень астенического синдрома"}
                    />
                </Form.Item>

                <Form.Item label={"Есть ли зависимость"} name={"hasAddiction"}
                           rules={[{required: true, message: 'Введите значение'}]}>
                    <Radio.Group>
                        <Radio value={true}>Да</Radio>
                        <Radio value={false}>Нет</Radio>
                    </Radio.Group>
                </Form.Item>

                <Form.Item label={"Заболевание"} name={"illnessName"}>
                    <Input disabled/>
                </Form.Item>

                <Form.Item label={"Нужна ли госпитализация"} name={"needHospitalization"}>
                    <Radio.Group disabled>
                        <Radio value={true}>Да</Radio>
                        <Radio value={false}>Нет</Radio>
                    </Radio.Group>
                </Form.Item>

                <Form.Item label={"Рекомендуемый врач"} name={"recommendedDoctorName"}>
                    <Input disabled/>
                </Form.Item>

                <Form.Item>
                    <Button htmlType={"submit"} icon={<SaveOutlined/>} className={s.button__marginRight}>
                        Сохранить
                    </Button>
                    <Button onClick={setFormFieldsBeforeChanges} icon={<UndoOutlined/>}>
                        Отмена
                    </Button>
                </Form.Item>
            </Form>

            <div className={s.footer}>
                <Button onClick={() => setEditMode(true)} icon={<EditOutlined/>} className={s.button__marginRight}>
                    Редактировать
                </Button>
                <Button onClick={deleteUser} danger icon={<DeleteOutlined/>}>
                    Удалить
                </Button>
            </div>

        </div>

    );
};

export default PatientPage;
