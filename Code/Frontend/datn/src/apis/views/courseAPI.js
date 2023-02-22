import BaseAPI from "@/apis/base/baseAPI.js";

class CourseAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Course";
  }

  saveCourse(payload) {
    return this.postAxios(`${this.controller}/save-course`, payload);
  }

  removeCourse(id) {
    return this.postAxios(`${this.controller}/remove-course/${id}`);
  }

  getMaxID() {
    return this.getAxios(`${this.controller}/max-id`);
  }

  getCourseById(id) {
    return this.postAxios(`${this.controller}/get-course-by-courseid/${id}`);
  }

  getCourseByUserId(id) {
    return this.postAxios(`${this.controller}/get-course-by-userid/${id}`);
  }
}

export default new CourseAPI();
