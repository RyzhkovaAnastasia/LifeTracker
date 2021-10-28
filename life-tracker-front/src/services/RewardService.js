import axios from 'axios'

export const createReward = async (newReward) => {
  const reward = await axios.post('/Reward', newReward);
  return reward;
}

export const deleteReward = async (id) => {
  const reward = await axios.delete(`/Reward/${id}`);
}

export const updateReward = async (reward) => {
  const reward = await axios.delete('/Reward', reward);
}

export const getReward = async (id) => {
  const reward = await axios.get(`/Reward/${id}`);
}

export const getAllRewards = async (id) => {
  const reward = await axios.get('/Reward/GetAll');
}