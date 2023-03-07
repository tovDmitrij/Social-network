import { React, useState } from 'react'
import AuthService from '../API/AuthService'


/**
 * Страница с формой авторизации пользователя в системе
 */
export const SignIn = () => {
    const[login, setLogin] = useState('')
    const[password, setPassword] = useState('')

    const AuthSubmit = (event) => {
        event.preventDefault()
        if(AuthService.SignIn(login, password)){
            alert('Авторизация прошла успешно')
        }
        else{
            alert('Пользователь не найден')
        }
    }

    const UpdateLogin = (event) => {
        setLogin(event.target.value)
    }
    const UpdatePassword = (event) => {
        setPassword(event.target.value)
    }

    return (
        <div>
            <h1>Авторизация</h1>
            <form onSubmit={AuthSubmit}>
                <input onChange={UpdateLogin} type="text" placeholder='Введите логин' />
                <input onChange={UpdatePassword} type="text" placeholder='Введите пароль' />
                <button>Войти</button>
            </form>
        </div>
    )
}