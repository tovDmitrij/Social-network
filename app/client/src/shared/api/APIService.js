const url = 'https://localhost:7074'

class APIService {
    static async SignUp(email, password, surname, name){
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

    static async SignIn(email, password){
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
}

export default APIService