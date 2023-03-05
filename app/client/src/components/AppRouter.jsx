import React                
    from 'react'
import { Navigate, Route, Routes } 
    from 'react-router-dom'
import Posts                
    from '../pages/Posts'
import About                
    from '../pages/About'
import UserProfile          
    from '../pages/UserProfile'
import UserProfileSettings  
    from '../pages/UserProfileSettings'
import Help                 
    from '../pages/Help'


/**
 * Элемент React с прописанными маршрутами
 */
export default function AppRouter () {
    return (
        <Routes>
            <Route 
                path='/posts' 
                element={<Posts />} />
            <Route 
                path='/about' 
                element={<About />} />
            <Route 
                path='/profile/:id' 
                element={<UserProfile />} />
            <Route 
                path='/profile/:id/settings' 
                element={<UserProfileSettings />} />
            <Route 
                path='/help' 
                element={<Help />} />
            {/* <Route
                path='/*'
                element={<Navigate to='/login' replace />} /> */}
        </Routes>
    )
}