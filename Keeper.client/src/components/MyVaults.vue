<template>
  <div @click="goToVault">
    <img :src="vault.img" class="card-img  w-100 rounded" alt="">
    <div class="card-img-overlay ">
      <div>
        <h3 class="card-title d-flex justify-content-between align-text-bottom text-dark words">
          {{ vault.name }}
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
    vault: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    return {
      goToVault() {
        router.push({ name: 'Vaults', params: { id: props.vault.id } })
        // console.log(props.vault)
      }
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
