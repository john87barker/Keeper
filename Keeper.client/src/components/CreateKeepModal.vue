<template>
  <div class="create-keep-modal">
    <div class="modal fade" id="create-keep-modal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <form @submit.prevent="createKeep">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="exampleModalLabel">
                Create Keep
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
                v-model="state.rawKeep.name"
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
                v-model="state.rawKeep.description"
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
                v-model="state.rawKeep.img"
                placeholder="URL..."
                required
              >
              <div class="modal-footer">
                <button type="submit" class="btn btn-primary" data-toggle="modal" data-target="#createKeep">
                  Create Keep
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
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Notifier'
import $ from 'jquery'

export default {
  name: 'Component',
  setup() {
    const state = reactive({
      rawKeep: {}
    })
    return {
      state,
      async createKeep() {
        try {
          await keepsService.createKeep(state.rawKeep)
          state.rawKeep = {}
          Pop.toast('Keep Created', 'success')
          $('#create-keep-modal').modal('toggle')
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
