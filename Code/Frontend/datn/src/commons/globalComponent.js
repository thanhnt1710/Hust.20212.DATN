import Vue from "vue";

import BaseInput from "@/components/BaseInput.vue";
import BaseCombobox from "@/components/BaseCombobox.vue";
import BaseButton from "@/components/BaseButton.vue";

Vue.component(BaseInput.name, BaseInput);
Vue.component(BaseCombobox.name, BaseCombobox);
Vue.component(BaseButton.name, BaseButton);

import VTooltip from "v-tooltip";
Vue.use(VTooltip, {
  defaultHtml: false,
});

import VueToast from 'vue-toast-notification';
import 'vue-toast-notification/dist/theme-sugar.css';
Vue.use(VueToast);