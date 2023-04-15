/**
 * Адрес APIшки
 */
const url = 'https://localhost:7008/api/'

/**
 * Сервис, предоставляющий возможность отправлять запросы к API соцсети
 */
export default class APIService {
    /**
     * Подтверждение авторизации пользователя в системе
     * @param {*} user - почта и пароль
     * @returns response
     */
    static async SignInSubmit(user) {
        return await fetch(`${url}Auth/SignIn/email=${user.email}&password=${user.password}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        })
    }

    /**
     * Подтверждение регистрации пользователя в системе
     * @param {*} user - почта, пароль и ФИО
     * @returns response
     */
    static async SignUpSubmit(user) {
        return await fetch(`${url}Auth/SignUp/email=${user.email}&password=${user.password}&surname=${user.surname}&name=${user.name}&patronymic=${user.patronymic}`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            }
        })
    }

    /**
     * Получение базовой информации о профиле пользователя
     * @param {*} user - идентификатор пользователя 
     * @returns response
     */
    static async GetProfileBaseInfo(user) {
        return await fetch(`${url}Profile/userID=${user.id}/BaseInfo/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + sessionStorage.getItem('token')
            }
        })
    }
}