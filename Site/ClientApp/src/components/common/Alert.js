import React, { useEffect } from 'react'

export default function Alert(props) {

    const { color, message, time, setVisible } = props

    useEffect(() => {
        let timeMin = time ? (time*1000) : 2000
        setTimeout(() => { setVisible(false) }, timeMin)
    }, [])

    return (
        <div className={`alert alert-${color}`} role="alert">
            {message}
        </div>
    )
}
