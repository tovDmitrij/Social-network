import styles from './styles.module.scss'

const ProfileAboutModel = ({title, text}) => {
    return (
        <div className={`${styles.model} grid grid-cols-2`}>
            <label>{title}</label>
            <label>{text}</label>
        </div>
    )
}

export default ProfileAboutModel