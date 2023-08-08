import SignUpForm from '@/widgets/signUpForm/index'
import AppHeader from "@/widgets/header"
import styles from '@/shared/styles/backgrounds/animatedYellowEllipse/style.module.scss'

const SignUpPage = () => {
    return (
        <div className={styles.background}>
            <AppHeader />
            <SignUpForm />
        </div>
    )
}

export default SignUpPage