<template>
  <img :src="vault.img" class="card-img  w-100 rounded" alt="">
  <div class="card-img-overlay ">
    <div>
      <h3 class="card-title d-flex justify-content-between align-text-bottom text-primary words">
        {{ vault.name }}

        <div>
          <img :src="vault.creator.picture" class="rounded-pill pic" alt="">
        </div>
      </h3>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
