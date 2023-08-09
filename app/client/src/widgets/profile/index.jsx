import { useEffect } from "react"
import { useState } from "react"
import { useNavigate } from "react-router-dom"
import useFetching from '@/shared/hooks/useFetching'
import APIService from "@/shared/api/APIService"

const ProfileWidget = () => {
    const navigate = useNavigate()
    const [profileInfo, setProfileInfo] = useState('')

    const [ProfileBaseInfo, isLoading, inputError] = useFetching(async () => {
        APIService.GetAuthProfileBaseInfo().then(response => {
            if (response.ok) {
                response.json().then((data) => {
                    setProfileInfo(data)
                })
            }
            else {
                navigate('/signIn')
            }
        })
    })

    useEffect(() => {
        ProfileBaseInfo()
    }, [])

    return (
        <div>
            {profileInfo.surname} {profileInfo.name}
        </div>
    )
}

export default ProfileWidget