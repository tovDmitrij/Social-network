import React, { useEffect, useState } from 'react'
import { BrowserRouter } from 'react-router-dom'
import AuthContext from './components/context/AuthContext'
import AppRouter from './components/AppRouter'
import HeaderNavbar from './components/UI/navbars/header/HeaderNavbar'
import FooterNavbar from './components/UI/navbars/footer/FooterNavbar'
import styles from './App.module.css'


function App() {
    const [isAuth, setIsAuth] = useState(false)
    const [isLoading, setLoading] = useState(true)

    useEffect(() => {
        if (localStorage.getItem('token') != null){
            setIsAuth(true)
        }
        setLoading(false)
    }, [])

    return (
         <AuthContext.Provider value={{isAuth, setIsAuth, isLoading}}>
            <BrowserRouter>
                <HeaderNavbar />
                <div className={`grid ${styles.main}`}>
                    <AppRouter />
                </div>
                <FooterNavbar />
            </BrowserRouter>
         </AuthContext.Provider>
    )
}


export default App;