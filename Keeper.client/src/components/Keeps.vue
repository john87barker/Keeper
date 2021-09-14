<template>
  <img :src="keeps.img" class="card-img  w-100 rounded" alt="">
  <div class="card-img-overlay ">
    <div>
      <h3 class="card-title d-flex justify-content-between align-text-bottom text-primary words">
        {{ keeps.name }}
        <img :src="user.picture" class="rounded-pill pic" alt="">
      </h3>
    </div>
  </div>
</template>

<script>
import { computed } from '@vue/runtime-core'
import { AppState } from '../AppState'
export default {
  props: {
    keeps: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {
      user: computed(() => AppState.user)
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
  text-shadow:1px 1px 15px black;
}
// .container{
//   display: grid;
//   grid-template-columns: 2fr, 1fr, 1fr;
//   gap: 10px;
// }

</style>
