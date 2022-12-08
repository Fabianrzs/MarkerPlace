import {useForm} from "react-hook-form";
import LayoutUser from "../../components/LayoutUser";
import Form from "../../components/common/Form";
import Input from "../../components/common/input";
import {useContext} from "react";
import {AuthContext} from "../../context/AuthContext";
export default function Register(){

    const { signIn} = useContext(AuthContext);

    const formMethods = useForm({
        mode: "onChange",
        defaultValues: {UserName : "", Password : ""},
    });

    const {formState:{errs} } = formMethods

    const onSubmit = (data) =>{
        signIn(data)
    }

    return(
        <LayoutUser>
            <h3 className={"p-2 mb-4 text-center"}>Registrate</h3>
            <Form formMethods={formMethods} onSubmit={onSubmit}
                  btnText={"Registrarse"}>
                <Input label={"Nombre de Usuario"} id={"UserName"}
                       name={"UserName"}  type = {"text"}/>
                <Input label={"Contraseña"} id={"Password"}
                       name={"Password"}   type = {"password"}/>
            </Form>
        </LayoutUser>
    )
}
