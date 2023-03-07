import React from 'react'
import { AppRouter } from './AppRouter';
import { LeftNavbar } from '../components/UI/navbars/LeftNavbar';


/**
 * Основная часть веб-приложения
 */
export const Body = () => {
    return (
        <div className='grid grid-cols-12 gap-3 grid-rows-10'>
            <LeftNavbar />
            <div className='bg-slate-300 col-start-3 col-span-8'>
                <AppRouter />
            </div>
        </div>    
    )
}