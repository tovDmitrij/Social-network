import React  from 'react'
import { Link }  from 'react-router-dom'
import { LinksDropMenu } from '../dropDownMenu/LinksDropMenu'
import { NotificationDropMenu } from '../dropDownMenu/NotificationDropMenu'
import { LogoImage } from '../images/LogoImage'
import { SearchInput }  from '../inputs/SearchInput'
import ImageSize from '../../../enums/ImageSize'

/**
 * Шапка веб-приложения с различной информациями и ссылками
 */
export const HeaderNavbar = () => {
    return (
        <div className='grid grid-cols-4 grid-rows-2 bg-slate-100'>


            {/* Перейти на главную страницу приложения*/}
            <div className='grid justify-items-center items-center'>
                <Link to="/posts">
                    <LogoImage src='/images/avatar_website.webp' size={ImageSize.SMALL} />
                </Link>
            </div>

            <SearchInput />

            <NotificationDropMenu posts={[]} />

            {/* Профиль пользователя и выпадающий список */}
            <div className='grid grid-cols-2 items-center'>
                <div className='grid justify-items-end'>
                    <Link to="/profile/:id">
                        <LogoImage src='/images/avatar_user_default.webp' size={ImageSize.SMALL} />
                    </Link>
                </div>
                <div className='grid justify-items-start'>
                    <LinksDropMenu />
                </div>
            </div>


        </div>
    )
}