import { useContext } from "react";
import AuthContext from "../../../context/AuthContext";
import PrivateHeaderNavbar from "./private/PrivateHeaderNavbar";
import PublicHeaderNavbar from "./public/PublicHeaderNavbar";


/**
 * Навигационная панель для хэдера
 */
const HeaderNavbar = () => {
    const {isAuth, setIsAuth} = useContext(AuthContext)

    const LogOut = () => {
        setIsAuth(false)
        localStorage.clear()
    }

    return(isAuth ? <PrivateHeaderNavbar logOut={LogOut} /> : <PublicHeaderNavbar />)
}


export default HeaderNavbar;