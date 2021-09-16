<template>
  <div>
    <img :src="vk.img" class="card-img  w-100 rounded" alt="">
    <div class="card-img-overlay ">
      <div>
        <h3 class="card-title d-flex justify-content-between align-text-bottom text-dark words">
          {{ vk.name }}
        </h3>
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { router } from '../router'
export default {
  props: {
    vk: {
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
.words{
  text-shadow:1px 1px 15px white;
}
</style>
