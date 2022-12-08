import {useForm} from "react-hook-form";
import LayoutUser from "../../components/LayoutUser";
import Form from "../../components/common/Form";
import Input from "../../components/common/input";
import Select from "../../components/common/select";

export default function CategoryRegister(){
    const formMethods = useForm({
        mode: "onChange",
        defaultValues: {name : ""},
    });

    const onSubmit = (data) =>{
        console.log(data)
    }
    return(
        <>
            <LayoutUser>
                <h3 className={"p-2 mb-4 text-center"}>Registrar Productos</h3>
                <Form formMethods={formMethods} onSubmit={onSubmit}
                      btnText={"Guardar Categoria"}>
                    <Input label={"Nombre"} id={"name"}
                           name={"name"}  type = {"text"}/>
                </Form>
            </LayoutUser>
        </>
    )
}
