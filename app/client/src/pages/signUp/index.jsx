import SignUpForm from '@/widgets/signUpForm/index'
import AppHeader from "@/widgets/header"
import backgroundStyles from '@/shared/styles/backgrounds/animatedYellowEllipse/style.module.scss'
import styles from './styles.module.scss'

const SignUpPage = () => {
    return (
        <div className={backgroundStyles.background}>
            <AppHeader />
            <div className={styles.signUpForm}>
                <SignUpForm />
            </div>
        </div>
    )
}

export default SignUpPage