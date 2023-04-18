import React, { useEffect, useState } from 'react'
import styles from './ProfileSettingsPage.module.css'
import APIService from '../../API/APIService'
import {useFetching} from '../../components/hooks/useFetching'
import LeftNavbar from '../../components/UI/navbars/leftbar/LeftNavbar'
import Loader from '../../components/UI/loaders/Loader'
import SuccessPanel from '../../components/UI/plates/success/SuccessPanel'


const ProfileSettingsPage = () => {
    const [languages, setLang] = useState([])
    const [status, setStatus] = useState([])
    const [birthDate, setBirthDate] = useState(new Date())

    const [langID, setLangID] = useState(-1)
    const [profileLangID, setProfileLangID] = useState(-1)
    const [profileLangs, setProfLangs] = useState([])

    const [familyStatus, setFamily] = useState({'id': -1, 'name': ''})
    const [familyStatuses, setFamilyStatus] = useState([])

    const [profileCity, setProfileCity] = useState('')
    const [cityID, setCityID] = useState(-1)
    const [cities, setCities] = useState([])



    //#region ФЕТЧИ

    const [GetBaseInfo, isBaseLoading, baseError] = useFetching(async () => {
    APIService.GetAuthProfileBaseInfo().then(response => {
        if (response.ok){
            response.json().then((data) => {
                    setStatus(data.data.status)
                    const stat = {id: -1, name: data.data.familyStatus}
                    setFamily(stat)
                    
                    setProfileCity(data.data.city)
                    
                    if (data.data.birthDate !== null){
                        let date = new Date(data.data.birthDate)
                        setBirthDate(`${date.getFullYear()}-${date.getMonth()}-${date.getDate()}`)
                    }                
                })
            }
        })
    })

    const [GetLanguageInfo, isProfileLangLoading, profileLangError] = useFetching(async () => {
        APIService.GetAuthProfileLanguageInfo().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    data.data.forEach((item) => {
                        profileLangs.push(item)
                    })
                })
            }
            else{
                response.json().then((data) => {
                    console.log(data.status)
                })
            }
        })
    })
    
    const [GetLangs, isLangLoading, langError] = useFetching(async () => {
        APIService.GetLanguageList().then(response => {
            if (response.ok){
                response.json().then((data) => {
                    setLang(data.data)
                })
            }
        })
    })
    
    const [GetFamilyStatuses, isStatusLoading, familyStatusError] = useFetching(async () => {
        APIService.GetFamilyStatuses().then(response => {
            response.json().then((data) => {
                setFamilyStatus(data.data)
            })
        })
    })

    const [GetCities, isCitiesLoading, citiesError] = useFetching(async () => {
        APIService.GetCities().then(response => {
            response.json().then((data) => {
                setCities(data.data)
            })
        })
    })

    const [SetFamilyStatus, isFamilyLoading, newError] = useFetching(async () => {
        APIService.UpdateProfileFamilyStatus(familyStatus.id).then(response => {
            response.json().then((data) => {
                console.log(data.status)
            })
        })
    })
    
    const [SetStatus, isStatusUpdating, statusError] = useFetching(async () => {
        APIService.PutProfileStatus(status).then(response => {
            if (response.ok){
                response.json().then((data) => {
                    console.log(data.status)
                })
            }
        })
    })
    
    const [SetDate, isDateUpdating, dateError] = useFetching(async () => {
        APIService.PutProfileBirthdate(birthDate).then(response => {
            if (response.ok){
                response.json().then((data) => {
                    console.log(data.status)
                })
            }
        })
    })
    
    const [SetLang, isLangUpdating, addLangError] = useFetching(async () => {
        APIService.AddProfileLanguage(langID).then(response => {
            response.json().then((data) => {
                console.log(data.status)
            })
        })
    })
    
    const [DeleteLang, isLangDeleting, deleteLangError] = useFetching(async () => {
        APIService.DeleteProfileLanguage(profileLangID).then(response => {
            response.json().then((data) => {
                console.log(data.status)
            })
        })
    })
        
    const [SetCity, isCityLoading, cityError] = useFetching(async () => {
        APIService.UpdateProfileCity(cityID).then(response => {
            response.json().then((data) => {
                console.log(data.status)
            })
        })
    })
    
    //#endregion



    useEffect(() => {
        document.title = "Настройки профиля"
        GetBaseInfo()
        GetLanguageInfo()
        GetLangs()
        GetFamilyStatuses()
        GetCities()
    }, [])
    

    const SelectFamilyStatus = (value) => {
        const currentStatus = {
            id: value,
            name: ''
        }
        setFamily(currentStatus)
    }
    useEffect(() => {
        if (familyStatus.id !== -1){
            SetFamilyStatus()
        }
    }, [familyStatus])

    useEffect(() => {
        if (profileLangID !== -1){
            DeleteLang()
        }
    }, [profileLangID])

    useEffect(() => {
        if (langID !== -1) {
            SetLang()
        }
    }, [langID])

    useEffect(() => {
        if (cityID !== -1) {
            SetCity()
        }
    }, [cityID])

    return (
        <div className={`grid grid-cols-12 ${styles.myPage}`}>
            <div className='grid col-span-3'>
                <LeftNavbar />
            </div>

            <div className='grid col-span-6'>
                <div className={`grid ${styles.myPanel}`}>
                    <label className={styles.myLabel}>Статус</label>
                    {isBaseLoading ? <Loader /> : <input className={styles.myInput} type="text" onChange={e => setStatus(e.target.value)} defaultValue={status} />}
                    <button className={styles.myInput} onClick={SetStatus}>Подтвердить</button>
                    {}
                </div>

                <div className={`grid ${styles.myPanel}`}>
                    <label className={styles.myLabel}>Семейное положение</label>
                    <select
                        onChange={(e) => SelectFamilyStatus(e.target.value)}
                        className={styles.myInput}>
                        <option/>
                        {isStatusLoading ? <Loader /> : 
                            familyStatuses.map((status) => (
                                status.name === familyStatus.name ? 
                                <option selected key={status.id} value={status.id}>{status.name}</option> :
                                <option key={status.id} value={status.id}>{status.name}</option>
                            ))}
                    </select>
                </div>

                <div className={`grid ${styles.myPanel}`}>
                    <label className={styles.myLabel}>Дата рождения</label>
                    {isBaseLoading ? <Loader /> : <input className={styles.myInput} type="date" onChange={e => setBirthDate(e.target.value)} defaultValue={birthDate} />}
                    <button className={styles.myInput} onClick={SetDate}>Подтвердить</button>
                </div>

                <div className={`grid ${styles.myPanel}`}>
                    <label className={styles.myLabel}>Родной город</label>
                    <select
                        onChange={(e) => {setCityID(e.target.value)}}
                        className={styles.myInput}>
                        <option/>
                        {isCitiesLoading ? <Loader /> :
                            cities.map((city) => (
                                city.name === profileCity ?
                                <option selected key={city.id} value={city.id}>{city.name}</option> :
                                <option key={city.id} value={city.id}>{city.name}</option>
                            ))}
                    </select>
                </div>

                <div className={`grid ${styles.myPanel}`}>
                    <label className={styles.myLabel}>Удалить язык</label>
                    <select
                        onChange={(e) => {setProfileLangID(e.target.value)}}
                        className={styles.myInput}>
                        <option/>
                        {isProfileLangLoading ? <Loader /> :
                            profileLangs.map((lang) => (
                                <option key={lang.id} value={lang.languageID}>{lang.languageName}</option>
                            ))}
                    </select>

                    <hr/>

                    <label className={styles.myLabel}>Выбрать язык</label>
                    <select 
                        onChange={(e) => {setLangID(e.target.value);}}
                        className={styles.myInput}>
                        <option/>
                        {isLangLoading ? <Loader /> :
                            languages.map((lang) => (
                                <option key={lang.id} value={lang.id}>{lang.name}</option>
                            ))
                        }
                    </select>
                </div>
            </div>

            <div className='grid col-span-3'></div>
        </div>
    )
}


export default ProfileSettingsPage