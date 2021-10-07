import axios from 'axios'
import environment from '../settings'

axios.defaults.baseURL = environment.apiUrl;

const AUTH_TOKEN = 'auth-token';

export const getToken = () => {
  localStorage.getItem(AUTH_TOKEN);

}

export const setToken = token => {
  localStorage.setItem(AUTH_TOKEN, token);
  axios.defaults.headers.common['Accept'] = 'application/json';
  axios.defaults.headers.common['Authorization'] = 'Bearer ' + token;
}

export const deleteToken = () => {
  localStorage.removeItem(AUTH_TOKEN);
  axios.defaults.headers.common['Authorization'] = '';
  axios.defaults.headers.common['Accept'] = 'application/json';
}

export const registerUser = async (newUser) => {
  const token = await axios.post('/Account', newUser);
  return setToken(token['data']);
}

export const loginUser = async (user) => {
  const token = await axios.post('/Account/Login', user);
  return setToken(token['data']);
}

export const logoutUser = async () => {
  await axios.post('/Account/Logout');
  return deleteToken();
}