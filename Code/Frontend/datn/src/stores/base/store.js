import Vue from "vue";
import Vuex from "vuex";

// modules
import module_category from "@/stores/modules/module_category.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    loading: false,
  },
  getters: {},
  mutations: {
    setLoading(state, value) {
      state.loading = value;
    },
  },
  actions: {},
  modules: { module_category },
});
