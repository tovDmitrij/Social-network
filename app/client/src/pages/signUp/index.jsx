import SignUpForm from '@/widgets/signUpForm/index'
import AppHeader from "@/widgets/header"
import styles from './styles.module.scss'

const SignUpPage = () => {
    return (
        <div className={styles.background}>
            <AppHeader />
            <SignUpForm />
        </div>
    )
}

export default SignUpPage