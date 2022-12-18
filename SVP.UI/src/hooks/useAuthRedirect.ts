import {useEffect} from "react";
import {useHistory} from "react-router-dom";

const useAuthRedirect = () => {

    const history = useHistory();

    useEffect(() => {

        type localStorageObj = { value: boolean, timestamp: Date };
        const obj: localStorageObj = JSON.parse(window.localStorage.getItem("isAuthUser") || "");
        const currentDate = new Date();

        if (!obj.value || obj.timestamp < currentDate) {
            history.push("/auth");
        }

    }, []);
};

export default useAuthRedirect;
