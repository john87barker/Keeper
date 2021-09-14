<template>
  <div class="row masonry-items">
    <img :src="keeps.img" class="img py-2" alt="">
    <div class="card-img-overlay masonry-content">
      <!-- <h3 class="card-title">
        {{ keeps.name }}
      </h3> -->
    </div>
  </div>
</template>

<script>
export default {
  props: {
    keeps: {
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
.img{
  // height: 20rem;
  max-width: 20rem;
  object-fit: contain;
}
.words{
  text-shadow:1px 1px 15px black;
}
// .container{
//   display: grid;
//   grid-template-columns: 2fr, 1fr, 1fr;
//   gap: 10px;
// }
.masonry-wrapper {
  padding: 1.5em;
  max-width: 960px;
  margin-right: auto;
  margin-left: auto;
}
.masonry {
  columns: 1;
  column-gap: 10px;
}
.masonry-item {
  display: inline-block;
  vertical-align: top;
  margin-bottom: 10px;
}
@media only screen and (max-width: 1023px) and (min-width: 768px) {  .masonry {
    columns: 2;
  }
}
@media only screen and (min-width: 1024px) {
  .masonry {
    columns: 3;
  }
}
.masonry-item, .masonry-content {
  border-radius: 4px;
  overflow: hidden;
}
.masonry-item {
  filter: drop-shadow(0px 2px 2px rgba(0, 0, 0, .3));
  transition: filter .25s ease-in-out;
}
.masonry-item:hover {
  filter: drop-shadow(0px 5px 5px rgba(0, 0, 0, .3));
}
.masonry-content {
  overflow: hidden;
}
.masonry-item {
  color: #111111;
  background-color: #f9f9f9;
}
.masonry-title, .masonry-description {
  margin: 0;
}
.masonry-title {
  font-weight: 700;
  font-size: 1.1rem;
  padding: 1rem 1.5rem;
}
.masonry-description {
  padding: 1.5rem;
  font-size: .75rem;
  border-top: 1px solid rgba(0, 0, 0, .05);
}
.masonry-footer {
  font-size: .75em;
  opacity: .25;
  text-align: center;
  padding-top: 3em;
  padding-bottom: 3em;
  margin-bottom: -1.5em;
  transition: opacity 1s ease-in-out;
}
.masonry-footer a {
  color: currentColor;
}
.masonry-footer:hover, .masonry-footer:active, .masonry-footer:focus {
  opacity: .75;
}
</style>
