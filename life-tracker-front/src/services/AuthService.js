import axios from 'axios'
import environment from '../settings'

axios.defaults.baseURL = environment.apiUrl;

export const registerUser = (newUser) => {
  return axios.post('/Account', newUser);
}

export const loginUser = (user) => {
  return axios.post('/Account/Login', user);
}

export const logoutUser = () => {
  return axios.post('/Account/Logout');
}