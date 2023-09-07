import { useState, useEffect } from 'react'
import styles from './styles.module.scss'

const ProfileAboutModel = ({title, text}) => {
    return (
        <div className={`${styles.model} grid grid-cols-2`}>
            <label>{title}</label>
            <label>{text}</label>
        </div>
    )
}

const ProfileAboutModel2 = ({title, values}) => {
    return (
        <div className={`${styles.model} grid grid-cols-2`}>
            <label>{title}</label>
            <div className='flex'>
                {values.map(value => (
                    <label>{value}</label>
                ))}
            </div>
        </div>
    )
}



const ProfileAboutWidget = () => {
    const [fullName, setFullName] = useState('')
    const [status, setStatus] = useState('')
    const [city, setCity] = useState('')
    const [familyStatus, setFamilyStatus] = useState('')
    const [birthDate, setBirthDate] = useState('')
    const [langs, setLangs] = useState([])

    useEffect(() => {
        setFullName('Кузьмин Дмитрий')
        setStatus('Лучше уметь и не нуждаться, чем нуждаться и не уметь')
        setCity('Дубна')
        setFamilyStatus('Всё сложно')
        setBirthDate('25.11.2001')
        setLangs(['Русский', 'Английский', 'Немецкий'])
    }, [])

    return (
        <div className={`${styles.main} grid`}>
            <label>{fullName}</label>
            <label>{status}</label>

            <ProfileAboutModel title='Город:' text={city} />
            <ProfileAboutModel title='Семейный статус:' text={familyStatus} />
            <ProfileAboutModel title='Дата рождения:' text={birthDate} />

            <ProfileAboutModel2 title='Языки:' values={langs} />
        </div>
    )   
}

export default ProfileAboutWidget