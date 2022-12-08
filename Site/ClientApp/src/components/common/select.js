import React from 'react'
import {useFormContext} from "react-hook-form";

export default function Select(props) {

    const { type, label, id, name, defaultValue, onChange, options } = props
    const { register, setValue, getValues, formState:
        { errors, isDirty } } = useFormContext();

  const optionsHtml = options.map((option, key) => {
    return (
      <option key={key} value={option.id} >{option.name}</option>
    )
  }
  )
  return (
    <div className={"mb-3"}>
        <label htmlFor={id} className={"form-label"}>{label}</label>
        <select className="form-select" id={id} name={id} {...register(String(name))}
              defaultValue={defaultValue}>
        {optionsHtml}
      </select>
    </div>
  )
}
