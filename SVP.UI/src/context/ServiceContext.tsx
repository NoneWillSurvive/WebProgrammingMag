import {createContext} from "react";
import {DoctorService} from "../service/doctor.service";
import {PatientService} from "../service/patient.service";
import {IllnessService} from "../service/illness.service";

interface IServiceContext {
    doctorApi: InstanceType<typeof DoctorService>
    patientApi: InstanceType<typeof PatientService>
    illnessApi: InstanceType<typeof IllnessService>
}

export const ServiceContext = createContext<IServiceContext>({} as IServiceContext)
