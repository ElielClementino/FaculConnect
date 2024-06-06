import api from "./config.js"

export default {
    retrieveCourseDisciplines: (courseId, semester) => {
        return new Promise((resolve, reject) => {
            api.get(`discipline/${courseId}/${semester}`)
            .then((response) => {
                return resolve(response.data)
            }).catch((error) => {
                return reject(error)
            })
        })
    }
}
