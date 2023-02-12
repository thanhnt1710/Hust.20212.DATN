<template>
  <div id="main" class="main flex-column">
    <the-header></the-header>
    <div class="main-data flex-row">
      <the-nav-left></the-nav-left>
      <div class="content scroll flex-column flex-1">
        <router-view></router-view><the-footer v-show="showFooter"></the-footer>
      </div>
    </div>
  </div>
</template>

<style lang="scss">
.main {
  .main-data {
    .content {
      overflow: auto;
      height: calc(100vh - 66px);
      background: linear-gradient(
        191.1deg,
        rgba(255, 192, 67, 0) 14.17%,
        rgba(255, 192, 67, 0.28) 105.12%
      );
    }
  }
}
</style>

<script>
import TheHeader from "@/layouts/TheHeader.vue";
import TheFooter from "@/layouts/TheFooter.vue";
import TheNavLeft from "@/layouts/TheNavLeft.vue";

export default {
  name: "Main",
  components: { TheHeader, TheFooter, TheNavLeft },
  computed: {
    showFooter() {
      const me = this;

      return !(
        me.$route &&
        me.$route.name &&
        me.$app.config.ListNameHiddenFooter.includes(me.$route.name)
      );
    },
  },
};
</script>
