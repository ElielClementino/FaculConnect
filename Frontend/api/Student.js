export default {
    profile: (studentProfile) => {
        return new Promise((resolve, reject) => {
            api.post("student/create", studentProfile)
            .then((response) => {
                return resolve(response.data);
            }).catch((error) => {
                return reject(error);
            })
        })
    },
}