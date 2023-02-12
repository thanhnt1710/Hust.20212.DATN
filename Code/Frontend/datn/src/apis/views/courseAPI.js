import BaseAPI from "@/apis/base/baseAPI.js";

class CourseAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Course";
  }
}

export default new CourseAPI();
