<template>
  <div class="modal fade" id="activeKeepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
                  Views and Keeps info
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
              <div class=" row d-flex justify-content-around pt-5 pl-1">
                <div class="col-md-3">
                  <button type="button" class="btn btn-outline-primary">
                    Add to Vault
                  </button>
                </div>
                <div class="col-md-3 pt-3">
                  <img src="../assets/img/delete.png" alt="" @click="deleteKeep(aKeep)">
                </div>
                <div class="col-md-3  mr-3" v-if="aKeep.creator">
                  <img :src="aKeep.creator.picture" class="rounded img pr-2" alt="">
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'
export default {

  name: 'Component',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      aKeep: computed(() => AppState.activeKeep),
      keeps: computed(() => AppState.keeps),
      user: computed(() => AppState.user),
      async deleteKeep(props) {
        try {
          await keepsService.deleteKeep(props.keep.id)
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
