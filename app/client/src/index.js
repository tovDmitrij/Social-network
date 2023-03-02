import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import MainMenu from './MainMenu';


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        <MainMenu />
        <App />
    </React.StrictMode>
);