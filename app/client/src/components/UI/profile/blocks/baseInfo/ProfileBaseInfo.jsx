import React from 'react'
import styles from './ProfileBaseInfo.module.css'


/**
 * Базовая информация о профиле пользователя
 * @param {*} fullName - ФИО
 * @param {*} status - Статус пользователя
 */
const ProfileBaseInfo = ({fullName, status}) => {
    return (
        <div className={styles.profileBlock}>
            <div className={styles.fullName}>{fullName}</div>
            <div>{status}</div>
        </div>
    )
}


export default ProfileBaseInfo