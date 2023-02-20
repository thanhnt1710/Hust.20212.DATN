import Vue from "vue";
import courseAPI from "@/apis/views/courseAPI";

const state = {
  // Trạng thái form chi tiết khóa học
  formTypeCourseDetail: null,
  courseNew: {
    CourseID: null,
    CourseName: null,
    CourseDescription: null,
    Category: null,
    SubCategory: null,
    Chapters: [],
  },

  chapterNew: {
    ChapterID: null,
    ChapterName: null,
    CourseID: null,
    ChapterPrevID: null,
    Lessons: [],
  },

  lessonNew: {
    LessonID: null,
    LessonName: null,
    LessonPrevID: 0,
    ChapterID: null,
    CourseID: null,
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
