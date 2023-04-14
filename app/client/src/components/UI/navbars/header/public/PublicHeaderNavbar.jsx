import React from 'react'
import { Link } from 'react-router-dom'
import styles from './PublicHeaderNavbar.module.css'
import { publicRoutes } from '../../../../../router/Routes'


const PublicHeaderNavbar = () => {
    return (
        <div className={styles.navbar}>
            <div className={styles.navbar__links}>
                {publicRoutes.map((route) => (
                    <Link key={route.path} className={styles.links} to={route.path}>{route.title}</Link>
                ))}
            </div>
        </div>    
    )
}


export default PublicHeaderNavbar