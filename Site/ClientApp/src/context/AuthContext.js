import React, { createContext, useEffect, useReducer } from "react";
import { authReducer } from "../store/user/reducer";
import UserService from "../services/userService";

const authInicialState = {
    status: 'checking',
    token: null,
    user: null,
    errorMessage: ''
}

export const AuthContext = createContext({})

export const AuthProvider = ({children}) =>{

    const [ state, dispatch ] = useReducer( authReducer, authInicialState );

    const {login, register} = UserService

    useEffect(()=>{
        checkToken().then()
    },[])

    const checkToken = async () =>{
        const data = JSON.parse(localStorage.getItem('localSesion'));
        !data ? dispatch({type: 'no-auth'}) :
            dispatch({
                type: 'signUp',
                payload: {
                    token : data,
                    user: data
                }
            })
    }

    const signUp = async (data) => {
        try {
            const { user } = await login(data)
            dispatch({
                type: 'signUp',
                payload: {
                    token: user.token,
                    user: user
                }
            });
            localStorage.setItem('localSesion',JSON.stringify(user));
        }catch (error){
            dispatch({type: 'addError', payload : error?.error.toString() })
        }
    };
    const signIn = async (data) => {
        try {
            const { user } = await register(data)
            dispatch({
                type: 'signUp',
                payload: {
                    token: user.token,
                    user: user
                }
            });
            localStorage.setItem('localSesion',JSON.stringify(user));
        }catch (error ){
            dispatch({type: 'addError', payload : error?.error.toString() })
        }
    };
    /*const logOut = async () => {
        //await AsyncStorage.removeItem('token')
        dispatch({type: 'loaded'})
        setTimeout(()=>{
            dispatch({type: 'logout'})
        },1000)
    };*/

    const removeError = () => {
        dispatch({type: "removeError"})
    };

    return (
        <AuthContext.Provider value={{...state, signUp, signIn, removeError,}}>
            {children}
        </AuthContext.Provider>
    )
}
