<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12 d-flex">
        <h1 class="pr-3 pt-3">
          {{ vault.name }}
        </h1>
        <div class="pt-4">
          <img src="../assets/img/delete.png" alt="">
        </div>
      </div>
      <div class="col-md-12">
        <h5>
          Keeps: {{ vkLength }}
        </h5>
      </div>
      <div class="card-columns">
        <!-- {{ vk }} -->
        <div class="card" v-for="v in vk" :key="v.id">
          <MyVaultKeeps :vk="v" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { vaultsService } from '../services/VaultsService'
import { useRoute } from 'vue-router'
export default {
  name: 'Component',
  setup() {
    const route = useRoute()
    const state = reactive({
      vk: computed(() => AppState.vaultKeeps)
    })
    onMounted(async() => {
      try {
        await vaultsService.getVaultById(route.params.id)
        await vaultsService.getKeepsByVault(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      state,
      vault: computed(() => AppState.activeVault),
      vk: computed(() => AppState.vaultKeeps),
      vkLength: computed(() => AppState.vaultKeeps.length)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
