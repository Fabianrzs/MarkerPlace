import {useForm} from "react-hook-form";
import LayoutUser from "../../components/LayoutUser";
import Form from "../../components/common/Form";
import Input from "../../components/common/input";
import Select from "../../components/common/select";

export default function ProductRegister(){
    const formMethods = useForm({
        mode: "onChange",
        defaultValues: {image : "", name : "", descriptions : "", value : 0, category : 0},
    });

    const options = [
        {id:1, name:"Holas"},
        {id:2, name:"Holas1"},
        {id:3, name:"Holas11"},
        {id:4, name:"Holas111"},
        {id:5, name:"Holas1111"},
    ]

    const onSubmit = (data) =>{
        console.log(data)
    }
    return(
        <>
            <LayoutUser>
                <h3 className={"p-2 mb-4 text-center"}>Registrar Productos</h3>
                <Form formMethods={formMethods} onSubmit={onSubmit}
                      btnText={"Guardar Producto"}>
                    <Input label={"Imagen"} id={"image"}
                           name={"image"}  type = {"text"}/>
                    <Input label={"Nombre"} id={"name"}
                           name={"name"}  type = {"text"}/>
                    <Select options={options} label={"categoria"}
                            id={"category"} name={"category"} />
                    <Input label={"descripcion"} id={"descriptions"}
                           name={"descriptions"}  type = {"text"}/>
                    <Input label={"Valor"} id={"value"}
                           name={"value"}  type = {"text"}/>
                </Form>
            </LayoutUser>
        </>
    )
}
