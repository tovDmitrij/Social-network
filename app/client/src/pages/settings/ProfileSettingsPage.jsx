import React, { useEffect, useState } from 'react'
import styles from './ProfileSettingsPage.module.css'
import APIService from '../../API/APIService'
import {useFetching} from '../../components/hooks/useFetching'

const ProfileSettingsPage = () => {

    const [languages, setLang] = useState([])

    const [GetLangs, isLangLoading, langError] = useFetching(async () => {
        APIService.GetLanguageList().then(response => {
            response.json().then((data) => {
                console.log(data.data)
            })
        })
    })

    useEffect(() => {
        GetLangs()
    }, [])

    return (
        <div className={`grid grid-cols-12 ${styles.myPage}`}>
            ProfileSettings
        </div>
    )
}


export default ProfileSettingsPage