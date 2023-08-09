import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import useFetching from '@/shared/hooks/useFetching'
import APIService from '@/shared/api/APIService'
import styles from './styles.module.scss'
import AppLogo from '@/assets/app_logo.webp'
import Modal from '@/models/modals/error'

const SignInForm = () => {
    const navigate = useNavigate()

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')

    const [isOpen, setIsOpen] = useState(false)
    const [error, setError] = useState('')
    
    const [SignIn, isLoading, inputError] = useFetching(async () => {
        APIService.SignIn(email, password).then(response => {
            if (response.ok) {
                response.json().then((data) => {
                    localStorage['access_token'] = data
                    navigate('/profile')
                })
            }
            else {
                response.json().then((data) => {
                    openErrorModalWindow(data)
                })
            }
        })
    })

    const openErrorModalWindow = (textError) => {
        setError(textError)
        setIsOpen(true)
    }

    const ValidateData = () => {
        const emailRegex = /[A-Za-zА-Яа-я0-9]+@[A-Za-z]+\.[A-Za-z]+/g
        if (email.match(emailRegex) == null){
            openErrorModalWindow("Почта не валидная. Пример: ivanov@mail.ru")
            return false;
        }

        const passRegex = /[\S+]{8,16}/g
        if (password.match(passRegex) == null){
            openErrorModalWindow("Пароль не валидный. Разрешённые символы: буквы, цифры. Минимальная длина 8 символов")
            return false;
        }

        SignIn()
    }

    return(
        <>
            <div className={styles.signInForm}>
                <form className='grid'>
                    <img src={AppLogo} />
                    <h1>Авторизация</h1>
                    <input
                        placeholder="Введите почту"
                        onChange={e => setEmail(e.target.value)} />
                    <input
                        placeholder="Введите пароль"
                        onChange={e => setPassword(e.target.value)} />
                    <button 
                        type='button' 
                        onClick={ValidateData}>Подтвердить</button>            
                </form>
            </div>

            {isOpen && <Modal setIsOpen={setIsOpen} error={error} />}
        </>
    )
}

export default SignInForm