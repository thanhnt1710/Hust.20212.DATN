import BaseAPI from "@/apis/base/baseAPI.js";

class CourseAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Course";
  }

  saveCourse(payload) {
    return this.BaseAPIConfig.post(`${this.controller}/save-course`, payload);
  }
}

export default new CourseAPI();
