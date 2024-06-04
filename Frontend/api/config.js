import axios from "axios"

const api = axios.create({
  baseURL: "http://localhost:5173/",
  xsrfCookieName: "csrftoken",
  xsrfHeaderName: "X-CSRFToken",
  withCredentials: true,
  withXSRFToken: true,
})

export default api