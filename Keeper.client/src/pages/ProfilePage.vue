<template>
  <div class=" text-center container">
    <ProfileComponent />
    <!-- VAULTS -->
    <div class="row pb-2">
      <div class="col-md-12 d-flex justify-content-between">
        <h2>
          My Keeps
        </h2>
        <button type="button" class="btn btn-outline-secondary ml-2">
          +
        </button>
      </div>
    </div>
    <div class="card-columns">
      <div class=" card" v-for="v in vaults" :key="v.id">
        <MyVaults :vault="v" />
      </div>
    </div>

    <!-- KEEPS -->
    <div class="row pb-2">
      <div class="col-md-12 d-flex justify-content-between">
        <h2>
          My Keeps
        </h2>
        <button type="button" class="btn btn-outline-secondary ml-2">
          +
        </button>
      </div>
    </div>
    <div class="card-columns">
      <div class=" card" v-for="k in keeps" :key="k.id">
        <MyKeeps :keep="k" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
import { useRoute } from 'vue-router'
import Pop from '../utils/Notifier'
export default {
  name: 'Profile',
  setup() {
    const route = useRoute()
    onMounted(async() => {
      try {
        await keepsService.getMyKeeps(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
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
