import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import { useFetching } from '../../components/hooks/useFetching'
import APIService from '../../API/APIService'


const ProfilePage = () => {
    const params = useParams()
    //const [user, setUser] = useState({id: '', roleTitle: '', registrationDate: new Date(),surname: '', name: '', patronymic: ''})
    const [user, setUser] = useState('')
    const [responseError, setError] = useState('')

    const [GetBaseInfo, isBaseLoading, error] = useFetching(async(userInfo) => {
        APIService.GetProfileBaseInfo(userInfo).then(response => {
            if(response.ok){
                response.json().then((data) => {
                    console.log(data.data)
                    // setUser(data.data.surname)
                    //setUser(data.data)
                })
            }
            else{
                response.json().then((data) => {
                    setError(data.status)
                })
            }
        }).catch(err => { setError(err.status) })
    })

    useEffect(() =>{
        const user = {
            id: params.id
        }
        GetBaseInfo(user)
    }, [])

    return (
        <div>ProfilePage {user}</div>
    )
}


export default ProfilePage