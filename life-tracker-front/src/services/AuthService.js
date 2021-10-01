import axios from 'axios'
import environment from '../settings'

axios.defaults.baseURL = environment.apiUrl;

function registerUser(newUser) {
    try {
      const response = axios.post('/Account', newUser);
      return JSON.parse(response.request.response);
    } catch (error) {
      console.error(error);
      return error;
    }
  }

function loginUser(user) {
    try {
      const response = axios.post('/Account', user);
      return JSON.parse(response.request.response);
    } catch (error) {
      console.error(error);
    }
}

function logoutUser(newUser) {
    try {
      const response = axios.post('/Account/Logout');
      return JSON.parse(response.request.response);
    } catch (error) {
      console.error(error);
    }
}

export default {
    registerUser,
    loginUser,
    logoutUser
};