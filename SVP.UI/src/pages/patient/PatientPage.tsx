import React, {useContext, useEffect, useState} from 'react';
import {message, Skeleton} from "antd";
import {PatientModel} from "../../models/patient.model";
import {useParams} from "react-router-dom";
import {ServiceContext} from "../../contexts/ServiceContext";
import s from "../style.module.css";
import PatientForm from "./patientComponents/PatientForm";
import {IllnessModel} from "../../models/illness.model";


const initialStatePatient: PatientModel.IPatient = {
    id: 0,
    gender: true,
    age: 0,
    name: "",
    illness: {
        name: "Здоровый",
        id: 0,
        type: "Здоровый",
        codeMKB: ""
    },
    levelAnxiety: 0,
    levelDepression: 0,
    levelHopelessness: 0,
    levelAsthenicSyndrome: 0,
    hasAddiction: false,
    needHospitalization: false,
    recommendedDoctor: null
}
const PatientPage = () => {

    const {patientApi, illnessApi} = useContext(ServiceContext);
    const [patient, setPatient] = useState<PatientModel.IPatient>(initialStatePatient);
    const [illnesses, setIllnesses] = useState<IllnessModel.Illness[]>([]);
    const [loading, setLoading] = useState(true);
    const params = useParams<{ id: string }>();

    console.log("params: ", params);
    useEffect(() => {

        const fetch = async () => {
            try {
                if (params.id) {
                    const _patient = await patientApi.GetPatientById(+params.id);
                    if (!_patient.id) {
                        throw new Error();
                    }
                    setPatient(_patient);
                }
                const _illnesses = await illnessApi.GetIllnesses();
                setIllnesses(_illnesses);
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

            <h3>Модуль "Пациент"</h3>

            <PatientForm patient={patient} illnesses={illnesses}/>

        </div>

    );
};

export default PatientPage;
