import SignUpPage from '../pages/signUp/SignUpPage'
import SignInPage from '../pages/signIn/SignInPage'
import HelpPage from '../pages/help/HelpPage'
import ProfilePage from '../pages/profile/ProfilePage'


/**
 * Маршруты, доступные только авторизованным пользователям
 */
export const privateRoutes = [
    {path: '/profile/:id',  title: 'Профиль',   element: ProfilePage},
    {path: '/help',         title: 'Помощь',    element: HelpPage}
]

/**
 * Маршруты, доступные неавторизованным пользователям
 */
export const publicRoutes = [
    {path: '/signUp',   title: 'Регистрация',   element: SignUpPage},
    {path: '/signIn',   title: 'Авторизация',   element: SignInPage},
    {path: '/help',     title: 'Помощь',        element: HelpPage}
]