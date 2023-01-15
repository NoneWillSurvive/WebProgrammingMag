import React from 'react';
import s from "./MainPage.module.css"
import doctorBlackImg from "../../assets/doctor_black.png"
import patientBlackImg from "../../assets/patient_black.png"
import deseaseBlackImg from "../../assets/desease_black.png"
import {useHistory} from "react-router-dom";

const MainPage = () => {

    const history = useHistory();
    const onClickModule = (key: "patient" | "doctor" | "illness") => {
        history.push(key);
    }

    return (
        <>
            <h3 className={s.title}>Выберите один из модулей</h3>
            <div className={s.container__modules}>
                <div className={s.module} onClick={() => onClickModule("patient")}>
                    <img src={patientBlackImg} alt=""/>
                    Пациент
                </div>

                <div className={s.module} onClick={() => onClickModule("doctor")}>
                    <img src={doctorBlackImg} alt=""/>
                    Доктор
                </div>

                <div className={s.module} onClick={() => onClickModule("illness")}>
                    <img src={deseaseBlackImg} alt=""/>
                    Заболевание
                </div>
            </div>
        </>
    );
};

export default MainPage;
