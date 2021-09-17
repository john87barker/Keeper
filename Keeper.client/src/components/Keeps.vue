<template>
  <div data-target="#active-keep-modal" data-toggle="modal" @click.prevent="setActiveKeep(keep.id)">
    <img :src="keep.img" class="card-img  w-100 rounded shadow" alt="">
    <div class="card-img-overlay ">
      <div>
        <h3 class="card-title d-flex justify-content-between align-text-bottom text-dark words">
          {{ keep.name }}

          <div>
            <img :src="keep.creator.picture" class="rounded-pill pic action" alt="" @click.stop="goToProfile">
          </div>
        </h3>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { router } from '../router'
import { keepsService } from '../services/KeepsService'
export default {
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
      keeps: computed(() => AppState.keeps)
    })
    const route = useRoute()
    return {
      user: computed(() => AppState.user),
      state,
      route,
      account: computed(() => AppState.account),
      goToProfile() {
        // console.log(props.keep.creatorId)
        router.push({ name: 'Profile', params: { id: props.keep.creatorId } })
      },
      async setActiveKeep(id) {
        AppState.activeKeep = props.keep
        await keepsService.getKeepById(id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.pic{
  width: 3rem;
}
.words{
  text-shadow:1px 1px 15px white;
}
// .container{
//   display: grid;
//   grid-template-columns: 2fr, 1fr, 1fr;
//   gap: 10px;
// }

</style>
