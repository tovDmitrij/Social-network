import React, { useState } from 'react'
import { useFetching } from '../../components/hooks/useFetching'
import { useNavigate } from 'react-router-dom'
import Loader from '../../components/UI/loaders/Loader'
import ErrorPanel from '../../components/UI/plates/error/ErrorPanel'
import styles from './SignUpPage.module.css'
import SignUpForm from '../../components/UI/forms/signUp/SignUpForm'
import APIService from '../../API/APIService'


/**
 * Страница для регистрации пользователя в системе
 */
const SignUpPage = () => {
    const navigate = useNavigate();
    const [responseError, setError] = useState('')

    /**
     * Регистрация пользователя в системе 
     * @param {*} userInfo - почта и пароль пользователя
     */
    const [SignUp, isLoading, error] = useFetching(async (userInfo) => {
        APIService.SignUpSubmit(userInfo).then(response => {
            if(response.ok){
                navigate("/signIn")
            }
            else{
                response.json().then((data) => {
                    setError(data.status)
                })
        }
        }).catch(err => { setError(err.status) })
    })

    return(
        <div className={`grid place-self-center place-items-center gap-4 grid-cols-1 grid-rows-1 ${styles.myPage}`}>
            <SignUpForm accept={SignUp} error={setError} />
            {isLoading && <Loader /> }
            {error && <ErrorPanel error={error} /> }
            {responseError && <ErrorPanel error={responseError} /> }
        </div>
    )
}


export default SignUpPage