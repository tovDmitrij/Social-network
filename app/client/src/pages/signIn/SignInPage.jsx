import React, { useContext, useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { useFetching } from '../../components/hooks/useFetching'
import AuthContext from '../../components/context/AuthContext'
import Loader from '../../components/UI/loaders/Loader'
import ErrorPanel from '../../components/UI/plates/error/ErrorPanel'
import SignInForm from '../../components/UI/forms/signIn/SignInForm'
import APIService from '../../API/APIService'
import styles from './SignInPage.module.css'


/**
 * Страница для авторизации пользователя в системе
 */
const SignInPage = () => {
    const navigate = useNavigate();
    const {isAuth, setIsAuth} = useContext(AuthContext)
    const [responseError, setError] = useState('')

    /**
     * Авторизация пользователя в системе
     * @param {*} userInfo - почта и пароль пользователя
     */
    const [SignIn, isLoading, inputError] = useFetching(async (userInfo) => {
        APIService.SignInSubmit(userInfo).then(response => {
            if (response.ok){
                response.json().then((data) => {
                    setIsAuth(true)
                    localStorage.setItem('token', data.token) 
                    navigate("/news")             
                })
            }
            else{
                response.json().then((data) => {
                    setError(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    useEffect(() => {
        document.title = "Авторизация"
    }, [])

    return(
        <div className={`grid place-self-center place-items-center gap-4 grid-cols-1 grid-rows-1 ${styles.myPage}`}>
            <SignInForm accept={SignIn} error={setError} />

            {isLoading && <Loader /> }
            {inputError && <ErrorPanel error={inputError} /> }
            {responseError && <ErrorPanel error={responseError} /> }
        </div>
    )
}


export default SignInPage