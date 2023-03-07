import React from 'react'
import { Navigate, Route, Routes } from 'react-router-dom'
import { publicRoutes } from '../router/Routes'


/**
 * Элемент React с прописанными маршрутами
 */
export const AppRouter = () => {
    return (
        <Routes>
            {publicRoutes.map((route) =>
                <Route key={route.direct} path={route.direct} element={<route.element />} />
            )}
            <Route path='/*' element={<Navigate to='/login' replace />} />
        </Routes>
    )
}