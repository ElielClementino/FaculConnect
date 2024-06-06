import api from "./config.js"

export default {
    retrieveDisciplinesLessons: (disciplineId) => {
        return new Promise((resolve, reject) => {
            api.get(`lesson/${disciplineId}`)
            .then((response) => {
                return resolve(response.data)
            }).catch((error) => {
                return reject(error)
            })
        })
    }
}
