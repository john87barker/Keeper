<template>
  <div class="modal fade" id="active-keep-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg">
      <div class="modal-content">
        <div class="modal-body">
          <div class="row flex-grow-1">
            <div class="col-md-6">
              <img :src="aKeep.img" class="pic" alt="">
            </div>
            <div class="col-md-6">
              <div class="row ">
                <div class="col-md-12">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>
                <div class="col-md-12 text-center pb-3">
                  Views:{{ aKeep.views }}
                  Keeps: {{ aKeep.keeps }}
                </div>

                <h2 class="col-md-12 text-center pb-4">
                  {{ aKeep.name }}
                </h2>
                <div class="col-md-12 pl-5">
                  {{ aKeep.description }}
                </div>
                <div class="col-md-12 text-center py-5">
                  ____________________________
                </div>
              </div>
              <div class=" row d-flex justify-content-center pt-5 ">
                <!-- <p>{{ vaults }}</p> -->
                <select v-model="state.selectedVault"
                        :value="vaults.name"
                        @change="assignVault(aKeep.id, user.id)"
                >
                  <!-- <option selected="selected" value="Add to Vault">
                    Add to Vault
                  </option> -->
                  <option v-for="v in vaults" :value="v.id" :key="v.id" :vault="v">
                    {{ v.name }}
                  </option>
                </select>
                <!-- NOTE if time to make the selector pretty i want to use the bootstrap button below -->
                <!-- <div class="dropdown col-md-3 mr-3 pt-3">
                  <button class="btn btn-primary btn-sm dropdown-toggle"
                          type="button"
                          id="dropdownMenuButton"
                          data-toggle="dropdown"
                          aria-haspopup="true"
                          aria-expanded="false"
                  >
                    Add to a Vault
                  </button>
                  <div class="dropdown-menu" aria-labelledby="dropdownMenuButton" v-for="v in vaults" :key="v.id" :vault="v">
                    <a class="dropdown-item" href="#">{{ vaults.name }}</a>
                    <Dropdown :vault="v" />
              </div>
            </div> -->
                <div class="col-md-3 pt-3" v-if="aKeep.creatorId == user.id">
                  <img src="../assets/img/delete.png" alt="" @click="deleteKeep(aKeep.id)">
                </div>
                <router-link :to="{ name: 'Profile', params: { id: aKeep.creatorId } }">
                  <div class="col-md-3" @click="closeModal" v-if="aKeep.creator">
                    <img :src="aKeep.creator.picture" class="rounded img pr-2">
                  </div>
                </router-link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'
import $ from 'jquery'
import { vaultsService } from '../services/VaultsService'
import { router } from '../router'

export default {

  name: 'Component',
  props: {
    keep: {
      type: Object,
      required: true
    }
    // vaults: {
    //   type: Object,
    //   required: true
    // }
  },
  setup(props) {
    const state = reactive({
      selectedVault: '',
      newVK: {}
    })
    return {
      state,

      aKeep: computed(() => AppState.activeKeep),
      keeps: computed(() => AppState.keeps),
      user: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      async deleteKeep(keepid) {
        try {
          // debugger
          await keepsService.deleteKeep(keepid)
          Pop.toast('You have deleted this keep!', 'success')
          $('#active-keep-modal').modal('toggle')
          $('.modal-backdrop').remove()
        } catch (error) {
          Pop.toast(error, 'error')
        }
      },
      async assignVault(keepId, userId) {
        state.newVK.vaultId = state.selectedVault
        state.newVK.creatorId = userId
        state.newVK.keepId = keepId

        await vaultsService.createVK(state.newVK)
        Pop.toast('Successfully added to your vault!', 'success')
        state.selectedVault = ''
      },
      async closeModal() {
        $('#active-keep-modal').modal('toggle')
        $('.modal-backdrop').remove()
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.pic{
  width: 20rem;
  height: 30rem;
  object-fit:cover;
}
.img{
  width: 5rem;
  height: 5rem;
}
</style>
