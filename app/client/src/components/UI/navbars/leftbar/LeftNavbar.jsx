import React from 'react'
import MenuBtn from '../../buttons/menu/MenuBtn'
import { Link } from 'react-router-dom'
import styles from './LeftNavbar.module.css'


const LeftNavbar = () => {
    return (
        <div className={`flex flex-col place-items-end ${styles.body}`}>
            <Link to='/profile'>
                <MenuBtn children={[<i key={1} className="fa-solid fa-user"></i>, ' Мой профиль']}/>
            </Link>

            <Link to='/news'>
                <MenuBtn children={[<i key={1} className="fa-solid fa-newspaper"></i>, ' Мои новости']}/>
            </Link>

            <Link to='/conversations'>
                <MenuBtn children={[<i key={1} className="fa-solid fa-envelope"></i>,' Мои сообщения']}/>
            </Link>

            <Link to='/friends'>
                <MenuBtn children={[<i key={1} className="fa-solid fa-user-group"></i>, ' Мои друзья']}/>
            </Link>

            <Link to='/groups'>
                <MenuBtn children={[<i key={1} className="fa-solid fa-people-group"></i>, ' Мои группы']}/>            
            </Link>
        </div>
    )
}


export default LeftNavbar