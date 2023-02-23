import Vue from "vue";

const state = {
  questionNew: {
    QuestionID: null,
    QuestionStr: null,
    CourseID: null,
    Answers: [
      {
        Question: null,
        Answer: 1,
      },
      {
        Question: null,
        Answer: 2,
      },
      {
        Question: null,
        Answer: 3,
      },
      {
        Question: null,
        Answer: 4,
      },
    ],
    QuestionResult: null,
  },
};

const getters = {};

const mutations = {};

const actions = {};

export default {
  state,
  getters,
  mutations,
  actions,
};
