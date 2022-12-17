import {createContext} from "react";
import {DoctorService} from "../services/doctor.service";
import {PatientService} from "../services/patient.service";
import {IllnessService} from "../services/illness.service";

interface IServiceContext {
    doctorApi: InstanceType<typeof DoctorService>
    patientApi: InstanceType<typeof PatientService>
    illnessApi: InstanceType<typeof IllnessService>
}

export const ServiceContext = createContext<IServiceContext>({} as IServiceContext)
