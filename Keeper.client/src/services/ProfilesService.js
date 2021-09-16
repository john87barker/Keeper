import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
import { keepsService } from './KeepsService'
import { vaultsService } from './VaultsService'

class ProfilesService {
  async getProfile(id) {
    const res = await api.get(`api/profiles/${id}`)
    logger.log(res.data)
    AppState.profiles = res.data
    // keepsService.getMyVaults()
    // vaultsService.getMyVaults()
  }
}
export const profilesService = new ProfilesService()
