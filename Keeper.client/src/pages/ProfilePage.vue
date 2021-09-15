<template>
  <div class=" text-center container">
    <ProfileComponent />
    <!-- VAULTS -->
    <div class="row pb-3">
      <div class="col-md-12 d-flex justify-content-between">
        <h2>
          My Vaults
        </h2>
        <button type="button" class="btn btn-outline-secondary shadow" data-target="#create-vault-modal" data-toggle="modal">
          + New Vault
        </button>
      </div>
    </div>
    <div class="card-columns">
      <div class=" card" v-for="v in vaults" :key="v.id">
        <MyVaults :vault="v" />
      </div>
    </div>

    <!-- KEEPS -->
    <div class="row pb-3">
      <div class="col-md-12 d-flex justify-content-between">
        <h2>
          My Keeps
        </h2>

        <button type="button" class="btn btn-outline-secondary ml-2" data-target="#create-keep-modal" data-toggle="modal">
          + New Keep
        </button>
      </div>
    </div>
    <div class="card-columns">
      <div class=" card" v-for="k in keeps" :key="k.id">
        <MyKeeps :keep="k" />
      </div>
    </div>
  </div>
  <CreateKeepModal />
  <CreateVaultModal />
</template>

<script>
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
import Pop from '../utils/Notifier'
export default {
  name: 'Profile',
  setup() {
    const route = useRoute()
    const state = reactive({
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)
    })
    onMounted(async() => {
      try {
        await keepsService.getMyKeeps(route.params.id)
        await vaultsService.getMyVaults(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      state,
      profile: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults)

    }
  }
}
</script>

<style scoped>
img {
  width: 10rem;
}
</style>
