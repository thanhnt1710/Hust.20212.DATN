<template>
  <div id="loading">
    <div class="loading-overlay"></div>
    <div class="loading-icon">
      <object :data="loaderUrl"></object>
    </div>
  </div>
</template>

<style lang="scss" scoped>
#loading {
  z-index: 1000;
  position: absolute;
  width: 100%;
  height: 100%;
  top: 0px;
  left: 0px;
  animation: fadeIn linear 0.2s;

  .loading-overlay {
    position: absolute;
    width: 100%;
    height: 100%;
    border-radius: 2px;
    background-color: rgba(0, 0, 0, 0.2);
  }

  .loading-icon {
    margin: 22% 50%;
  }
}
</style>

<script>
export default {
  name: "BaseLoading",
  data() {
    return {
        loaderUrl: require("@/assets/icons/loading.svg"),
    };
  },
  components: {},
  props: {},
  methods: {},
};
</script>