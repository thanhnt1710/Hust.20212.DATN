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
    Questions: [],
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
    FileName: "",
    VideoName: "",
  },
  //Loại form chi tiết khóa học: 1-thêm mới; 2-sửa
  formTypeCourseDetail: 1,
  currentCourseLearn: {},
  currentCourseDetail: {},

  paramGetCourse: {
    CategoryID: null,
    InputFilter: null,
    UserID: null,
  },
  // Danh sách khóa học
  courses: [],
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
  setParamGetCourse(state, value) {
    state.paramGetCourse = value;
  },
  setCourses(state, courses) {
    state.courses = courses;
  },
};

const actions = {};

export default {
  state,
  getters,
  mutations,
  actions,
};
