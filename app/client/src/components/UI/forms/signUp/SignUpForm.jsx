import React, {useState} from 'react'
import FormInput from '../../inputs/form/FormInput'
import FormBtn from '../../buttons/form/FormBtn'
import styles from './SignUpForm.module.css'

/**
 * Форма регистрации пользователя в системе
 * @param {*} accept - callback-функция для передачи данных
 * @param {*} error - callback-функция для передачи возможной ошибки
 */
const SignUpForm = ({accept, error}) => {
    const [surname, setSurname] = useState('')
    const [name, setName] = useState('')
    const [patronymic, setPatronymic] = useState('')
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [repeatedPass, setRepeatedPass] = useState('')

    /**
     * Подтверждение формы регистрации
     */
    const SignUp = (e) => {
        e.preventDefault()

        const wordRegex = /[А-Я][а-я]+/g
        if (surname.match(wordRegex) == null){
            error('Фамилия не валидная')
            return false;
        }
        if (name.match(wordRegex) == null){
            error('Имя не валидно')
            return false;
        }
        if (name.match(wordRegex) == null){
            error('Отчество не валидно')
            return false;
        }

        const emailRegex = /[A-Za-zА-Яа-я0-9]+@[A-Za-z]+.[A-Za-z]+/g
        if (email.match(emailRegex) == null){
            error("Почта не валидная")
            return false;
        }

        const passRegex = /[\S+]{8,16}/g
        if (password.match(passRegex) == null || repeatedPass.match(passRegex) == null){
            error("Пароль не валидный")
            return false;
        }
        if (password !== repeatedPass){
            error('Пароли не совпадают')
            return false;
        }

        const userInfo = {
            email: email,
            password: password,
            surname: surname,
            name: name,
            patronymic: patronymic
        }
        accept(userInfo)
    }

    return(
        <form className={`grid place-items-center gap-4 grid-cols-1 grid-rows-4 ${styles.myForm}`}>
            <h1 className={styles.myHeader}>Регистрация</h1>
            <FormInput
                type="text"
                onChange={e => setSurname(e.target.value)}
                placeholder='Введите фамилию'/>
            <FormInput
                type="text"
                onChange={e => setName(e.target.value)}
                placeholder='Введите имя'/>
            <FormInput
                type="text"
                onChange={e => setPatronymic(e.target.value)}
                placeholder='Введите отчество'/>
            <FormInput 
                type="email"
                onChange={e => setEmail(e.target.value)}
                placeholder='Введите логин'/>
            <FormInput
                type="password"
                onChange={e => setPassword(e.target.value)}
                placeholder='Введите пароль'/>
            <FormInput
                type="password"
                onChange={e => setRepeatedPass(e.target.value)}
                placeholder='Повторите пароль'/>
            <FormBtn 
                onClick={SignUp}
                children={"Подтвердить"}/>
        </form>
    )
}


export default SignUpForm