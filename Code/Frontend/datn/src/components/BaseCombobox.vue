<template>
  <div class="base-combobox" :class="classCombobox">
    <multiselect
      v-model="data"
      :options="datas"
      :custom-label="displayFn"
      :allow-empty="allowEmpty"
      :placeholder="placeholder"
      deselect-label=""
      :label="label"
      :track-by="trackBy"
    ></multiselect>
  </div>
</template>

<style lang="scss">
@import "@/scss/base/combobox.scss";
</style>

<script>
import Multiselect from "vue-multiselect";
export default {
  name: "BaseCombobox",
  components: {
    Multiselect,
  },
  props: {
    classCombobox: {
      type: String,
      default: "",
    },
    placeholder: {
      type: String,
      default: "",
    },
    data: {
      type: [Number, String, Object],
      default: null,
    },
    // Dữ liệu combo
    datas: {
      type: Array,
      default: () => [],
    },
    // Cấu hình hiển thị
    displayFn: {
      type: Function,
      default: () => "",
    },
    allowEmpty: {
      type: Boolean,
      default: false,
    },
    label: {
      type: String,
      default: "",
    },
    trackBy: {
      type: String,
      default: "",
    },
  },
};
</script>