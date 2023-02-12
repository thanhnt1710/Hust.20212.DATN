import Vue from "vue";
import categoryAPI from "@/apis/views/categoryAPI";

const state = {
  navbarCategory: null,
};

const getters = {};

const mutations = {
  setNavbarCategory(state, data) {
    state.navbarCategory = data;
  },
};

const actions = {
  async getNavbarCategory({ commit }) {
    commit("setLoading", true);
    await categoryAPI
      .getAllCategory()
      .then((res) => {
        commit("setNavbarCategory", res.data.Data);
        Vue.$toast.success("Oke!");
      })
      .catch((err) => {
        console.log(err);
      })
      .finally(() => {
        commit("setLoading", false);
      });
  },
};

export default {
  state,
  getters,
  mutations,
  actions,
};
