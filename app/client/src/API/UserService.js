import { API_URL } from '../setupProxy'


/**
 * Сервис получения информации о пользователе
 */
export default class UserService {
    /**
     * Получить информацию о пользователе
     * @param userID - идентификатор страницы пользователя
     * @returns информация о выбранном пользователе
     */
    static async GetUserProfileInfo(userID) {
        const response = await fetch(`${API_URL}/profile/${userID}`, {
            method: "GET",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            }
        })
        const data = await response.json()
        return data
    }
}