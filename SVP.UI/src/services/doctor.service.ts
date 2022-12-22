import axios from "axios";
import {DoctorModel} from "../models/doctor.model";

export class DoctorService {

    private apiUrl: string

    constructor(apiUrl: string) {
        this.apiUrl = apiUrl;
    }

    async GetDoctorById(id: number): Promise<DoctorModel.IDoctor> {
        return await axios.get(this.apiUrl + "GetDoctorById", {
            params: {
                doctorId: id
            }
        }).then(res => res.data)
    }

    async AddDoctor(payload: DoctorModel.IDoctor): Promise<DoctorModel.IDoctor> {
        return await axios.put(this.apiUrl + "EditDoctor", {}, {
            params: {
                name: payload.name,
                qualification: payload.qualification
            }
        }).then(res => res.data)
    }

    async EditDoctor(payload: DoctorModel.IDoctor): Promise<DoctorModel.IDoctor> {
        return await axios.put(this.apiUrl + "EditDoctor", {}, {
            params: {
                id: payload.id,
                name: payload.name,
                qualification: payload.qualification
            }
        }).then(res => res.data)
    }

    async DeleteDoctor(id: DoctorModel.IDoctor["id"]): Promise<any> {
        return await axios.delete(this.apiUrl + `DeleteDoctor?doctorId=${id}`)
            .then(res => res.data)
    }
}
