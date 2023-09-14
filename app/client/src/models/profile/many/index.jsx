import styles from './styles.module.scss'

const ProfileManyModel = ({title, values}) => {
    return (
        <div className={`${styles.model} grid grid-cols-2`}>
            <label>{title}</label>
            <div className='flex'>
                {values.map(value => (
                    <label>{value}</label>
                ))}
            </div>
        </div>
    )
}

export default ProfileManyModel