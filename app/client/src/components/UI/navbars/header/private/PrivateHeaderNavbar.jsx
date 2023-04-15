import React from 'react'
import { Link } from 'react-router-dom'
import styles from './PrivateHeaderNavbar.module.css'
import HeaderBtn from '../../../buttons/header/HeaderBtn'
import { privateRoutes } from '../../../../../router/Routes'


const PrivateHeaderNavbar = ({logOut}) => {
    return (
        <div className={styles.navbar}>
            <div className={styles.navbar__links}>
                {privateRoutes.map((route) => (
                    <Link key={route.path} className={styles.links} to={route.path}>{route.title}</Link>
                ))}
                <HeaderBtn 
                    className={styles.links} 
                    onClick={logOut}
                    children={"Выйти"}/>            
            </div>
        </div>
    )
}


export default PrivateHeaderNavbar