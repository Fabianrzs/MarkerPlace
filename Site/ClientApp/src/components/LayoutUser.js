import Form from "./common/Form";
import Input from "./common/input";

export default function LayoutUser({children}){
    return(
        <div className={"container"}>
            <div className={"row justify-content-md-center"}>
                <div className="card p-5 mb-3" style={{width: "30rem"}}>
                    {children}
                </div>
            </div>
        </div>
    )
}
