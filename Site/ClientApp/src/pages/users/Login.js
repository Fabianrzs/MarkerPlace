import Input from "../../components/common/input";
import Form from "../../components/common/Form";
import {useForm} from "react-hook-form";
import LayoutUser from "../../components/LayoutUser";
import {useContext, useEffect} from "react";
import {AuthContext} from "../../context/AuthContext";

export default function Login(){
    const { signIn} = useContext(AuthContext);
    const formMethods = useForm({
        mode: "onChange",
        defaultValues: {UserName : "", Password : ""},
    });

    const {formState:{errs} } = formMethods

    const onSubmit = (data) =>{
        signIn(data).then(data => console.log(data))
    }

    return(
        <LayoutUser>
            <h3 className={"p-2 mb-4 text-center"}>Iniciar Sesion</h3>
            <Form formMethods={formMethods} onSubmit={onSubmit}
                  btnText={"Iniciar Sesion"}>
                <Input label={"Nombre de Usuario"} id={"UserName"}
                       name={"UserName"}  type = {"text"}/>
                <Input label={"Contraseña"} id={"Password"}
                       name={"Password"}   type = {"password"}/>
            </Form>
        </LayoutUser>
    )

}
