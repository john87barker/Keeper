<template>
  <img :src="keep.img" class="card-img  w-100 rounded" alt="">
  <div class="card-img-overlay ">
    <div>
      <h3 class="card-title d-flex justify-content-between align-text-bottom text-primary words">
        {{ keep.name }}

        <div>
          <img :src="keep.creator.picture" class="rounded-pill pic" alt="">
        </div>
      </h3>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    const state = reactive()
    return {
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.pic{
  width: 3rem;
}
</style>
