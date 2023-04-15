import React from 'react'
import { Link } from 'react-router-dom'
import { publicRoutes } from '../../../../../router/Routes'
import styles from './PublicHeaderNavbar.module.css'


const PublicHeaderNavbar = () => {
    return (
        <div className={`'grid grid-row-1 grid-cols-2 ${styles.navbar}`}>
            <img className={styles.navbar__logo} src='/images/logo.webp' />
            <div className={styles.navbar__links}>
                {publicRoutes.map((route) => (
                    <Link key={route.path} className={styles.links} to={route.path}>{route.title}</Link>
                ))}
            </div>
        </div>
    )
}


export default PublicHeaderNavbar