import React from 'react'
import styles from './FooterNavbar.module.css'


/**
 * Навигационная панель для подвала
 */
const FooterNavbar = () => {
    return (
        <footer className={`grid place-items-center ${styles.footer}`}>
            <p className={styles.text}>2023, created by Dmitrij Kuzmin</p>
            <p className={styles.text}>Source: https://github.com/tovDmitrij/Social-network</p>
        </footer>
    )
}


export default FooterNavbar;