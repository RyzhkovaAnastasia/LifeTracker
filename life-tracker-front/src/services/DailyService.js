import axios from 'axios'

export const createDaily = async (newDaily) => {
  const daily = await axios.post('/Daily', newDaily);
  return daily;
}

export const deleteDaily = async (id) => {
  const daily = await axios.delete(`/Daily/${id}`);
}

export const updateDaily = async (daily) => {
  const daily = await axios.delete('/Daily', daily);
}

export const getDaily = async (id) => {
  const daily = await axios.get(`/Daily/${id}`);
}

export const getAllDailys = async (id) => {
  const daily = await axios.get('/Daily/GetAll');
}