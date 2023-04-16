import React from 'react'
import styles from './ProfileMilitaryPanel.module.css'


const ProfileMilitaryPanel = ({military}) => {
    const ConvertDate = (currentDate) => {
        const date = new Date(currentDate)
        return `${date.getDate()}/${date.getMonth()}/${date.getFullYear()}`
    }

    return (
        <div className={`grid grid-cols-1 ${styles.myPanel}`}>
            {military.countryName !== "" &&
                <label>Страна - {military.countryName}</label>
            }

            {military.militaryUnit !== "" &&
                <label>Часть - {military.militaryUnit}</label>
            }

            {military.dateFrom !== null &&
                <label>Дата начала - {ConvertDate(military.dateFrom)}</label>
            }

            {military.dateTo !== null &&
                <label>Дата окончания - {ConvertDate(military.dateTo)}</label>
            }        
        </div>  
    )
}


export default ProfileMilitaryPanel