import axios from "axios";

export class AuthService {

    private apiUrl: string

    constructor(apiUrl: string) {
        this.apiUrl = apiUrl;
    }

    async CheckAuthUser(isPatient: boolean, login: string, password: string): Promise<number> {
        return await axios.get(this.apiUrl + "CheckAuthUser", {
            params: {
                isPatient,
                login,
                password
            }
        }).then(res => res.data)
    }
}
