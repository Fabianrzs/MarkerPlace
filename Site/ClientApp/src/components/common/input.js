import React from 'react'
import {useFormContext} from "react-hook-form";

export default function Input(props) {
  const { type, label, id, name, defaultValue, onChange } = props
    const { register, setValue, getValues, formState: { errors, isDirty } } = useFormContext();
    return (
    <div className={"mb-3"}>
      <label htmlFor={id} className={"form-label"}>{label}</label>
      <input id={id} className={"form-control"} {...register(String(name))}
             type={type} name={name} defaultValue={defaultValue}
      />
      {errors[id] &&
          <span className="d-block text-left" >
            {"Llene el campo"}
          </span>
      }
    </div>
  )
}
