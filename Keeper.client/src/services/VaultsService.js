import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class VaultsService {
  async getMyVaults(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    // logger.log(res.data)
    AppState.vaults = res.data
  }

  async getVaultById(id) {
    const res = await api.get(`api/vaults/${id}`)
    // logger.log(res.data)
    AppState.activeVault = res.data
  }

  async getKeepsByVault(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    // logger.log(res.data)
    AppState.vaultKeeps = res.data
  }

  async createVault(rawVault) {
    const res = await api.post('/api/vaults', rawVault)
    logger.log(res.data)
    AppState.vaults.push(res.data)
  }
}
export const vaultsService = new VaultsService()
