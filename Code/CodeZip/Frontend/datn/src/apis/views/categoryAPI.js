import BaseAPI from "@/apis/base/baseAPI.js";

class CategoryAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Category";
  }

  getAllCategory() {
    return this.getAxios(`${this.controller}/list-category`);
  }
}

export default new CategoryAPI();
