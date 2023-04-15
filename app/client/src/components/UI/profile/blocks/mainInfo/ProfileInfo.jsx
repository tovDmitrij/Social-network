import React from 'react'
import styles from './ProfileInfo.module.css'


/**
 * Базовая информация о профиле пользователя
 * @param {*} fullName - ФИО
 * @param {*} status - Статус пользователя
 * @param {*} family - Семейное положение
 * @param {*} birthDate - Дата рождения
 * @param {*} city - Родной город
 */
const ProfileInfo = ({fullName, status, family, birthDate}) => {
    return (
        <div className={styles.profileBlock}>
            <div className={styles.fullName}>{fullName}</div>
            <div>{status}</div>
            <hr/>
            <div>Семейное положение - {family}</div>
            <div>День рождения - {birthDate}</div>
            <div>Родной город - {city}</div>
        </div>
    )
}


export default ProfileInfo