<template>
  <div data-target="#active-keep-modal" data-toggle="modal" class="a" @click.prevent="setActiveKeep(keep.id)">
    <img :src="keep.img" class="card-img  w-100 rounded " alt="">
    <div class="card-img-overlay ">
      <div>
        <h3 class="card-title d-flex justify-content-between align-text-bottom  words">
          {{ keep.name }}
        </h3>
      </div>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { router } from '../router'
import { keepsService } from '../services/KeepsService'
// import { computed, reactive } from '@vue/runtime-core'
// import { AppState } from '../AppState'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
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
  color: white;
  text-shadow:10px 10px 50px black;
}
</style>
