import React, {useContext, useEffect, useState} from 'react';
import {useHistory} from "react-router-dom";
import {DataGrid} from "devextreme-react";
import {ServiceContext} from "../../contexts/ServiceContext";
import {Column, FilterRow, HeaderFilter, Paging, Scrolling, Selection} from "devextreme-react/data-grid";
import {Button} from "antd";
import {PlusOutlined} from "@ant-design/icons";
import {DoctorModel} from "../../models/doctor.model";

const DoctorsTable = () => {

    const history = useHistory();
    const {doctorApi} = useContext(ServiceContext);
    const [dataSource, setDataSource] = useState<Array<DoctorModel.IDoctor>>([]);

    useEffect(() => {
        const fetch = async () => {
            const doctors = await doctorApi.GetDoctors();
            setDataSource(doctors);
        }

        fetch();

    }, []);

    const cellRenderBtns = (data: any) => {
        return <div>
            <Button
                onClick={() => openDoctorForm(data.data.id)}
                size={"small"}
            >
                Открыть
            </Button>
        </div>
    }

    const doubleClickRow = (data: any) => {
        openDoctorForm(data.data.id)
    }

    const openDoctorForm = (id: number | "add") => {
        history.push("doctor/" + id);
    }

    return (
        <div>

            <Button
                icon={<PlusOutlined/>}
                onClick={() => openDoctorForm("add")} style={{margin: 10}}
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
                    caption="Имя доктора"
                />

                <Column
                    dataField="qualification"
                    caption="Квалификация (-и)"
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

export default DoctorsTable;
