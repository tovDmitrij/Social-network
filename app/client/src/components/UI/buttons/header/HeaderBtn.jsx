import React from 'react'
import classes from './HeaderBtn.module.css'


/**
 * Кнопка для хэдер-навбара
 * @param {*} children - текст или иной объект для кнопки
 */
const HeaderBtn = ({children, ...props}) => {
    return (
        <button className={classes.myBtn} {...props}>
            {children}
        </button>
    )
}


export default HeaderBtn