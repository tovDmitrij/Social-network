import React from 'react'
import styles from './ProfileItemLabel.module.css'

/**
 * Текстовое поле для профила
 * @param {*} text - текст
 */
const ProfileItemLabel = ({text}) => {
    return (
        <label className={styles.myLabel}>{text}</label>
    )
}


export default ProfileItemLabel