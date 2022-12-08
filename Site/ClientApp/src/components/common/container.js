import React from 'react'
import NavBar from '../NavBar/NavBar'
import '../../styles/children/Container.scss'

export default function Container({ children }) {
  return (
    <>
      <body>
        <header id="header">
          <NavBar/>
        </header>
        <nav id="nav">
          {children}
        </nav>
      </body>
    </>
  )
}
