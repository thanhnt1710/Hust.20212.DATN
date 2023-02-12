import BaseAPI from "@/apis/base/baseAPI.js";

class CategoryAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Category";
  }

  getAllCategory() {
    return this.BaseAPIConfig.get(`${this.controller}/list-category`);
  }
}

export default new CategoryAPI();
