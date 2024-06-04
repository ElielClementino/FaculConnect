import api from "./config.js"

export default {
    login: (User) => {
        return new Promise((resolve, reject) => {
            api.post("login", User)
            .then((response) => {
                return resolve(response.data);
            }).catch((error) => {
                return reject(error);
            })
        })
    },
    register: (User) => {
        return new Promise((resolve, reject) => {
            api.post("register", User)
            .then((response) => {
                return resolve(response.data);
            }). catch((error) => {
                return reject(error);
            })
        })
    }
}