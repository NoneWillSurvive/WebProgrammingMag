import React, {useContext, useEffect, useState} from 'react';
import {ServiceContext} from "../../contexts/ServiceContext";
import {DoctorModel} from "../../models/doctor.model";
import {Button, message, Skeleton} from "antd";
import {useHistory, useParams} from "react-router-dom";
import s from "../style.module.css";
import DoctorForm from "./DoctorComponents/DoctorForm";
import {ArrowLeftOutlined} from "@ant-design/icons";

const initialStateDoctor: DoctorModel.IDoctor = {
    id: 0,
    name: "",
    qualification: ""
}
const DoctorPage = () => {

    const {doctorApi} = useContext(ServiceContext);
    const [doctor, setDoctor] = useState<DoctorModel.IDoctor>(initialStateDoctor);
    const [loading, setLoading] = useState(true);
    const params = useParams<{ id: string }>();
    const history = useHistory();

    useEffect(() => {

        const fetch = async () => {
            try {
                if (params.id && params.id !== "add") {
                    const _doctor = await doctorApi.GetDoctorById(+params.id);
                    if (!_doctor.id) {
                        throw new Error();
                    }
                    setDoctor(_doctor);
                }
                setLoading(false);
            } catch (e) {
                message.error("Не удалось получить данные о пациенте")
            }
        }
        fetch()
    }, [])

    const toMaiPage = () => {
        history.push("/doctor");
    }

    if (loading) {
        return <Skeleton/>
    }

    return (
        <div className={s.container}>

            <Button icon={<ArrowLeftOutlined/>} onClick={toMaiPage}>
                Назад
            </Button>

            <h3>Модуль "Доктор"</h3>

            <DoctorForm doctor={doctor}/>

        </div>

    );
};

export default DoctorPage;
