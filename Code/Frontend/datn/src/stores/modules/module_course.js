import Vue from "vue";
import courseAPI from "@/apis/views/courseAPI";

const state = {
  // Trạng thái form chi tiết khóa học
  formTypeCourseDetail: null,
  courseNew: {
    CourseID: null,
    CourseName: null,
    CategoryID: null,
    CategoryName: null,
    SubCategoryID: null,
    SubCategoryName: null,
    Chapters: [],
  },

  chapterNew: {
    ChapterID: null,
    ChapterName: null,
    ChapterParentID: null,
  },

  lessonNew: {
    LessonID: null,
    LessonName: null,
    LessonParentID: 0,
    FileID: null,
    VideoID: null,
    IsMixQuestion: true,
  },
};

const getters = {};

const mutations = {
  setFormTypeCD(state, type) {
    state.formTypeCourseDetail = type;
  },
};

const actions = {};

export default {
  state,
  getters,
  mutations,
  actions,
};
