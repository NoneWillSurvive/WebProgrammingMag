import React, {useContext, useEffect, useState} from 'react';
import {ServiceContext} from "../../contexts/ServiceContext";
import {DoctorModel} from "../../models/doctor.model";
import {message, Skeleton} from "antd";
import {useParams} from "react-router-dom";
import s from "../style.module.css";
import DoctorForm from "./DoctorComponents/DoctorForm";

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

    useEffect(() => {

        const fetch = async () => {
            try {
                if (params.id) {
                    const _doctor = await doctorApi.GetDoctorById(+params.id);
                    if (!doctor.id) {
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

    if (loading) {
        return <Skeleton/>
    }

    return (
        <div className={s.container}>

            <h3>Модуль "Доктор"</h3>

            <DoctorForm doctor={doctor}/>

        </div>

    );
};

export default DoctorPage;
