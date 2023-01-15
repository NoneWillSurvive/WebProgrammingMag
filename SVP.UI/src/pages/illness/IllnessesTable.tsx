import React, {useContext, useEffect, useState} from 'react';
import {useHistory} from "react-router-dom";
import {DataGrid} from "devextreme-react";
import {ServiceContext} from "../../contexts/ServiceContext";
import {Column, FilterRow, HeaderFilter, Paging, Scrolling, Selection} from "devextreme-react/data-grid";
import {Button} from "antd";
import {PlusOutlined} from "@ant-design/icons";
import {IllnessModel} from "../../models/illness.model";

const IllnessesTable = () => {

    const history = useHistory();
    const {illnessApi} = useContext(ServiceContext);
    const [dataSource, setDataSource] = useState<Array<IllnessModel.Illness>>([]);

    useEffect(() => {
        const fetch = async () => {
            const illnesses = await illnessApi.GetIllnesses();
            setDataSource(illnesses);
        }

        fetch();

    }, []);

    const cellRenderBtns = (data: any) => {
        return <div>
            <Button
                onClick={() => openDoctorForm(data.data.id)}
                size={"small"}
                disabled={data.data.name === "Здоровый"}
            >
                Открыть
            </Button>
        </div>
    }

    const doubleClickRow = (data: any) => {
        if (data.data.name === "Здоровый") {
            return;
        }
        openDoctorForm(data.data.id)
    }

    const openDoctorForm = (id: number | "add") => {
        history.push("illness/" + id);
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
                    caption="Наименование болезни"
                />

                <Column
                    dataField="type"
                    caption="Тип заболевания"
                />

                <Column
                    dataField="codeMKB"
                    caption="Код МКБ"
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

export default IllnessesTable;
