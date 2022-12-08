import Button from "./button";
import {Link} from "react-router-dom";
import { FormProvider } from "react-hook-form";

export default function Form(props){
    const {formMethods, id, onSubmit, btnText, backLink, children, button, link} = props
    return(
        <FormProvider {...formMethods}>
            <form id={id}
                  onSubmit={formMethods.handleSubmit(onSubmit)}>
                {children}
                {<Button
                    type="submit"
                    text={btnText}
                    color={"primary"}
                />}
                {backLink && (
                    <div className="mt-2 back-link">
                        <Link href={link}>Atrás</Link>
                    </div>
                )}
            </form>
        </FormProvider>
    )
}
