import SignUpPage from '../pages/signUp/SignUpPage'
import SignInPage from '../pages/signIn/SignInPage'
import HelpPage from '../pages/help/HelpPage'
import ForeignProfilePage from '../pages/profile/foreign/ForeignProfilePage'
import DomesticProfilePage from '../pages/profile/domestic/DomesticProfilePage'
import ProfileSettingsPage from '../pages/settings/ProfileSettingsPage'


/**
 * Маршруты, доступные только авторизованным пользователям
 */
export const privateRoutes = [
    {path: '/profile', title: 'Мой профиль', element: DomesticProfilePage},
    {path: '/profile/settings', title: 'Редактировать профиль', element: ProfileSettingsPage},
    {path: '/profile/:id', title: 'Профиль', element: ForeignProfilePage},
    {path: '/help', title: 'Помощь', element: HelpPage}
]

/**
 * Маршруты, доступные неавторизованным пользователям
 */
export const publicRoutes = [
    {path: '/signUp', title: 'Регистрация', element: SignUpPage},
    {path: '/signIn', title: 'Войти', element: SignInPage},
    {path: '/help', title: 'Помощь', element: HelpPage}
]