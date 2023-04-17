import React, { useContext, useEffect } from 'react'
import styles from './HelpPage.module.css'
import LeftNavbar from '../../components/UI/navbars/leftbar/LeftNavbar'
import AuthContext from '../../components/context/AuthContext'


/**
 * Страница-справочник-памятка для пользователя
 */
const HelpPage = () => {
    const {isAuth, setIsAuth} = useContext(AuthContext)

    useEffect(() => {
        document.title = "Справочник"
    }, [])

    return (
        <div className={`grid grid-cols-12 ${styles.myPage}`}>
            <div className='grid col-span-3'>
                {isAuth && <LeftNavbar />}
            </div>
            
            <div className='grid col-span-6'>
                ПОМОЩЬ ПО ПРИЛОЖУХЕ
            </div>

            <div className='grid col-span-3'></div>
        </div>
    )
}


export default HelpPage