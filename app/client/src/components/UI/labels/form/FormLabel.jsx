import React from 'react'
import styles from './FormLabel.module.css'


/**
 * Лэйбл
 * @param {*} title - текст лэйбла
 */
const FormLabel = ({ title, ...props }) => {
    return (
        <label className={styles.myLbl} {...props}>{title}</label>
    )
}


export default FormLabel