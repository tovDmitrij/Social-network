import React from 'react'
import classes from './FormBtn.module.css'


/**
 * Кнопка для формы
 * @param {*} children - текст или иной объект для кнопки
 */
const FormBtn = ({children, ...props}) => {
    return (
        <button className={classes.myBtn} {...props}>
            {children}
        </button>
    )
}


export default FormBtn