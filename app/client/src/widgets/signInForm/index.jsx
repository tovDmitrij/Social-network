import { useState } from 'react'
import useFetching from '@/shared/hooks/useFetching'
import APIService from '@/shared/api/APIService'
import styles from './styles.module.scss'
import appLogo from '@/assets/app_logo.webp'

const SignInForm = () => {
    const [email, setEmail] = useState('')
    const [password, setPassword] = useState('')
    
    const [SignIn, isLoading, inputError] = useFetching(async () => {
        APIService.SignIn(email, password).then(response => {
            response.json().then((data) => {
                console.log(data)
            })
        })
    })

    return(
        <div className={styles.signInForm}>
            <form className='grid'>
                <img src={appLogo} />
                <h1>Авторизация</h1>
                <input
                    placeholder="Введите почту"
                    onChange={e => setEmail(e.target.value)} />
                <input
                    placeholder="Введите пароль"
                    onChange={e => setPassword(e.target.value)} />
                <button 
                    type='button' 
                    onClick={SignIn}>Подтвердить</button>            
            </form>
        </div>
    )
}

export default SignInForm