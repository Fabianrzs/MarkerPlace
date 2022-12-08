import React from 'react';
import { Layout } from './components/Layout';
import './Styles/custom.css';
import {AuthProvider} from "./context/AuthContext";
import Router from "./routes/router";

export default function  App (){
    return (
      <Layout>
          <AppState>
              <Router/>
          </AppState>
      </Layout>
    );
}

const AppState = ({children}) => {
    return (
        <AuthProvider>
            {children}
        </AuthProvider>
    )
}
