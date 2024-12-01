import axios from 'axios';
class AccountService {
  static baseUrl = "https://localhost:5212/api/";

  /**
   * user object {email, displayName, token}
   * token will persist (localstorage)-> retrieve user info
   * access user info in other places in app (to remove signin with the user name)
   */
  static async login(values) {
    const user = await axios.post(`${this.baseUrl}account/login`, values);
    localStorage.setItem('token', user.data.token);
    return user.data;
  }
  static async register(values) {
    const newuser = await axios.post(`${this.baseUrl}account/register`, values)
    localStorage.setItem('token', user.token)
    return newuser.data;
  }
  static async getUser() {
    const token = localStorage.getItem("token");

    if (!token) {
      return Promise.reject("Token not found");
    }
  
    // Create a new instance of axios with interceptors
    const axiosWithAuth = axios.create();
  
    // Add a request interceptor to set the Authorization header
    axiosWithAuth.interceptors.request.use(config => {
      config.headers.Authorization = `Bearer ${token}`;
      return config;
    }, error => {
      return Promise.reject(error);
    });
  
    try {
      const response = await axiosWithAuth.get(`${this.baseUrl}account`);
      return response.data; // Return the response data
    } catch (error) {
      console.error("Error fetching user data:", error);
      throw error;
    }
  }
  static logout() {
    localStorage.removeItem('token')
  }
  static async checkEmailExists(email) {
    const typedEmail = await axios.get(`${this.baseUrl}account/emailexists?email=` + email);
    return typedEmail;
  }
  static getUserAddress() {
    return axios.get(`${this.baseUrl}account/address`)
  }
  static updateUserAddress(data) {
    return axios.put(`${this.baseUrl}account/address`,data)
  }
}

export default AccountService;