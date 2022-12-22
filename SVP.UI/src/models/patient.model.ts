import {IllnessModel} from "./illness.model";

export declare module PatientModel {

    export interface RecDoctor {
        id: number,
        name: string,
        qualification: string
    }

    export interface IPatient {
        id: number,
        gender: boolean,
        age: number,
        name: string,
        illness: IllnessModel.Illness,
        levelAnxiety: number,
        levelDepression: number,
        levelHopelessness: number,
        levelAsthenicSyndrome: number,
        hasAddiction: boolean
        needHospitalization: boolean,
        recommendedDoctor: RecDoctor | null
    }
}
