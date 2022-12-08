import React from 'react'

export default function Loading() {
  return (
    <div className="d-flex vh-100 justify-content-center align-items-center">
      <div className="spinner-border text-primary">
        <span className="visually-hidden">Loading...</span>
      </div>
    </div>
  )
}
