import BaseAPI from "@/apis/base/baseAPI.js";

class QuestionAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Question";
  }

  getMaxID() {
    return this.getAxios(`${this.controller}/max-id`);
  }
}

export default new QuestionAPI();
