import api from "./config.js"

export default {
    listCourses: () => {
        return new Promise((resolve, reject) => {
            api.get("course/list")
            .then((response) => {
                return resolve(response.data)
            }).catch((error) => {
                return reject(error)
            })
        })
    }
}
