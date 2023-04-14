import React, {useState} from 'react'
import FormInput from '../../inputs/form/FormInput'
import FormBtn from '../../buttons/form/FormBtn'
import styles from './SignInForm.module.css'


/**
 * Форма авторизации пользователя в системе
 * @param {*} accept - callback-функция для передачи данных
 * @param {*} error - callback-функция для передачи возможной ошибки
 */
const SignInForm = ({accept, error}) => {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    /**
     * Подтверждение формы авторизации
     */
    const SignIn = (e) => {
        e.preventDefault()

        const emailRegex = /[A-Za-zА-Яа-я0-9]+@[A-Za-z]+.[A-Za-z]+/g
        const emailMatch = email.match(emailRegex)
        if (emailMatch == null){
            error("Почта не валидная")
            return false;
        }

        const passRegex = /[\S+]{8,16}/g
        const passMatch = password.match(passRegex)
        if (passMatch == null){
            error("Пароль не валидный")
            return false;
        }

        const userInfo = {
            email: email,
            password: password
        }
        accept(userInfo)
    }

    return(
        <form className={`grid place-items-center gap-4 grid-cols-1 grid-rows-4 ${styles.myForm}`}>
            <h1 className={styles.myHeader}>Авторизация</h1>
            <FormInput 
                type="email"
                onChange={e => setEmail(e.target.value)}
                placeholder='Введите логин'/>
            <FormInput
                type="password"
                onChange={e => setPassword(e.target.value)}
                placeholder='Введите пароль'/>
            <FormBtn 
                onClick={SignIn}
                children={"Подтвердить"}/>
        </form>
    )
}


export default SignInForm