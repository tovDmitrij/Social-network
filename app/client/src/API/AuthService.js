import { API_URL } from '../setupProxy'


/**
 * Сервис аутентификации пользователя в системе
 */
export default class AuthService {
    /**
     * Регистрация пользователя в системе
     * @param email - логин (почта)
     * @param password - пароль
     * @param surname - фамилия
     * @param name - имя
     * @returns true - регистрация прошла успешно; false - не успешно
     */
    static async SignUp(email, password, surname, name) {
        const response = await fetch(`${API_URL}/signUp`, {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                Login: email,
                Password: password,
                Surname: surname,
                Name: name
            })
        })
        const data = await response.json()
        if (response.ok === true) {
            sessionStorage.setItem("token", data.token)
        }
        else {
            console.error("Status: ", response.status, data.statusText)
            return false
        }
        return true
    }

    /**
     * Авторизация пользователя в системе
     * @param email - логин (почта)
     * @param password - пароль
     * @returns true - авторизация прошла успешно; false - не успешно
     */
    static async SignIn(email, password) {
        const response = await fetch(`${API_URL}/signIn`, {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                Login: email,
                Password: password
            })
        })
        const data = await response.json()
        if (response.ok === true) {
            sessionStorage.setItem("token", data.token)
        }
        else {
            console.error("Status: ", response.status, data.statusText)
            return false
        }
        return true
    }
}