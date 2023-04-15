import React from 'react'
import styles from './MenuBtn.module.css'


/**
 * Кнопка vty.
 * @param {*} children - текст или иной объект для кнопки
 */
const MenuBtn = ({children, ...props}) => {
    return (
        <button className={styles.myBtn} {...props}>
            {children}
        </button>
    )
}


export default MenuBtn