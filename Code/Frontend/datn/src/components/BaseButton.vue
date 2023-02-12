<template>
  <div class="base-button" :class="classButton">
    <button
        type="button"
        @click="$emit('click')"
    >{{textBtn}}</button>
  </div>
</template>

<style lang="scss">
@import "@/scss/base/button.scss";
</style>

<script>

export default {
  name: "BaseButton",
  components: {
    
  },
  props: {
    classButton: {
      type: String,
      default: "",
    },
    textBtn: {
        type: String,
        default: "",
    }
  },
};
</script>