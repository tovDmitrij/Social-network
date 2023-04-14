import { useContext } from "react";
import AuthContext from "../../../context/AuthContext";
import PrivateHeaderNavbar from "./private/PrivateHeaderNavbar";
import PublicHeaderNavbar from "./public/PublicHeaderNavbar";


const HeaderNavbar = () => {
    const {isAuth, setIsAuth} = useContext(AuthContext)

    const LogOut = () => {
        setIsAuth(false)
        sessionStorage.removeItem('id')
        sessionStorage.removeItem('token')
    }

    return (
        isAuth ? <PrivateHeaderNavbar logOut={LogOut} /> : <PublicHeaderNavbar />
    )
}


export default HeaderNavbar;