import { useState } from 'react'
import useFetching from '@/shared/hooks/useFetching'
import APIService from '@/shared/api/APIService'
import styles from './styles.module.scss'
import appLogo from '@/assets/app_logo.webp'

const SignUpForm = () => {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    const [surname, setSurname] = useState('')
    const [name, setName] = useState('')

    const [SignUp, isLoading, inputError] = useFetching(async () => {
        APIService.SignUp(email, password, surname, name).then(response => {
            response.json().then((data) => {
                console.log(data)
            })
        })
    })

    return (
        <>
            <div className={styles.signUpForm}>
                <form className='grid'>
                    <img src={appLogo} />
                    <h1>Регистрация</h1>
                    <input
                        placeholder="Введите почту"
                        onChange={e => setEmail(e.target.value)} />
                    <input
                        placeholder="Введите пароль"
                        onChange={e => setPassword(e.target.value)} />
                    <input
                        placeholder="Введите фамилию"
                        onChange={e => setSurname(e.target.value)} />
                    <input
                        placeholder="Введите имя"
                        onChange={e => setName(e.target.value)} />
                    <button 
                        type='button' 
                        onClick={SignUp}>Подтвердить</button>            
                </form>
            </div>
        </>
    )
}

export default SignUpForm