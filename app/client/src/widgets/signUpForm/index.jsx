import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import useFetching from '@/shared/hooks/useFetching'
import APIService from '@/shared/api/APIService'
import styles from './styles.module.scss'
import appLogo from '@/assets/app_logo.webp'
import Modal from '@/models/modals/error'

const SignUpForm = () => {
    const navigate = useNavigate()

    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [repeatedPass, setRepeatedPass] = useState('')
    const [surname, setSurname] = useState('')
    const [name, setName] = useState('')

    const [isOpen, setIsOpen] = useState(false)
    const [error, setError] = useState('')

    const [SignUp, isLoading, inputError] = useFetching(async () => {
        APIService.SignUp(email, password, surname, name).then(response => {
            if (response.ok) {
                navigate('/signIn')
            }
            else {
                response.json().then((data) => {
                    openErrorModalWindow(data)
                })
            }
        })
    })

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
        if (repeatedPass.match(passRegex) == null){
            openErrorModalWindow("Пароль не валидный. Разрешённые символы: буквы, цифры. Минимальная длина 8 символов")
            return false;
        }
        if (password !== repeatedPass) {
            openErrorModalWindow("Пароли не совпадают")
            return false;
        }

        const fullnameRegex = /[А-Я]{1}[а-я]+ [А-Я]{1}[а-я]+/g
        const fullname = surname + ' ' + name
        if (fullname.match(fullnameRegex) == null) {
            openErrorModalWindow("ФИО не валидное. Пример: Иванов Иван")
            return false;
        }

        SignUp()
    }

    const openErrorModalWindow = (textError) => {
        setError(textError)
        setIsOpen(true)
    }

    return (
        <>
            <div className={styles.signUpForm}>
                <form className='grid'>
                    <img src={appLogo} />
                    <h1>Регистрация</h1>
                    <input
                        type='email'
                        placeholder="Введите почту"
                        onChange={e => setEmail(e.target.value)} />
                    <input
                        type='password'
                        placeholder="Введите пароль"
                        onChange={e => setPassword(e.target.value)} />
                    <input
                        type='password'
                        placeholder="Повторите пароль"
                        onChange={e => setRepeatedPass(e.target.value)} />
                    <input
                        placeholder="Введите фамилию"
                        onChange={e => setSurname(e.target.value)} />
                    <input
                        placeholder="Введите имя"
                        onChange={e => setName(e.target.value)} />
                    <button 
                        type='button' 
                        onClick={ValidateData}>Подтвердить</button>            
                </form>
            </div>

            {isOpen && <Modal setIsOpen={setIsOpen} error={error} />}
        </>
    )
}

export default SignUpForm