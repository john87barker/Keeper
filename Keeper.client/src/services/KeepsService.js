import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { vaultsService } from './VaultsService'

class KeepsService {
  async getAll() {
    const res = await api.get('api/keeps')

    AppState.keeps = res.data
  }

  // NOTE many to many
  async getMyKeeps(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)

    AppState.keeps = res.data
  }

  async createKeep(rawKeep) {
    const res = await api.post('/api/keeps', rawKeep)
    logger.log(res.data)
    AppState.keeps.push(res.data)
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    this.getAll()
  }

  async deleteVaultKeep(id) {
    await api.delete('api/vaultkeeps/' + id)
    // vaultsService.getKeepsByVault()
  }
}
export const keepsService = new KeepsService()
