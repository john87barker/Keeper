<template>
  <div class="row pt-5 pl-0">
    <div class="col-md-3">
      <img class="rounded img ml-0" src="" alt="" />
    </div>
    <div class="col-md-9 text-left">
      <h1>{{ keep }}</h1>
      <h5>Vaults: profile persons amount</h5>
      <h5>Keeps: profile persons amount</h5>
    </div>
  </div>
</template>

<script>
// import { computed } from '@vue/runtime-core'
// import { AppState } from '../AppState'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {

    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
