import React, { useContext } from "react"
import { Route, Routes, Navigate } from "react-router-dom"
import AuthContext from './context/AuthContext'
import Loader from './UI/loaders/Loader'
import { privateRoutes, publicRoutes } from "../router/Routes"


/**
 * Настройка маршрутов приложения на основе сессии
 */
const AppRouter = () => {
    const {isAuth, setIsAuth, isLoading} = useContext(AuthContext)
    
    if (isLoading) { return <Loader /> }

    return (
        isAuth ?
        (<Routes>
            {privateRoutes.map(route =>
                <Route key={route.path} path={route.path} element={<route.element />} />
            )}
            <Route path="/*" element={<Navigate to='help' replace />} />
        </Routes>)
        :
        (<Routes>
            {publicRoutes.map(route =>
                <Route key={route.path} path={route.path} element={<route.element />} />
            )}
            <Route path="/*" element={<Navigate to='signIn' replace />} />
        </Routes>)
    )
}


export default AppRouter