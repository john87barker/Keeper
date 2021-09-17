<template>
  <div data-target="#active-keep-modal" data-toggle="modal" class="a" @click.prevent="setActiveKeep(vk.id)">
    <img :src="vk.img" class="card-img  w-100 rounded" alt="">
    <div class="card-img-overlay">
      <div class="d-flex justify-content-between">
        <h3 class="card-title d-flex justify-content-between align-text-bottom words">
          {{ vk.name }}
        </h3>
        <div v-if="user.id == vk.creatorId">
          <button type="button" class="btn btn-outline-dark  " @click.stop="deleteVaultKeep(vk.vaultKeepId, vault.id)" title="remove from vault">
            X
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { router } from '../router'
import Pop from '../utils/Notifier'
import Swal from 'sweetalert2'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
export default {
  props: {
    vk: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),
      user: computed(() => AppState.account),
      profile: computed(() => AppState.profiles),
      async deleteVaultKeep(vkId, vId) {
        try {
          await Swal.fire({
            title: 'Are you sure you want to remove this keep from this vault?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085D6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
          }).then(async(result) => {
            if (result.isConfirmed) {
              await keepsService.deleteVaultKeep(vkId)
              await vaultsService.getKeepsByVault(vId)
              // router.push({ name: 'Home' })
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
      },
      async setActiveKeep(id) {
        AppState.activeKeep = props.vk
        await keepsService.getKeepById(id)
      }

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.words{
  color: white;
  text-shadow:10px 10px 50px black;
}
</style>
