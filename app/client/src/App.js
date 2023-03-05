import React                
    from 'react';
import AppRouter            
    from './components/AppRouter';
import HeaderNavbar         
    from './components/UI/navbars/HeaderNavbar';
import { BrowserRouter }    
    from "react-router-dom"
import { LeftNavbar }   
    from './components/UI/navbars/LeftNavbar';
import { FooterNavbar } 
    from './components/UI/navbars/FooterNavbar';
import { RightNavbar } 
    from './components/UI/navbars/RightNavbar';


export default function App() {
    return (
        <BrowserRouter>
            <div className='grid grid-rows-3 grid-cols-1 gap-4'>
                <div className='bg-slate-100'>
                    <HeaderNavbar />
                </div>
                <div className='grid grid-cols-3 gap-3'>
                    <div className='bg-slate-200'>
                        <LeftNavbar />
                    </div>
                    <div className='bg-slate-300 col-span-2'>
                        <AppRouter />
                    </div>
                </div>
                <div className='bg-slate-400'>
                    <FooterNavbar />
                </div>
            </div>

        </BrowserRouter>
    );
}