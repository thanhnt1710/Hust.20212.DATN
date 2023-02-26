<template>
  <div id="main" class="main flex-column">
    <the-header></the-header>
    <div class="main-data flex-row">
      <the-nav-left></the-nav-left>
      <div class="content scroll flex-column flex-1">
        <router-view></router-view>
        <!-- <the-footer v-show="showFooter"></the-footer> -->
      </div>
      <evaluate :showEvaluate="showEvaluate"></evaluate>
    </div>
  </div>
</template>

<style lang="scss">
.main {
  .main-data {
    position: relative;
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
import { mapState, mapMutations, mapActions } from "vuex";
import TheHeader from "@/layouts/TheHeader.vue";
import TheFooter from "@/layouts/TheFooter.vue";
import TheNavLeft from "@/layouts/TheNavLeft.vue";
import Evaluate from "@/components/views/Evaluate.vue";

export default {
  name: "Main",
  components: { TheHeader, TheFooter, TheNavLeft, Evaluate },
  data() {
    return {
      moduleEvaluate: "module_evaluate",
    };
  },
  computed: {
    ...mapState({
      showEvaluate(state) {
        return state[this.moduleEvaluate].showEvaluate;
      },
    }),
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
