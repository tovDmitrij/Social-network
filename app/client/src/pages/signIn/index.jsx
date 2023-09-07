import SignInFormWidget from "@/widgets/forms/signIn/index"
import AppHeader from "@/widgets/header"
//import backgroundStyles from '@/shared/styles/backgrounds/animatedYellowEllipse/style.module.scss'
import styles from './styles.module.scss'

const SignInPage = () => {
    return (
        //<div className={backgroundStyles.background}>
        <div>
            <AppHeader />
            <div className={styles.signInForm}>
                <SignInFormWidget />
            </div>
        </div>
    )
}

export default SignInPage