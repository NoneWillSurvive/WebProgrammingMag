import React, {useContext, useEffect, useState} from 'react';
import {useHistory} from "react-router-dom";
import {DataGrid} from "devextreme-react";
import {ServiceContext} from "../../contexts/ServiceContext";
import {PatientModel} from "../../models/patient.model";
import {Column, FilterRow, HeaderFilter, Paging, Scrolling, Selection} from "devextreme-react/data-grid";
import {Button} from "antd";
import {PlusOutlined} from "@ant-design/icons";

const PatientsTable = () => {

    const history = useHistory();
    const {patientApi} = useContext(ServiceContext);
    const [dataSource, setDataSource] = useState<Array<PatientModel.IPatient>>([]);

    useEffect(() => {
        const fetch = async () => {
            const patients = await patientApi.GetPatients();
            setDataSource(patients);
        }

        fetch();

    }, []);

    const renderCellGender = (data: any) => {
        return data.data.gender ? <div style={{color: "blue"}}>
            Мужской
        </div> : <div style={{color: "pink"}}>
            Женский
        </div>;
    }


    const cellRenderBtns = (data: any) => {
        return <div>
            <Button onClick={() => openPatientForm(data.data.id)} size={"small"}>
                Открыть
            </Button>
        </div>
    }

    const doubleClickRow = (data: any) => {
        openPatientForm(data.data.id)
    }

    const openPatientForm = (id: number | "add") => {
        history.push("patient/" + id);
    }

    return (
        <div>

            <Button
                icon={<PlusOutlined/>}
                onClick={() => openPatientForm("add")} style={{margin: 10}}
            >
                Добавить
            </Button>

            <Button
                icon={<PlusOutlined/>}
                onClick={() => history.push("/")}
                style={{margin: 10, marginLeft: 0}}
            >
                На главную
            </Button>

            <DataGrid
                key={"id"}
                dataSource={dataSource}
                width={"100%"}
                showBorders
                showRowLines
                allowColumnResizing
                height={700}
                onRowDblClick={doubleClickRow}
            >
                <Paging pageSize={100}/>
                <Selection mode="single"/>
                <Scrolling mode={"virtual"} showScrollbar/>
                <FilterRow visible/>
                <HeaderFilter visible/>

                <Column
                    dataField="name"
                    caption="Имя пациента"
                />

                <Column
                    dataField="age"
                    type="number"
                    caption="Возраст"
                />

                <Column
                    dataField="gender"
                    caption="Пол пациента"
                    cellRender={renderCellGender}
                />

                <Column
                    dataField="illness.name"
                    caption="Заболевание"
                />

                <Column
                    width={90}
                    caption={"Действия"}
                    cellRender={cellRenderBtns}
                />

            </DataGrid>

        </div>
    );
};

export default PatientsTable;
