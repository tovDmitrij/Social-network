import SignUpFormWidget from "@/widgets/forms/signUp/index"
import AppHeader from "@/widgets/header"
//import backgroundStyles from '@/shared/styles/backgrounds/animatedYellowEllipse/style.module.scss'
import styles from './styles.module.scss'

const SignUpPage = () => {
    return (
        //<div className={backgroundStyles.background}>
        <div>
            <AppHeader />
            <div className={styles.signUpForm}>
                <SignUpFormWidget />
            </div>
        </div>
    )
}

export default SignUpPage