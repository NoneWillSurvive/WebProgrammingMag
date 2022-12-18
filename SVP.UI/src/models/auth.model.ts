export declare module AuthModel {

    export interface PageProps {

    }

    export interface FormProps {
        setUserAuthorizedId: (id: number) => void
        isPatient: boolean
    }

    export interface SignInFormProps {
        onFinishForm: (login: string, password: string) => void
    }

    export interface RegistrationForm {

    }

}
