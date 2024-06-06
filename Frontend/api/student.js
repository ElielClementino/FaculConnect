import api from "./config.js"

export default {
    register: (studentProfile) => {
        return new Promise((resolve, reject) => {
            api.post("student/create", studentProfile)
            .then((response) => {
                return resolve(response.data);
            }).catch((error) => {
                return reject(error);
            })
        })
    },
    update: (studentCourse) => {
        return new Promise((resolve, reject) => {
            api.put("student/update-course", studentCourse)
            .then((response) => {
                return resolve(response.data);
            }).catch((error) => {
                return reject(error);
            })
        })
    },
}
