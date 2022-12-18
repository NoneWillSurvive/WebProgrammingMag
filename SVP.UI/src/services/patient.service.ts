import {PatientModel} from "../models/patient.model";
import axios from "axios";

export class PatientService {
    private apiUrl: string

    constructor(apiUrl: string) {
        this.apiUrl = apiUrl;
    }

    async GetPatientById(id: number): Promise<PatientModel.IPatient> {
        return await axios.get(this.apiUrl + "GetPatientById", {
            params: {
                patientId: id
            }
        }).then(res => res.data)
    }

}
