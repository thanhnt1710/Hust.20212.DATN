import Vue from "vue";
import evaluateAPI from "@/apis/views/evaluateAPI";

const state = {
  showEvaluate: false,
  infoCourse: {
    CourseID: null,
    CourseName: "",
  },
  evaluates: [],
};

const getters = {};

const mutations = {
  setShowEvaluate(state, value) {
    state.showEvaluate = value;
  },
  setInfoCourse(state, value) {
    state.infoCourse = value;
  },
  setEvaluates(state, value) {
    state.evaluates = value;
  },
};

const actions = {
  async getEvaluates({ commit }) {
    commit("setLoading", true);
    await evaluateAPI
      .getEvaluateByCourseID(state.infoCourse.CourseID)
      .then((res) => {
        if (res && res.data && res.data.Success) {
          commit("setEvaluates", res.data.Data);
        } else {
          Vue.$toast.error("Lấy dữ liệu đánh giá khóa học không thành công!");
        }
      })
      .catch((err) => {
        console.log(err);
        Vue.$toast.error("Lấy dữ liệu đánh giá khóa học không thành công!");
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
