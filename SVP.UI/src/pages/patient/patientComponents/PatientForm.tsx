import React, {useContext, useEffect} from 'react';
import {Button, Form, Input, message, Modal, Radio, Select} from "antd";
import {DeleteOutlined, ExclamationCircleOutlined, SaveOutlined, UndoOutlined} from "@ant-design/icons";
import s from "../style.module.css";
import {PatientModel} from "../../../models/patient.model";
import {IllnessModel} from "../../../models/illness.model";
import {ServiceContext} from "../../../contexts/ServiceContext";
import {useHistory} from "react-router-dom";
import {AppContext} from "../../../contexts/AppContext";

type FormProps = {
    patient: PatientModel.IPatient
    illnesses: Array<IllnessModel.Illness>
}
const PatientForm: React.FC<FormProps> = (props) => {

    const {baseUrl} = useContext(AppContext);
    const {patientApi} = useContext(ServiceContext);
    const [form] = Form.useForm();
    const history = useHistory();

    useEffect(() => {
        form.setFieldsValue({
            ...props.patient,
            illness: JSON.stringify(props.patient.illness),
            recommendedDoctorName: props.patient.recommendedDoctor?.id ?
                `${props.patient.recommendedDoctor?.name}: ${props.patient.recommendedDoctor?.qualification}`
                : ""
        });
    }, [form, props.patient]);

    const setFormFieldsBeforeChanges = () => {
        form.setFieldsValue({
            ...props.patient,
            illness: JSON.stringify(props.patient.illness),
            recommendedDoctorName: props.patient.recommendedDoctor?.id ?
                `${props.patient.recommendedDoctor?.name}: ${props.patient.recommendedDoctor?.qualification}`
                : ""
        });
    }

    const confirmDeletePatient = () => {
        Modal.confirm({
            title: 'Подтверждение удаления',
            icon: <ExclamationCircleOutlined/>,
            content: 'Вы действительно желаете удалить данные о пациенте?',
            okText: 'Удалить',
            cancelText: 'Отмена',
            onOk: deletePatient,
        })
    }

    const deletePatient = async () => {
        try {
            await patientApi.DeletePatient(props.patient.id);
            alert("Пациент успешно удален");
            window.location.href = baseUrl + `patient`
        } catch (e) {
            message.error("Не удалось удалить пациента");
            console.error(e);
        }
    }

    const onFinishForm = async (data: PatientModel.IPatient) => {
        const payload: PatientModel.IPatient = {
            ...data,
            // @ts-ignore
            illness: JSON.parse(data.illness),
            id: props.patient.id
        }
        if (props.patient.id) {
            await EditPatient(payload);
        } else {
            await AddPatient(payload)
        }
    }

    const AddPatient = async (data: PatientModel.IPatient) => {
        try {
            const savedPatient = await patientApi.AddPatient(data);
            alert("Пациент успешно сохранен");
            window.location.href = baseUrl + `patient/${savedPatient.id}`
        } catch (e) {
            message.error("Не удалось сохранить пациента");
            console.error(e);
        }
    }

    const EditPatient = async (data: PatientModel.IPatient) => {
        try {
            await patientApi.EditPatient(data);
            message.success("Пациент успешно отредактирован");
        } catch (e) {
            message.error("Не удалось отредактировать пациента");
            console.error(e);
        }
    }

    const illnessOptions = props.illnesses.map((elem: IllnessModel.Illness) => {
        return {
            value: JSON.stringify(elem),
            label: elem.name
        }
    });

    return (
        <>
            <h3>
                {props.patient.id ? "Редактирование информации о пациенте" : "Добавление пациента"}
            </h3>
            <Form
                form={form}
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
                onFinish={onFinishForm}
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

                <Form.Item label={"Заболевание"} name={"illness"}
                           rules={[{required: true, message: 'Введите значение'}]}
                >
                    <Select options={illnessOptions}/>
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
                    <Button onClick={setFormFieldsBeforeChanges} icon={<UndoOutlined/>}
                            className={s.button__marginRight}>
                        Отмена
                    </Button>
                    {props.patient.id && <Button
                        onClick={confirmDeletePatient}
                        icon={<DeleteOutlined/>}
                        danger
                    >
                        Удалить пациента
                    </Button>}
                </Form.Item>
            </Form>
        </>
    );
};

export default PatientForm;
