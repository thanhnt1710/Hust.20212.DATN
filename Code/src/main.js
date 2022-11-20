import { createApp } from "vue";
import axios from "axios";
import VueAxios from "vue-axios";
import App from "./App.vue";
import router from "./routers/router.js";
import store from "./stores/base/store.js";

const app = createApp(App);
app.use(store);
app.use(VueAxios, axios);
app.use(router);
app.config.productionTip = false;

app.mount('#app');
