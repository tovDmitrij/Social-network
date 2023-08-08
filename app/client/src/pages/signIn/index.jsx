import SignInForm from "@/widgets/signInForm/index"
import AppHeader from "@/widgets/header"
import styles from './styles.module.scss'

const SignInPage = () => {
    return (
        <div className={styles.background}>
            <AppHeader />
            <SignInForm />
        </div>
    )
}

export default SignInPage