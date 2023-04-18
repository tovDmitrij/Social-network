import React from 'react'
import styles from './ProfileInfo.module.css'
import ProfileItemLabel from '../../../labels/profile/ProfileItemLabel'
import ProfileCarrerPanel from '../../../plates/profile/carrer/ProfileCarrerPanel'
import ProfileMilitaryPanel from '../../../plates/profile/military/ProfileMilitaryPanel'


/**
 * Дополнительная информация о профиле пользователя
 * @param {*} family - Семейное положение
 * @param {*} birthDate - Дата рождения
 * @param {*} city - Родной город
 * @param {*} langs - Список языков
 */
const ProfileInfo = ({family, birthDate, city, langs, positions, carrers, militaries}) => {
    return (
        <div className={styles.profileBlock}>
            {family &&
                <div>
                    <label>Семейное положение: </label>
                    <ProfileItemLabel text={family} />
                </div>
            }

            {birthDate &&
                <div>
                    <label>День рождения: </label>
                    <ProfileItemLabel text={birthDate} />
                </div>
            }
            
            {city &&
                <div>
                    <label>Родной город: </label>
                    <ProfileItemLabel text={city} />
                </div>
            }

            {langs.length !== 0 && 
                <div>
                    <label>Языки: </label>
                    {langs.map((lang) => (
                        <label key={lang.languageName}>
                            <ProfileItemLabel text={lang.languageName} />
                        </label>
                    ))}
                </div>
            }

            {positions.length !== 0 &&
                <div className={styles.langs}>
                    <hr/>
                    <input id="langsTab" className={styles.langInput} type='checkbox' />
                    <label htmlFor="langsTab" className={styles.langLabel}>Жизненные позиции:</label>

                    <div className={styles.langItems}>
                        {positions.map((pos) => (
                            <div key={pos.positionID}>
                                <label>{pos.typeName} - </label>
                                <ProfileItemLabel text={pos.positionName} />
                            </div>
                        ))}
                    </div>  
                </div>
            }

            {carrers.length !== 0 &&
                <div className={styles.langs}>
                    <hr/>
                    <input id="carrersTab" className={styles.langInput} type='checkbox' />
                    <label htmlFor="carrersTab" className={styles.langLabel}>Карьера:</label>

                    <div className={`grid grid-cols-1 ${styles.langItems}`}>
                        {carrers.map((carrer) => (
                            <ProfileCarrerPanel key={carrer.id} carrer={carrer} />
                        ))}
                    </div>   
                </div>
            }

            {militaries.length !== 0 &&
                <div>
                    <hr/>
                    <input id="militariesTab" className={styles.langInput} type='checkbox' />
                    <label htmlFor="militariesTab" className={styles.langLabel}>Военная служба:</label>

                    <div className={`grid grid-cols-1 ${styles.langItems}`}>
                        {militaries.map((military) => (
                            <ProfileMilitaryPanel key={military.id} military={military} />
                        ))}
                    </div>
                </div>
            }
        </div>
    )
}


export default ProfileInfo