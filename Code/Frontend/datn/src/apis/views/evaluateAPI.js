import BaseAPI from "@/apis/base/baseAPI.js";

class EvaluateAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Evaluate";
  }
  
  getEvaluateByCourseID(courseID) {
    return this.postAxios(`${this.controller}/get-by-courseid/${courseID}`);
  }

  insertEvaluate(payload) {
    return this.postAxios(`${this.controller}/insert-evaluate`, payload);
  }
}

export default new EvaluateAPI();
