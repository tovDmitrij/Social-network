import React from 'react'
import { Link } from 'react-router-dom'
import Styles from './LeftMenuButton.module.css'


/**
 * Кнопка навигации для левого меню веб-приложения
 * @param direct - адрес
 * @param text - текст кнопки
 */
export const LeftMenuButton = ({direct, text}) => {
    return (
        <button className={Styles.leftBarButton}>
            <Link key={direct} to={direct}>{text}</Link>
        </button>
    )
}