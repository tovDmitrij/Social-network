import React from 'react'
import styles from './ProfileImage.module.css'


/**
 * ��������, �������������� � ������� ������������
 * @param {*} avatar - �������� � ������� base64
 * @returns
 */
const ProfileImage = ({avatar}) => {
    return (
        <img className={styles.profileImg} src={`data:image/jpeg;base64,${avatar}`} />
    )
}


export default ProfileImage