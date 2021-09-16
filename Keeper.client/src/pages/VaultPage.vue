<template>
  <div class="container">
    <div class="row">
      <div class="col-md-12 d-flex">
        <h1 class="pr-3 pt-3">
          {{ vault.name }}
        </h1>

        <div class="pt-4" v-if="user.id == profile.id">
          <img src="../assets/img/delete.png" alt="" @click="deleteKeep(vault.id)">
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
import Swal from 'sweetalert2'
import { router } from '../router'
export default {
  name: 'Component',
  setup() {
    const route = useRoute()
    const state = reactive({
      vk: computed(() => AppState.vaultKeeps)
    })
    onMounted(async() => {
      try {
        await vaultsService.getKeepsByVault(route.params.id)
        await vaultsService.getVaultById(route.params.id)
      } catch (error) {
        router.push({ name: 'Home' })
      }
    })
    return {
      state,
      vault: computed(() => AppState.activeVault),
      vk: computed(() => AppState.vaultKeeps),
      vkLength: computed(() => AppState.vaultKeeps.length),
      user: computed(() => AppState.account),
      profile: computed(() => AppState.profiles),
      async deleteKeep(vaultId) {
        try {
          await Swal.fire({
            title: 'Are you sure you want to delete this Vault?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085D6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
          }).then(async(result) => {
            if (result.isConfirmed) {
              await vaultsService.deleteVault(vaultId)
              router.push({ name: 'Home' })
              Swal.fire(
                'You got it, dude!',
                'May you shelter in the palm of the Creator\'s hand, and may the last embrace of the mother welcome you home. -Shinaran Funeral Saying',
                'success'
              )
            }
          })
        } catch (error) {
          Pop.toast(error, 'error')
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
