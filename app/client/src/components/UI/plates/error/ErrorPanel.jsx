import React from 'react'
import styles from './ErrorPanel.module.css'


/**
 * Плашка, отображающая текст ошибки
 * @param {*} error - текст ошибки
 */
const ErrorPanel = ({error}) => {
    return (
        <div className={`grid place-items-center grid-cols-1 grid-rows-1 ${styles.main}`}>
            <h1 className={styles.header}>ОШИБКА</h1>
            <p className={styles.body}>{error}</p>
        </div>
    )
}


export default ErrorPanel