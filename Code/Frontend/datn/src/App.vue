<template>
  <div id="app">
    <base-loading v-show="loading"></base-loading>
    <router-view></router-view>
  </div>
</template>

<style lang="scss">
</style>

<script>
import { mapState } from "vuex";
import BaseLoading from "@/components/BaseLoading.vue";

export default {
  name: "App",
  components: { BaseLoading },
  computed: {
    ...mapState({
      loading: (state) => state.loading,
    }),
  },
};
</script>
