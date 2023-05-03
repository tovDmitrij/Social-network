import React from 'react'
import { Link } from 'react-router-dom'
import styles from './PrivateHeaderNavbar.module.css'
import MenuBtn from '../../../buttons/menu/MenuBtn'
import { privateRoutes } from '../../../../../router/Routes'


const PrivateHeaderNavbar = ({logOut}) => {
    return (
        <div className={`'grid grid-row-1 grid-cols-2 ${styles.navbar}`}>
            <img className={styles.navbar__logo} src='/images/logo.webp' />
            <div className={styles.navbar__links}>
                {/* {privateRoutes.map((route) => (
                    <Link key={route.path} className={styles.links} to={route.path}>{route.title}</Link>
                ))} */}
                <MenuBtn 
                    onClick={logOut}
                    children={"Выйти"}/>            
            </div>
        </div>
    )
}


export default PrivateHeaderNavbar