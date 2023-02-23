import Vue from "vue";
import courseAPI from "@/apis/views/courseAPI";

const state = {
  courseNew: {
    CourseID: null,
    CourseName: null,
    CourseDescription: null,
    Category: null,
    SubCategory: null,
    Chapters: [],
    Questions: []
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
  //Loại form chi tiết khóa học: 1-thêm mới; 2-sửa
  formTypeCourseDetail: 1,
  currentCourseLearn: {},
  currentCourseDetail: {},
};

const getters = {};

const mutations = {
  setFormTypeCourseDetail(state, type) {
    state.formTypeCourseDetail = type;
  },
  setCurrentCourseLearn(state, course) {
    state.currentCourseLearn = course;
  },
  setCurrentCourseDetail(state, course) {
    state.currentCourseDetail = course;
  },
};

const actions = {};

export default {
  state,
  getters,
  mutations,
  actions,
};
