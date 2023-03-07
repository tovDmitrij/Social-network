import React from 'react';
import { BrowserRouter } from "react-router-dom"
import { HeaderNavbar } from './components/UI/navbars/HeaderNavbar';
import { Body } from './components/Body';
import { FooterNavbar } from './components/UI/navbars/FooterNavbar';


export default function App() {
    return (
        <BrowserRouter>
            <div className='grid grid-rows-12 gap-3'>
                <HeaderNavbar />
                <Body />
                <FooterNavbar />
            </div>
        </BrowserRouter>
    );
}