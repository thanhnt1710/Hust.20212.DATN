import BaseAPI from "@/apis/base/baseAPI.js";

class QuestionAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Question";
  }

  getMaxID() {
    return this.getAxios(`${this.controller}/max-id`);
  }

  scroingTest(payload) {
    return this.postAxios(`${this.controller}/scroing-test`, payload);
  }
}

export default new QuestionAPI();
