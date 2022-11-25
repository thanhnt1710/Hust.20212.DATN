import Vue from "vue";

import BaseInput from "@/components/BaseInput.vue";
Vue.component(BaseInput.name, BaseInput);

import VTooltip from "v-tooltip";
Vue.use(VTooltip, {
  defaultHtml: false,
});


