import React from 'react'
import Styles from './LogoImage.module.css'
import ImageSize from '../../../enums/ImageSize'


/**
 * Логотип с регулируемыми параметрами
 * @param src - путь до изображения
 * @param size - размер изображения
 */
export const LogoImage = ({src, size}) => {
    switch(size){
        case ImageSize.SMALL:
            return (<img src={src} className={Styles.small} />)
        case ImageSize.MEDIUM:
            return (<img src={src} className={Styles.medium} />)
        case ImageSize.BIG:
            return (<img src={src} className={Styles.big} />)
        default:
            return (<img src={src} className={Styles.small} />)           
    }
}