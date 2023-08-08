import SignInForm from "@/widgets/signInForm/index"
import AppHeader from "@/widgets/header"
import styles from '@/shared/styles/backgrounds/animatedYellowEllipse/style.module.scss'

const SignInPage = () => {
    return (
        <div className={styles.background}>
            <AppHeader />
            <SignInForm />
        </div>
    )
}

export default SignInPage