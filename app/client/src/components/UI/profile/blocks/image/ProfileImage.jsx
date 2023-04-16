import React from 'react'
import styles from './ProfileImage.module.css'


/**
 * ��������, �������������� � ������� ������������
 * @param {*} avatar - �������� � ������� base64
 * @returns
 */
const ProfileImage = ({avatar}) => {
    return (
        <div>
            {avatar !== null ?
                <img className={styles.profileImg} src={`data:image/jpeg;base64,${avatar}`} /> :
                <img className={styles.profileImg} src='/images/avatar.webp' />}
        </div>
    )
}


export default ProfileImage