import {React, useEffect } from 'react'


export const About = () => {
    useEffect(() => {
        document.title = 'О проекте'
    })

    return (
        <div>
            О проекте
        </div>
    )
}