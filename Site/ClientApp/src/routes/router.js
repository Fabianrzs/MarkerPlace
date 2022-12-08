import AppRoutes from "./AppRoutes";
import {Route, Routes} from "react-router-dom";
import React, {useContext} from "react";
import {AuthContext} from "../context/AuthContext";
import Loading from "../components/common/Loading";

export default function Router(){

    const {status, user} = useContext(AuthContext);

    if (status === 'checking') {
        return <Loading/>
    }
    return(
        <Routes>
            {AppRoutes.map((route, index) => {
                const { element, ...rest } = route;
                return <Route key={index} {...rest} element={element} />;
            })}
        </Routes>
    )
}
