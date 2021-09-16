<template>
  <div class="component">
    <a class="dropdown-item" href="#">{{ vaults.name }}</a>
  </div>
</template>

<script>
export default {
  name: 'Component',
  props: {
    vaults: {
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
