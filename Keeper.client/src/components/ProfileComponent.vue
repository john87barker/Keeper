<template>
  <div class="row pt-5 pl-0 ">
    <div class="col-md-3 ">
      <img :src="profile.picture" class="rounded-pill pic action" alt="">
    </div>
    <div class="col-md-9 text-left pb-5 ">
      <!-- <h1>{{ keeps }}</h1> -->
      <h1>{{ profile.name }}</h1>
      <h1>{{ vault.title }}</h1>
      <h5>Vaults: {{ vaults }} </h5>
      <h5>Keeps: {{ keeps }} </h5>
    </div>
  </div>
</template>

<script>
import { reactive } from '@vue/reactivity'
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { profilesService } from '../services/ProfilesService'
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
    // onMounted(async() => {
    //   try {

    //   } catch (error) {
    //     Pop.toast(error, 'error')
    //   }
    // })
    // const state = reactive()
    return {
      user: computed(() => AppState.user)

      // profiles: computed(() => AppState.vaults)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
