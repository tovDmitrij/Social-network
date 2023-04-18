import React from 'react'
import styles from './SuccessPanel.module.css'


/**
 * Плашка, отображающая текст успешного фетча
 * @param {*} text - текст
 */
const SuccessPanel = ({text}) => {
    return (
        <div className={`grid place-items-center grid-cols-1 grid-rows-1 ${styles.main}`}>
            <h1 className={styles.header}><i className="fa-sharp fa-solid fa-circle-exclamation"></i> УСПЕШНО</h1>
            <p className={styles.body}>{text}</p>
        </div>
    )
}


export default SuccessPanel