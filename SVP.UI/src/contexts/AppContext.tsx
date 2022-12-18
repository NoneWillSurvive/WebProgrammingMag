import {createContext} from "react";

interface IAppContext {
    baseUrl: string
    apiUrl: string
}

export const AppContext = createContext<IAppContext>({} as IAppContext)
