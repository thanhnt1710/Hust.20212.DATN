<template>
  <div class="base-button" :class="classButton">
    <button class="button" type="button" @click="clickBtn">{{ textBtn }}</button>
  </div>
</template>

<style lang="scss">
@import "@/scss/base/button.scss";
</style>

<script>
export default {
  name: "BaseButton",
  components: {},
  props: {
    // btn-primary; btn-primary-outline
    classButton: {
      type: String,
      default: "",
    },
    textBtn: {
      type: String,
      default: "",
    },
  },
  methods: {
    clickBtn(e) {
      this.$emit("click", e);
    },
  },
};
</script>