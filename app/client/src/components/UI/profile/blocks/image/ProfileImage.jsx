import React from 'react'
import styles from './ProfileImage.module.css'


const ProfileImage = ({avatar}) => {
    return (
        <img className={styles.profileImg} src={`data:image/jpeg;base64,${avatar}`} />
    )
}


export default ProfileImage