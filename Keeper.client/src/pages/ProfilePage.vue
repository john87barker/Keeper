<template>
  <div class=" text-center container">
    <div class="row pt-5 pl-0 ">
      <div class="col-md-3 ">
        <img :src="profile.picture" class="rounded-pill pic action" alt="">
      </div>
      <div class="col-md-9 text-left pb-5 ">
        <!-- <h1>{{ keeps }}</h1> -->
        <h1>{{ profile.name }}</h1>
        <h1>{{ vault.title }}</h1>
        <h5>Vaults: {{ vLength }} </h5>
        <h5>Keeps: {{ kLength }} </h5>
      </div>
    </div>
    <!-- VAULTS -->

    <div class="row pb-3">
      <div class="col-md-12 d-flex justify-content-between">
        <h2>
          My Vaults
        </h2>
        <!-- FIXME v-if isn't right -->
        <div v-if="user.id == profile.id">
          <button type="button" class="btn btn-outline-secondary shadow" data-target="#create-vault-modal" data-toggle="modal">
            + New Vault
          </button>
        </div>
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
        <div v-if="user.id == profile.id">
          <button type="button" class="btn btn-outline-secondary ml-2" data-target="#create-keep-modal" data-toggle="modal">
            + New Keep
          </button>
        </div>
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
import { profilesService } from '../services/ProfilesService'
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
        await profilesService.getProfile(route.params.id)
        await keepsService.getMyKeeps(route.params.id)
        await vaultsService.getMyVaults(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      state,
      profile: computed(() => AppState.profiles),
      user: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
      vLength: computed(() => AppState.vaults.length),
      vault: computed(() => AppState.vaults),
      kLength: computed(() => AppState.keeps.length)
    }
  }
}
</script>

<style scoped>
img {
  width: 10rem;
}
</style>
