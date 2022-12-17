import {createContext} from "react";

interface IAppContext {
    baseUrl: string
    apiUrl: string

    userId: number
}

export const AppContext = createContext<IAppContext>({} as IAppContext)
