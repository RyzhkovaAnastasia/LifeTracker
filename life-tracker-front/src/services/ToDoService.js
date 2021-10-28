import axios from 'axios'

export const createToDo = async (newToDo) => {
  const toDo = await axios.post('/ToDo', newToDo);
  return toDo;
}

export const deleteToDo = async (id) => {
  const toDo = await axios.delete(`/ToDo/${id}`);
}

export const updateToDo = async (toDo) => {
  const toDo = await axios.delete('/ToDo', toDo);
}

export const getToDo = async (id) => {
  const toDo = await axios.get(`/ToDo/${id}`);
}

export const getAllToDos = async (id) => {
  const toDo = await axios.get('/ToDo/GetAll');
}