import axios from 'axios'

export const createTag = async (newTag) => {
  const tag = await axios.post('/Tag', newTag);
  return tag;
}

export const deleteTag = async (id) => {
  const tag = await axios.delete(`/Tag/${id}`);
}

export const updateTag = async (tag) => {
  const tag = await axios.delete('/Tag', tag);
}

export const getTag = async (id) => {
  const tag = await axios.get(`/Tag/${id}`);
}

export const getAllTags = async (id) => {
  const tag = await axios.get('/Tag/GetAll');
}