<template>
  <div class="create-vault-modal">
    <div class="modal fade" id="create-vault-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <form @submit.prevent="createVault">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLabel">
                Create Vault
              </h5>
              <button type="button" class="btn-close btn btn-outline-danger" data-dismiss="modal" aria-label="Close" title="close">
                X
              </button>
            </div>
            <div class="modal-body">
              <label for="Title"> Title </label>
              <input
                title="Title"
                class="form-control"
                type="text"
                v-model="state.rawVault.name"
                id="name"
                placeholder="Title..."
                required
                minlength="4"
                maxlength="50"
              >
              <br>
              <label for="Description"> Description </label>
              <input
                title="Desc."
                class="form-control"
                type="text"
                v-model="state.rawVault.description"
                id="name"
                placeholder="description..."
                required
                minlength="4"
                maxlength="200"
              >
              <br>
              <label for="Image URL"> Image URL </label>
              <input
                name="Image URL"
                class="form-control"
                type="text"
                id="media"
                v-model="state.rawVault.img"
                placeholder="URL..."
                required
              >
              <div class="p-2">
                <input
                  for="Private?"
                  type="checkbox"
                  v-model="state.rawVault.isPrivate"
                  aria-label="Checkbox for following text input"
                >
                <label for="Private Vault?" class="pl-3"> Private Vault? </label>
              </div>
              <div class="modal-footer">
                <button type="submit" class="btn btn-primary" data-toggle="modal" data-target="#createVault">
                  Create Vault
                </button>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { vaultsService } from '../services/VaultsService'
import Pop from '../utils/Notifier'
import $ from 'jquery'

export default {
  name: 'Component',
  setup() {
    const state = reactive({
      rawVault: {}
    })
    return {
      state,
      async createVault() {
        try {
          await vaultsService.createVault(state.rawVault)
          state.rawVault = {}
          Pop.toast('Vault Created', 'success')
          $('#create-vault-modal').modal('toggle')
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
