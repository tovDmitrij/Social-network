import {React, useEffect } from 'react'


export const Help = () => {
    useEffect(() => {
        document.title = 'FAQ'
    })

    return (
        <div>
            Страница с памяткой для пользователя
        </div>
    )
}