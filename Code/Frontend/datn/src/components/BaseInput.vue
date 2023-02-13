<template>
  <div :class="classInput" class="base-input flex-row-between">
    <div
      v-if="iconLeft"
      class="icon-left flex-center"
      :class="iconLeft.className"
    >
      <i class="fa-sharp fa-solid fa-magnifying-glass"></i>
    </div>
    <input
      v-model="modelValue"
      type="text"
      class="input"
      :maxlength="maxlength"
      :placeholder="placeholder"
      @focus="$emit('focusInput')"
      @blur="$emit('blurInput')"
      @input="actionInput"
      @keyup.enter="$emit('enterInput')"
    />
    <div
      v-if="iconRight"
      class="icon-right flex-center"
      :class="classRight.className"
    ></div>
  </div>
</template>

<style lang="scss">
@import "@/scss/base/input.scss";
</style>

<script>
export default {
  name: "BaseInput",
  components: {},
  props: {
    modelValue: {
      type: String,
      default: null,
    },
    classInput: {
      type: String,
      default: "",
    },
    maxlength: {
      type: Number,
      default: 255,
    },
    placeholder: {
      type: String,
      default: "",
    },
    // {class: className}
    iconLeft: {
      type: Object,
      default: null,
    },
    iconRight: {
      type: Object,
      default: null,
    },
  },
  emits: ['update:modelValue'],
  methods: {
    actionInput(e) {
      this.$emit('input', e.target.value)
    }
  },
};
</script>