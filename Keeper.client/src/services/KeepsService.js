import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')
    logger.log(res.data)
    AppState.keeps = res.data
  }

  async getMyKeeps(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    logger.log(res.data)
    AppState.keeps = res.data
  }

  async createKeep(rawKeep) {
    const res = await api.post('/api/keeps', rawKeep)
    logger.log(res.data)
    AppState.keeps.push(res.data)
  }

  async deleteKeep(id) {
    const res = await api.delete('api/keeps/' + id)
  }
}
export const keepsService = new KeepsService()
