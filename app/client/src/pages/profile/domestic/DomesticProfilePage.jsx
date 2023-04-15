import React, { useContext, useEffect, useState } from 'react'
import { useFetching } from '../../../components/hooks/useFetching'
import { useNavigate } from 'react-router-dom'
import AuthContext from '../../../components/context/AuthContext'
import APIService from '../../../API/APIService'
import styles from './DomesticProfilePage.module.css'
import LeftNavbar from '../../../components/UI/navbars/leftbar/LeftNavbar'
import ProfileImage from '../../../components/UI/profile/blocks/image/ProfileImage'
import ProfileInfo from '../../../components/UI/profile/blocks/mainInfo/ProfileInfo'
import Loader from '../../../components/UI/loaders/Loader'
import ErrorPanel from '../../../components/UI/plates/error/ErrorPanel'
import MenuBtn from '../../../components/UI/buttons/menu/MenuBtn'


/**
 * Страница с профилем авторизованного пользователя в системе
 */
const ForeignProfilePage = () => {
    const navigate = useNavigate()
    const {isAuth, setIsAuth} = useContext(AuthContext)
    const [responseError, setError] = useState('')

    const [fullName, setFullname] = useState('')
    const [status, setStatus] = useState('')
    const [avatar, setAvatar] = useState('')
    const [birthDate, setBirthDate] = useState('')
    const [family, setFamily] = useState('')
    const [city, setCity] = useState('')

    /**
     * Получить базовую информацию о профиле пользователя
     */
    const [GetBaseInfo, isBaseLoading, error] = useFetching(async () => {
        APIService.GetAuthProfileBaseInfo().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    setFullname(data.data.surname + ' ' + data.data.name + ' ' + data.data.patronymic)
                    setStatus(data.data.status)
                    setAvatar(data.data.avatar)
                    setFamily(data.data.familyStatus)
                    setCity(data.data.city)

                    let date = new Date(data.data.birthDate)
                    setBirthDate(`${date.getDate()}/${date.getMonth()}/${date.getFullYear()}`)
                })
            }
            else if (response.status === 401){
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else{
                response.json().then((data) => {
                    setError(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    useEffect(() => {
        GetBaseInfo()
    }, [])

    return (
        <div className={`grid grid-cols-12 ${styles.myPage}`}>
            <div className='grid col-span-3'>
                <LeftNavbar />
            </div>

            <div className='grid col-span-6'>
                <div className='grid gap-3 grid-rows-6 grid-cols-3'>
                    <div className='grid col-span-1 row-span-3 place-items-center'>
                        {isBaseLoading ? 
                            <Loader /> : 
                            <ProfileImage avatar={avatar} /> }
                        {error && <ErrorPanel error={error} /> }
                        {responseError && <ErrorPanel error={responseError} /> }

                        <MenuBtn children='Редактировать профиль' />
                    </div>

                    <div className='col-span-2 row-span-3'>
                        {isBaseLoading ? 
                            <Loader /> :                         
                            <ProfileInfo 
                                fullName={fullName} 
                                status={status} 
                                family={family} 
                                birthDate={birthDate}
                                city={city} />}
                        {error && <ErrorPanel error={error} /> }
                        {responseError && <ErrorPanel error={responseError} /> }
                    </div>

                    <div className='col-span-1 row-span-2 bg-slate-50'>
                        Друзья
                    </div>

                    <div className='col-span-2 bg-slate-50'>
                        Новости
                    </div>
                </div>
            </div>

            <div className='grid col-span-3'></div>
        </div>
    )
}


export default ForeignProfilePage