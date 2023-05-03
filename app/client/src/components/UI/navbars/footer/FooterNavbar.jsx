import React from 'react'
import styles from './FooterNavbar.module.css'
import { Link } from 'react-router-dom'
import MenuBtn from '../../buttons/menu/MenuBtn'


/**
 * ������������� ������ ��� �������
 */
const FooterNavbar = () => {
    return (
        <footer className={`grid grid-cols-2 place-items-center ${styles.footer}`}>
            <div className='grid place-items-center'>
                <p className={styles.text}>2023, created by Dmitrij Kuzmin</p>
                <p className={styles.text}>Source: https://github.com/tovDmitrij/Social-network</p>
            </div>
            <div>
                <p className={styles.text}>
                    <Link to='/help'>
                        <MenuBtn
                            children={"Помощь"}/>
                    </Link>
                </p>
            </div>
        </footer>
    )
}


export default FooterNavbar;