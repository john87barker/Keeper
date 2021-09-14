<template>
  <div class="about text-center container-fluid">
    <div class="row pt-5">
      <div class="col-md-3">
        <img class="rounded img" :src="profile.picture" alt="" />
      </div>
      <div class="col-md-9 text-left">
        <h1>{{ profile.name }}</h1>
        <h5>Vaults: profile persons amount</h5>
        <h5>Keeps: profile persons amount</h5>
      </div>
    </div>
    <div class="row">
      <div class="col-md-12 d-flex ">
        <h3>
          Vaults
        </h3>
        <img src="" alt="">
      </div>
      <div class="col-md-12">
        Users Vaults
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Profile',
  setup() {
    return {
      profile: computed(() => AppState.account)
    }
  }
}
</script>

<style scoped>
img {
  width: 10rem;
}
</style>
