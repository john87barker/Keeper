<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12">
        {{ vault }}
        <img src="../assets/img/delete.png" alt="">
      </div>
      <div class="card-columns">
        <div class="card" v-for="k in keeps" :key="k.id">
          <MyKeeps :keep="k" />
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
      keeps: computed(() => AppState.keeps)
    })
    onMounted(async() => {
      try {
        await vaultsService.getVaultKeeps(route.params.id)
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      state,
      vault: computed(() => AppState.vaults),
      vk: computed(() => AppState.keeps)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
