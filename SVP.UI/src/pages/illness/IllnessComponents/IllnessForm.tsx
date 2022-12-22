import React, {useContext, useEffect} from 'react';
import {IllnessModel} from "../../../models/illness.model";
import {AppContext} from "../../../contexts/AppContext";
import {ServiceContext} from "../../../contexts/ServiceContext";
import {Button, Form, Input, message, Modal, Select} from "antd";
import {DeleteOutlined, ExclamationCircleOutlined, SaveOutlined, UndoOutlined} from "@ant-design/icons";
import s from "../../style.module.css";

const typesArray = [
    "Депрессивное расстройство",
    "Аффективное расстройство",
    "Шизофреническое расстройство",
    "Аутистическое расстройство",
    "Расстройство личности",
    "Тревожное расстройство",
    "Нервное расстройство",
]

type IllnessFormProps = {
    illness: IllnessModel.Illness
}
const IllnessForm: React.FC<IllnessFormProps> = (props, context) => {

    const {baseUrl} = useContext(AppContext);
    const {illnessApi} = useContext(ServiceContext);
    const [form] = Form.useForm();

    useEffect(() => {
        form.setFieldsValue(props.illness);
    }, [form, props.illness]);

    const setFormFieldsBeforeChanges = () => {
        form.setFieldsValue(props.illness);
    }

    const onFinishForm = async (data: IllnessModel.Illness) => {
        const payload: IllnessModel.Illness = {
            ...data,
            id: props.illness.id
        }
        if (props.illness.id) {
            await EditIllness(payload);
        } else {
            await AddIllness(payload)
        }
    }

    const AddIllness = async (data: IllnessModel.Illness) => {
        try {
            const savedPatient = await illnessApi.AddIllness(data);
            alert("Заболевание успешно сохранено");
            window.location.href = baseUrl + `illness/${savedPatient.id}`
        } catch (e) {
            message.error("Не удалось сохранить заболевание");
            console.error(e);
        }
    }

    const EditIllness = async (data: IllnessModel.Illness) => {
        try {
            await illnessApi.EditIllness(data);
            message.success("Заболевание успешно отредактировано");
        } catch (e) {
            message.error("Не удалось отредактировать заболевание");
            console.error(e);
        }
    }

    const confirmDeleteIllness = () => {
        Modal.confirm({
            title: 'Подтверждение удаления',
            icon: <ExclamationCircleOutlined/>,
            content: 'Вы действительно желаете удалить данные о заболевании?',
            okText: 'Удалить',
            cancelText: 'Отмена',
            onOk: deleteIllness,
        })
    }

    const deleteIllness = async () => {
        try {
            await illnessApi.DeleteIllness(props.illness.id);
            alert("Заболевание успешно удалено");
            window.location.href = baseUrl + `illness`
        } catch (e) {
            message.error("Не удалось удалить заболевание");
            console.error(e);
        }
    }

    const illnessTypesOptions = typesArray.map((elem) => {
        return {
            value: elem,
            label: elem
        }
    })

    return (
        <div>
            <h3>
                {props.illness.id ? "Редактирование информации о заболевании" : "Добавление заболевания"}
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

                <Form.Item label={"Наименование"} name={"name"} rules={[{required: true, message: 'Введите значение'}]}>
                    <Input placeholder={"Укажите имя"}/>
                </Form.Item>

                <Form.Item label={"Код МКБ"} name={"codeMKB"} rules={[{required: true, message: 'Введите значение'}]}>
                    <Input placeholder={"Укажите код МКБ"}/>
                </Form.Item>

                <Form.Item label={"Тип заболевания"} name={"type"}
                           rules={[{required: true, message: 'Введите значение'}]}>
                    <Select options={illnessTypesOptions} placeholder={"Укажите тип"}/>
                </Form.Item>

                <Form.Item>
                    <Button htmlType={"submit"} icon={<SaveOutlined/>} className={s.button__marginRight}>
                        Сохранить
                    </Button>
                    <Button onClick={setFormFieldsBeforeChanges} icon={<UndoOutlined/>}
                            className={s.button__marginRight}>
                        Отмена
                    </Button>
                    {props.illness.id ? <Button
                        onClick={confirmDeleteIllness}
                        icon={<DeleteOutlined/>}
                        danger
                    >
                        Удалить заболевание
                    </Button> : ""}
                </Form.Item>

            </Form>
        </div>
    );
};

export default IllnessForm;
