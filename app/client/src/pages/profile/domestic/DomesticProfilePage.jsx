import React, { useContext, useEffect, useState } from 'react'
import { useFetching } from '../../../components/hooks/useFetching'
import { Link, useNavigate } from 'react-router-dom'
import AuthContext from '../../../components/context/AuthContext'
import APIService from '../../../API/APIService'
import styles from './DomesticProfilePage.module.css'
import LeftNavbar from '../../../components/UI/navbars/leftbar/LeftNavbar'
import ProfileImage from '../../../components/UI/profile/blocks/image/ProfileImage'
import ProfileBaseInfo from '../../../components/UI/profile/blocks/baseInfo/ProfileBaseInfo'
import ProfileInfo from '../../../components/UI/profile/blocks/mainInfo/ProfileInfo'
import Loader from '../../../components/UI/loaders/Loader'
import ErrorPanel from '../../../components/UI/plates/error/ErrorPanel'
import MenuBtn from '../../../components/UI/buttons/menu/MenuBtn'


/**
 * Страница с профилем пользователя в системе
 */
const DomesticProfilePage = () => {
    const navigate = useNavigate()
    const {isAuth, setIsAuth} = useContext(AuthContext)
    const [responseError, setError] = useState('')

    const [fullName, setFullname] = useState('')
    const [status, setStatus] = useState('')
    const [avatar, setAvatar] = useState('')
    const [birthDate, setBirthDate] = useState('')
    const [family, setFamily] = useState('')
    const [city, setCity] = useState('')

    const [languages, setLang] = useState([])
    const [positions, setPos] = useState([])
    const [carrers, setCarrer] = useState([])
    const [militaries, setMilitary] = useState([])

    const [GetBaseInfo, isBaseLoading, baseError] = useFetching(async () => {
        APIService.GetAuthProfileBaseInfo().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    setFullname(data.data.surname + ' ' + data.data.name + ' ' + data.data.patronymic)
                    setStatus(data.data.status)
                    setAvatar(data.data.avatar)
                    setFamily(data.data.familyStatus)
                    setCity(data.data.city)

                    if (data.data.birthDate !== null){
                        let date = new Date(data.data.birthDate)
                        setBirthDate(`${date.getDate()}/${date.getMonth()}/${date.getFullYear()}`)
                    }
                })
            }
            else if (response.status === 401){
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else{
                response.json().then((data) => {
                    console.log(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetLanguageInfo, isLangLoading, langError] = useFetching(async () => {
        APIService.GetAuthProfileLanguageInfo().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    data.data.forEach((item) => {
                        languages.push(item)
                    })
                })
            }
            else if (response.status === 401){
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else{
                response.json().then((data) => {
                    console.log(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetPositionInfo, isPosLoading, posError] = useFetching(async () => {
        APIService.GetAuthProfileLifePositionsInfo().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    data.data.forEach((item) => {
                        positions.push(item)
                    })
                })
            }
            else if (response.status === 401){
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else{
                response.json().then((data) => {
                    console.log(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetCarrerInfo, isCarrerLoading, carrerError] = useFetching(async () => {
        APIService.GetAuthProfileCarrerInfo().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    data.data.forEach((item) => {
                        carrers.push(item)
                    })
                })
            }
            else if (response.status === 401){
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else{
                response.json().then((data) => {
                    console.log(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    const [GetMilitaryInfo, isMilitaryLoading, militaryError] = useFetching(async () => {
        APIService.GetAuthProfileMilitaryInfo().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    data.data.forEach((item) => {
                        militaries.push(item)
                    })
                })
            }
            else if (response.status === 401){
                setIsAuth(false)
                localStorage.clear()
                navigate("/signIn")
            }
            else{
                response.json().then((data) => {
                    console.log(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    useEffect(() => {
        GetBaseInfo()
        GetLanguageInfo()
        GetPositionInfo()
        GetCarrerInfo()
        GetMilitaryInfo()
    }, [])

    useEffect(() => {
        document.title = `${fullName}`
    }, [fullName])

    return (
        <div className={`grid grid-cols-12 ${styles.myPage}`}>
            <div className='grid col-span-3'>
                <LeftNavbar />
            </div>

            <div className='grid col-span-6'>
                <div className='grid gap-3 grid-rows-6 grid-cols-3'>

                    <div className='grid col-span-1 row-span-3'>
                        {isBaseLoading ? <Loader /> : <ProfileImage avatar={avatar} /> }
                        
                        <div className='grid place-items-center'>
                            <Link to='/profile/settings'>
                                <MenuBtn children='Редактировать профиль' />
                            </Link>
                        </div>
                    </div>

                    <div className='col-span-2 row-span-3'>
                        {isBaseLoading ? 
                            <Loader /> :                         
                            <ProfileBaseInfo 
                                fullName={fullName} 
                                status={status} />}
                        
                        {isBaseLoading ? <Loader /> :
                            isLangLoading ? <Loader /> :
                            isPosLoading ? <Loader /> :
                            isCarrerLoading ? <Loader /> :
                            isMilitaryLoading ? <Loader /> :
                            <ProfileInfo
                                family={family} 
                                birthDate={birthDate}
                                city={city}
                                langs={languages}
                                positions={positions}
                                carrers={carrers}
                                militaries={militaries} />
                        }

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


export default DomesticProfilePage