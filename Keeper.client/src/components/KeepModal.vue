<template>
  <div class="active-keep-modal text-dark ">
    <div class="modal fade "
         id="activeKeepModal"
         tabindex="-1"
         aria-labelledby="exampleModalLabel"
         aria-hidden="true"
    >
      <div class="row">
        <div class="col-md-6">
          <img :src="activeKeep.img" alt="">
        </div>
        <div class="col-md-6">
          details
        </div>
      </div>
    </div>

    <!-- Modal -->
    <div class="modal fade"
         id="modelId"
         tabindex="-1"
         role="dialog"
         aria-labelledby="modelTitleId"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Modal title
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            Body
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">
              Close
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {

  name: 'Component',
  props: {
    // activeKeep: {
    //   type: Object,
    //   required: true
    // }
  },
  setup() {
    return {
      activeKeep: computed(() => AppState.activeKeep),
      keeps: computed(() => AppState.keeps)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
