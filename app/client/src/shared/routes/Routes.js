import SignInPage from '@/pages/signIn/index.jsx'
import SignUpPage from '@/pages/signUp/index.jsx'
import ProfilePage from '@/pages/profile'

const ClientRoutes = [
    {path: '/signIn', element: SignInPage},
    {path: '/signUp', element: SignUpPage},
    {path: '/profile', element: ProfilePage}
]

export default ClientRoutes