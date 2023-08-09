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
            body: JSON.stringify(user)
        })
    }

    static async SignIn(email, password) {
        const user = {email, password}
        return await fetch(`${url}/api/v1/account/signIn`, {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)
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
            }
        })
    }
}

export default APIService