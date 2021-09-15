<template>
  <div class="row pt-5 pl-0 ">
    <div class="col-md-3 ">
      <img :src="profiles.picture" class="rounded-pill pic action" alt="">
    </div>
    <div class="col-md-9 text-left pb-5 ">
      <!-- <h1>{{ keeps }}</h1> -->
      <h1>{{ user.name }}</h1>
      <h5>Vaults: {{ vaults }} </h5>
      <h5>Keeps: {{ keeps }} </h5>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
// import { computed } from '@vue/runtime-core'
// import { AppState } from '../AppState'
export default {
  props: {
    profile: {
      type: Object,
      required: true
    }
  },
  setup() {
    // const state = reactive()
    return {
      user: computed(() => AppState.user),
      vaults: computed(() => AppState.vaults.length),
      vault: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps.length),
      profiles: computed(() => AppState.profiles)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
