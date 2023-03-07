import { React, useEffect } from 'react'
import { LogoImage } from '../components/UI/images/LogoImage'
import ImageSize from '../enums/ImageSize'


/**
 * Профиль пользователя
 * @param profileInfo - информация о пользователе
 */
export const UserProfile = ({profileInfo}) => {
    useEffect(() => {
        document.title = 'Профиль'
    })
    
    return (
        <div className='grid grid-cols-2 m-3'>

            <div>
                <LogoImage src='/images/avatar_user_default.webp' size={ImageSize.BIG} />
                <button>Написать</button>
                <button>Добавить в друзья</button>

                <div>
                    <h1>Друзья</h1>
                    ...
                </div>
            </div>

            <div>
                Фамилия информациями
            </div>

        </div>
    )
}