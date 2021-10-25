import axios from 'axios'

export const createTag = async (newTag) => {
  const tag = await axios.post('/Tag', newTag);
  return tag;
}

export const deleteTag = async (id) => {
  const userWithToken = await axios.delete('/Tag', id);
}