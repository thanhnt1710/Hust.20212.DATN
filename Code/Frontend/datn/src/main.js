import Vue from "vue";
import App from "./App.vue";
import router from "./routers/router";
import store from "./stores/base/store";

import "@/commons/globalComponent.js";
import enums from "@/commons/enums.js";
import config from "@/config/config.js";
import "@/scss/base/app.scss";

Vue.prototype.$app = { enums, config };

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
