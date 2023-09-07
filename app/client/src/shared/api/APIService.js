const url = 'https://localhost:7074'

class APIService {
    static async SignUp(email, password, surname, name) {
        const user = {email, password, surname, name}
        return await fetch(`${url}/api/v1/account/signUp`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            credentials: 'include',
            body: JSON.stringify(user)
        })
    }

    static async SignIn(email, password) {
        const user = {email, password}
        return await fetch(`${url}/api/v1/account/signIn`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            credentials: 'include',
            body: JSON.stringify(user)
        })
    }

    static async RefreshToken() {
        return await fetch(`${url}/api/v1/account/refresh`, {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            credentials: 'include'
        })
    }

    static async GetAuthProfileBaseInfo(){
        const accessToken = localStorage['access_token']
        return await fetch(`${url}/api/v1/profiles/auth/base`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + accessToken
            },
            credentials: 'include'
        })
    }
}

export default APIService