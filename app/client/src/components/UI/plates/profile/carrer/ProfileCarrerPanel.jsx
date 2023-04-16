import React from 'react'
import styles from './ProfileCarrerPanel.module.css'


const ProfileCarrerPanel = ({carrer}) => {
    const ConvertDate = (currentDate) => {
        const date = new Date(currentDate)
        return `${date.getDate()}/${date.getMonth()}/${date.getFullYear()}`
    }

    return (
        <div className={`grid grid-cols-1 ${styles.myPanel}`}>
            {carrer.company !== "" &&
                <label>Компания - {carrer.company}</label>
            }

            {carrer.job !== "" &&
                <label>Должность - {carrer.job}</label>
            }
            
            {carrer.cityName !== "" &&
                <label>Город - {carrer.cityName}</label>
            }

            {carrer.dateFrom !== null &&
                <label>Начало карьеры - {ConvertDate(carrer.dateFrom)}</label>
            }
            
            {carrer.dateTo !== null &&
                <label>Окончание карьеры - {ConvertDate(carrer.dateTo)}</label>
            }
        </div>  
    )
}


export default ProfileCarrerPanel