import axios from "axios";
import {IllnessModel} from "../models/illness.model";

export class IllnessService {
    private apiUrl: string

    constructor(apiUrl: string) {
        this.apiUrl = apiUrl;
    }

    async GetIllnesses(): Promise<IllnessModel.Illness[]> {
        return await axios.get(this.apiUrl + "GetIllnesses").then(res => res.data)
    }

    async GetIllnessById(id: number): Promise<IllnessModel.Illness> {
        return await axios.get(this.apiUrl + "GetIllnessById", {
            params: {
                illnessId: id
            }
        }).then(res => res.data)
    }

    async AddIllness(payload: IllnessModel.Illness): Promise<IllnessModel.Illness> {
        return await axios.post(this.apiUrl + "AddIllness", {}, {
            params: {
                name: payload.name,
                codeMKB: payload.codeMKB,
                type: payload.type
            }
        }).then(res => res.data)
    }

    async EditIllness(payload: IllnessModel.Illness): Promise<IllnessModel.Illness> {
        return await axios.put(this.apiUrl + "EditIllness", {}, {
            params: {
                id: payload.id,
                name: payload.name,
                codeMKB: payload.codeMKB,
                type: payload.type
            }
        }).then(res => res.data)
    }

    async DeleteIllness(id: IllnessModel.Illness["id"]): Promise<any> {
        return await axios.delete(this.apiUrl + `DeleteIllness?illnessId=${id}`)
            .then(res => res.data)
    }
}
