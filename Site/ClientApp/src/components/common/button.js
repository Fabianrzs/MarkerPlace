import React from 'react'

export default function Button(props) {
  const {type, onSubmit, text, color} = props
  return (
    <button type="type" onSubmit={onSubmit} className={"btn btn-"+color}>{text}</button>
  )
}
