<template>
  <div class="home flex-grow-1   container-fluid card-columns">
    <div class="py-2 card" v-for="k in keeps" :key="k.id">
      <Keeps :keep="k" />
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import Pop from '../utils/Notifier'
import { keepsService } from '../services/KeepsService'

export default {
  name: 'Home',
  setup() {
    onMounted(async() => {
      try {
        await keepsService.getAll()
      } catch (error) {
        Pop.toast(error, 'error')
      }
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
.container{
  display: inline-block;
  grid-template-columns: 2fr, 1fr, 1fr;
  gap: 10px;
}
body {
  background-color: #cccccc;
  color: #333333;
}

</style>
