import React 
    from 'react'
import Styles 
    from './MyDropMenu.module.css'
import { Link } 
    from 'react-router-dom'


/**
 * Выпадающий список ссылок на другие страницы
 * @param text - текст оглавления;
 * @param links - список ссылок.
 */
export default function MyDropMenu({text, links}) {
    return (
        <div className={Styles.dropdown}>
            <button className={Styles.dropbtn}>{text}</button>
            <div className={Styles.dropdown_content}>
                {links.map((link) => 
                    <Link key={link.direct} to={link.direct}>{link.text}</Link>            
                )}
            </div>
        </div> 
    )
}