import api from "./config.js"

export default {
    login: (userInfo) => {
        return new Promise((resolve, reject) => {
            api.post("login", userInfo)
            .then((response) => {
                return resolve(response.data)
            }).catch((error) => {
                return reject(error)
            })
        })
    },
}