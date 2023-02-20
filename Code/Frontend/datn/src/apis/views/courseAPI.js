import BaseAPI from "@/apis/base/baseAPI.js";

class CourseAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Course";
  }

  saveCourse(payload) {
    return this.postAxios(`${this.controller}/save-course`, payload);
  }

  getMaxID() {
    return this.getAxios(`${this.controller}/max-id`);
  }
}

export default new CourseAPI();
