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

    async AddPatient(payload: PatientModel.IPatient): Promise<PatientModel.IPatient> {
        return await axios.post(this.apiUrl + "AddPatient", {
            id: payload.illness!.id,
            name: payload.illness!.name,
            codeMKB: payload.illness!.codeMKB,
            type: payload.illness!.type
        }, {
            params: {
                gender: payload.gender,
                age: payload.age,
                name: payload.name,
                levelAnxiety: payload.levelAnxiety,
                levelDepression: payload.levelDepression,
                levelHopelessness: payload.levelHopelessness,
                levelAsthenicSyndrome: payload.levelAsthenicSyndrome,
                hasAddiction: payload.hasAddiction,
            }
        }).then(res => res.data)

    }

    async EditPatient(payload: PatientModel.IPatient): Promise<PatientModel.IPatient> {
        return await axios.put(this.apiUrl + "EditPatient", {
            id: payload.illness!.id,
            name: payload.illness!.name,
            codeMKB: payload.illness!.codeMKB,
            type: payload.illness!.type
        }, {
            params: {
                id: payload.id,
                gender: payload.gender,
                age: payload.age,
                name: payload.name,
                levelAnxiety: payload.levelAnxiety,
                levelDepression: payload.levelDepression,
                levelHopelessness: payload.levelHopelessness,
                levelAsthenicSyndrome: payload.levelAsthenicSyndrome,
                hasAddiction: payload.hasAddiction,
            }
        }).then(res => res.data)
    }

    async DeletePatient(id: PatientModel.IPatient["id"]): Promise<any> {
        return await axios.delete(this.apiUrl + `DeletePatient?patientId=${id}`)
            .then(res => res.data)
    }

}
