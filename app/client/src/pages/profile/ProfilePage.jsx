import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'


const ProfilePage = () => {
    const params = useParams()
    const [user, setUser] = useState(0)

    useEffect(() =>{
        setUser(params.id)
    })

    return (
        <div>ProfilePage {user}</div>
    )
}


export default ProfilePage