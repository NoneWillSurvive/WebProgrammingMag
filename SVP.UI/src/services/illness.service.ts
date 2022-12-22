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
}
