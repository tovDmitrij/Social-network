import { Help } from "../pages/Help";
import { About } from "../pages/About";
import { SignIn } from "../pages/SignIn";
import { SignUp } from "../pages/SignUp"
import { UserProfile } from "../pages/UserProfile"


/**
 * Список публичных маршрутов
 */
export const publicRoutes = [
    {
        direct: "/help", 
        element: Help
    },
    {
        direct: "/about", 
        element: About
    },
    {
        direct: "/signIn",
        element: SignIn
    },
    {
        direct: "/signUp",
        element: SignUp
    },
    {
        direct: "/profile/:id",
        element: UserProfile
    }
]