import React, {useContext, useEffect, useState} from 'react';
import {ServiceContext} from "../../contexts/ServiceContext";
import {IllnessModel} from "../../models/illness.model";
import {useParams} from "react-router-dom";
import {message, Skeleton} from "antd";
import s from "../style.module.css";
import IllnessForm from "./IllnessComponents/IllnessForm";

const initialStateIllness: IllnessModel.Illness = {
    id: 0,
    name: "",
    codeMKB: "",
    type: null,
}
const IllnessPage = () => {

    const {illnessApi} = useContext(ServiceContext);
    const [illness, setIllness] = useState<IllnessModel.Illness>(initialStateIllness);
    const [loading, setLoading] = useState(true);
    const params = useParams<{ id: string }>();

    useEffect(() => {

        const fetch = async () => {
            try {
                if (params.id) {
                    const _illness = await illnessApi.GetIllnessById(+params.id);
                    if (!_illness.id) {
                        throw new Error();
                    }
                    setIllness(_illness);
                }
                setLoading(false);
            } catch (e) {
                message.error("Не удалось получить данные о заболевании")
            }
        }
        fetch()
    }, [])

    if (loading) {
        return <Skeleton/>
    }

    return (
        <div className={s.container}>

            <h3>Модуль "Болезнь"</h3>

            <IllnessForm illness={illness}/>

        </div>
    );
};

export default IllnessPage;
