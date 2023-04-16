/**
 * Адрес APIшки
 */
const url = 'https://localhost:7237/api/'


/**
 * Сервис, предоставляющий возможность отправлять запросы к API соцсети
 */
export default class APIService {
    /**
     * Подтверждение авторизации пользователя в системе
     * @param {*} user - почта и пароль
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
     * Получение базовой информации о профиле авторизованного пользователя
     */
    static async GetAuthProfileBaseInfo() {
        return await fetch(`${url}Profile/BaseInfo/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }

    /**
     * Получить список языков в профиле авторизованного пользователя
     */
    static async GetAuthProfileLanguageInfo() {
        return await fetch(`${url}Profile/Languages/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }

    /**
     * Получить список жизненных позиций авторизованного пользователя
     */
    static async GetAuthProfileLifePositionsInfo() {
        return await fetch(`${url}Profile/LifePositions/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }

    /**
     * Получить информацию о военной службе пользователя
     */
    static async GetAuthProfileMilitaryInfo() {
        return await fetch(`${url}Profile/Militaries/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        }) 
    }

    /**
     * Получить информацию о карьере пользователя
     */
    static async GetAuthProfileCarrerInfo() {
        return await fetch(`${url}Profile/Carrers/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }

    static async GetLanguageList(){
        return await fetch(`${url}Data/Languages/Get`, {
            method: "GET",
            headers: {
                "Content-type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }

    /**
     * Получение базовой информации о профиле пользователя
     * @param {*} user - идентификатор пользователя 
     * @returns response
     */
    static async GetProfileBaseInfo(user) {
        return await fetch(`${url}Profile/id=${user.id}/BaseInfo/Get`, {
            method: "GET",
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + localStorage.getItem('token')
            }
        })
    }
}