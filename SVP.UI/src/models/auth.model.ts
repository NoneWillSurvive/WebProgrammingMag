export declare module AuthModel {

    export interface PageProps {
        setAuthorizedId: (id: number) => void
    }

    export interface FormProps {
        setAuthorizedId: (id: number) => void
        isPatient: boolean
    }

    export interface SignInFormProps {
        onFinishForm: (login: string, password: string) => void
    }

    export interface RegistrationForm {

    }

}
