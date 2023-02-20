import BaseAPI from "@/apis/base/baseAPI.js";

class UserAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Auth";
  }

  login(payload) {
    return this.postAxios(`${this.controller}/login`, payload);
  }

  register(payload) {
    return this.postAxios(`${this.controller}/register`, payload);
  }
}

export default new UserAPI();
