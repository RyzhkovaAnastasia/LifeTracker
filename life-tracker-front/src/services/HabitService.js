import axios from 'axios'

export const createHabit = async (newHabit) => {
  const habit = await axios.post('/Habit', newHabit);
  return habit;
}

export const deleteHabit = async (id) => {
  const habit = await axios.delete(`/Habit/${id}`);
}

export const updateHabit = async (habit) => {
  const habit = await axios.delete('/Habit', habit);
}

export const getHabit = async (id) => {
  const habit = await axios.get(`/Habit/${id}`);
}

export const getAllHabits = async (id) => {
  const habit = await axios.get('/Habit/GetAll');
}