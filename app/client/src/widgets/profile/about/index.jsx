import { useState, useEffect } from 'react'
import styles from './styles.module.scss'
import ProfileManyModel from '@/models/profile/many'
import ProfileAboutModel from '@/models/profile/about'

const ProfileAboutWidget = () => {
    const [fullName, setFullName] = useState('')
    const [status, setStatus] = useState('')
    const [city, setCity] = useState('')
    const [familyStatus, setFamilyStatus] = useState('')
    const [birthDate, setBirthDate] = useState('')
    const [langs, setLangs] = useState([])

    useEffect(() => {
        setFullName('Ivanov Ivan')
        setStatus('Лучше уметь и не нуждаться, чем нуждаться и не уметь')
        setCity('Moscow')
        setFamilyStatus('Всё сложно')
        setBirthDate('25.10.1998')
        setLangs(['Русский', 'Английский', 'Немецкий'])
    }, [])

    return (
        <div className={`${styles.main} grid`}>
            <label>{fullName}</label>
            <label>{status}</label>

            <ProfileAboutModel title='Город:' text={city} />
            <ProfileAboutModel title='Семейный статус:' text={familyStatus} />
            <ProfileAboutModel title='Дата рождения:' text={birthDate} />

            <ProfileManyModel title='Языки:' values={langs} />
        </div>
    )   
}

export default ProfileAboutWidget