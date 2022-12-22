import React, {useContext, useEffect} from 'react';
import {DoctorModel} from "../../../models/doctor.model";
import {AppContext} from "../../../contexts/AppContext";
import {ServiceContext} from "../../../contexts/ServiceContext";
import {Button, Form, Input, message, Modal} from "antd";
import {
    DeleteOutlined,
    ExclamationCircleOutlined,
    MinusCircleOutlined,
    PlusOutlined,
    SaveOutlined,
    UndoOutlined
} from "@ant-design/icons";
import s from "../../style.module.css";

type FormProps = {
    doctor: DoctorModel.IDoctor
}
const DoctorForm: React.FC<FormProps> = (props) => {

    const {baseUrl} = useContext(AppContext);
    const {doctorApi} = useContext(ServiceContext);
    const [form] = Form.useForm();

    useEffect(() => {
        form.setFieldsValue({
            ...props.doctor,
            qualification: props.doctor.qualification.split(", ").map((str) => ({
                value: str
            }))
        });
    }, [form, props.doctor]);

    const onFinishForm = async (data: any) => {
        const parceQualificationArrayOfObjToString = (qualificationArray: Array<{ value: string }>): string => {
            return qualificationArray.map((elem: { value: string }) => {
                return elem.value
            }).join(", ")
        }

        if (!props.doctor.id) {
            await AddDoctor({
                id: 0,
                name: data.name,
                qualification: parceQualificationArrayOfObjToString(data.qualification)
            });
        } else {
            await EditDoctor({
                id: props.doctor.id,
                name: data.name,
                qualification: parceQualificationArrayOfObjToString(data.qualification)
            });
        }
    }

    const AddDoctor = async (doctor: DoctorModel.IDoctor) => {
        try {
            const savedDoctor = await doctorApi.AddDoctor(doctor);
            alert("Доктор успешно сохранен");
            window.location.href = baseUrl + `doctor/${savedDoctor.id}`
        } catch (e) {
            message.error("Не удалось сохранить доктора");
            console.error(e);
        }
    }

    const EditDoctor = async (doctor: DoctorModel.IDoctor) => {
        try {
            await doctorApi.EditDoctor(doctor);
            message.success("Доктор успешно отредактирован");
        } catch (e) {
            message.error("Не удалось отредактировать доктора");
            console.error(e);
        }
    }

    const setFormFieldsBeforeChanges = () => {
        form.setFieldsValue({
            ...props.doctor,
            qualification: props.doctor.qualification.split(", ").map((str) => ({
                value: str
            }))
        });
    }
    const confirmDeleteDoctor = () => {
        Modal.confirm({
            title: 'Подтверждение удаления',
            icon: <ExclamationCircleOutlined/>,
            content: 'Вы действительно желаете удалить данные о докторе?',
            okText: 'Удалить',
            cancelText: 'Отмена',
            onOk: deleteDoctor,
        })
    }

    const deleteDoctor = async () => {
        try {
            await doctorApi.DeleteDoctor(props.doctor.id);
            alert("Доктор успешно удален");
            window.location.href = baseUrl + `doctor`
        } catch (e) {
            message.error("Не удалось удалить доктора");
            console.error(e);
        }
    }

    return (
        <div>

            <h3>
                {props.doctor.id ? "Редактирование информации о докторе" : "Добавление доктора"}
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

                <Form.List name="qualification">
                    {(fields, {add, remove}) => (
                        <>
                            {fields.map(({key, name, ...restField}) => (
                                <div className={s.qualification__item}>
                                    <Form.Item
                                        label={"Квалификация"}
                                        {...restField}
                                        name={[name, 'value']}
                                        rules={[{required: true, message: 'Введите значение'}]}
                                    >
                                        <Input placeholder="Название квалификации" style={{width: "92%"}}/>
                                    </Form.Item>
                                    <MinusCircleOutlined onClick={() => remove(name)} className={s.removeItem__btn}/>
                                </div>
                            ))}
                            <Form.Item>
                                <Button type="dashed" onClick={() => add()} block icon={<PlusOutlined/>}>
                                    Добавить квалификацию
                                </Button>
                            </Form.Item>
                        </>
                    )}
                </Form.List>

                <Form.Item>
                    <Button htmlType={"submit"} icon={<SaveOutlined/>} className={s.button__marginRight}>
                        Сохранить
                    </Button>
                    <Button onClick={setFormFieldsBeforeChanges} icon={<UndoOutlined/>}
                            className={s.button__marginRight}>
                        Отмена
                    </Button>
                    {props.doctor.id ? <Button
                        onClick={confirmDeleteDoctor}
                        icon={<DeleteOutlined/>}
                        danger
                    >
                        Удалить доктора
                    </Button> : ""}
                </Form.Item>

            </Form>

        </div>
    );
};

export default DoctorForm;
