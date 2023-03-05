import React, { useState } 
    from 'react'
import { Link } 
    from 'react-router-dom'
import MyDropMenu 
    from '../myDropMenu/MyDropMenu'
import { MyImage } 
    from '../myImage/MyImage'
import { MySearchInput } 
    from '../mySearchInput/MySearchInput'
import ImageSize
    from '../../../enums/ImageSize'


export default function HeaderNavbar() {
    const [links, setLinks] = useState([
        {direct:"/profile/:id", text:"Перейти в профиль"},
        {direct:"/profile/:id/settings", text:"Настройки аккаунта"},
        {direct:"/help", text:"Помощь"}
    ])

    return (
        <div className='grid grid-cols-4'>
            {/* Перейти на главную страницу */}
            <div>
                <Link to="/posts">
                    <MyImage src='images/avatar_website.webp' size={ImageSize.SMALL} />
                    <p>Соцсеть "На Связи"</p>
                </Link>
            </div>

            {/* Поиск */}
            <div>
                <MySearchInput />
            </div>

            {/* Уведомления */}
            <div className='grid grid-cols-2 items-center gap-4'>
                <div className='grid '>
                    <MyImage src='images/notification_ringbell.webp' size={ImageSize.SMALL} />
                </div>
                <p>3</p>
            </div>

            {/* Профиль пользователя и выпадающий список */}
            <div className='grid grid-cols-2 items-center gap-4'>
                <div className='grid justify-items-end'>
                    <Link to="/profile/:id">
                        <MyImage src='images/avatar_user_default.webp' size={ImageSize.SMALL} />
                    </Link>
                </div>
                <div className='grid justify-items-start'>
                    <MyDropMenu text={'⋮'} links={links} />
                </div>
            </div>
        </div>
    )
}