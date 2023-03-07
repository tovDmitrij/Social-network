import React from 'react'
import Styles from './LinksDropMenu.module.css'
import { Link } from 'react-router-dom'


/**
 * Выпадающий список ссылок на другие страницы для шапки веб-приложения
 */
export function LinksDropMenu() {
    return (
        <div className={Styles.dropdown}>

            <button className={Styles.dropbtn}>⋮</button>

            <div className={Styles.dropdown_content}>
                <Link to="/profile/:id">Профиль</Link>
                <Link to="/profile/:id/settings">Настройки аккаунта</Link>
                <Link to="/help">Помощь</Link>
            </div>

        </div> 
    )
}