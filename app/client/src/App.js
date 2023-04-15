import React, { useEffect, useState } from 'react'
import { BrowserRouter } from 'react-router-dom'
import AuthContext from './components/context/AuthContext'
import AppRouter from './components/AppRouter'
import HeaderNavbar from './components/UI/navbars/header/HeaderNavbar'
import FooterNavbar from './components/UI/navbars/footer/FooterNavbar'


function App() {
    const [isAuth, setIsAuth] = useState(false)
    const [isLoading, setLoading] = useState(true)

    useEffect(() => {
        if (sessionStorage.getItem('token') != null){
            setIsAuth(true)
        }
        setLoading(false)
    }, [])

    return (
         <AuthContext.Provider value={{isAuth, setIsAuth, isLoading}}>
            <BrowserRouter>
                <HeaderNavbar />
                <div className='grid place-items-center'>
                    <AppRouter />
                </div>
                <FooterNavbar />
            </BrowserRouter>
         </AuthContext.Provider>
    )
}


export default App;