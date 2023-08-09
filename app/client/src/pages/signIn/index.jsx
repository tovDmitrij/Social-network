import SignInForm from "@/widgets/signInForm/index"
import AppHeader from "@/widgets/header"
import backgroundStyles from '@/shared/styles/backgrounds/animatedYellowEllipse/style.module.scss'
import styles from './styles.module.scss'

const SignInPage = () => {
    return (
        <div className={backgroundStyles.background}>
            <AppHeader />
            <div className={styles.signInForm}>
                <SignInForm />
            </div>
        </div>
    )
}

export default SignInPage