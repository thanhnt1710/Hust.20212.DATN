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

  getListCourse(payload) {
    return this.postAxios(`${this.controller}/get-list-course`, payload);
  }

  getDataStatistic() {
    return this.postAxios(`${this.controller}/get-data-statistic`);
  }
}

export default new CourseAPI();
