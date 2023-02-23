import Vue from "vue";
import categoryAPI from "@/apis/views/categoryAPI";

const state = {
  category: [],
  subCategory: [],
};

const getters = {};

const mutations = {
  setCategory(state, data) {
    let category = data;
    let subCategory = [];
    if (category && Array.isArray(category)) {
      category.map((item) => {
        if (item.SubCategories) {
          item.SubCategories = JSON.parse(item.SubCategories);
          subCategory = subCategory.concat(item.SubCategories);
        }
      });
    }
    state.category = category;

    state.subCategory = [
      ...new Map(
        subCategory.map((item) => [item["SubCategoryID"], item])
      ).values(),
    ];
  },
};

const actions = {
  async getCategory({ commit }) {
    commit("setLoading", true);
    await categoryAPI
      .getAllCategory()
      .then((res) => {
        commit("setCategory", res.data.Data);
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
