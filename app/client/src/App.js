import React, { useState } from 'react';


export default function App() {
    const [info, setInfo] = useState('');

    async function getData() {
        try {
            fetch("account/SignUp")
                .then(response => response.json())
                .then(data => { console.log(data); });
        } catch (error) {
            console.error(error);
        }
    }

    return (
        <div>
            Hello World!
            <button onClick={getData}>Click Me!</button>
        </div>
    );
}