import React from "react";
import classes from './Loader.module.css'


/**
 * Вспомогательный элемент, оповещающий пользователя о процессе загрузки чего-либо (крутилка)
 */
const Loader = () => {
    return(
        <div className={classes.loader}></div>
    )
}


export default Loader