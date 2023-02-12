import APIConfig from "./apiConfig.js";
import axios from "axios";

export default class BaseAPI {
  constructor() {
    this.controller = null;
    this.BaseAPIConfig = axios.create({
      baseURL: APIConfig,
      headers: {
        "Content-type": "application/json",
        "Access-Control-Allow-Origin": "*",
      },
    });
  }

  getAll() {
    return BaseAPIConfig.get(`${this.controller}`);
  }

  getById(id) {
    return BaseAPIConfig.get(`${this.controller}/${id}`);
  }

  add(body) {
    return BaseAPIConfig.post(`${this.controller}`, body);
  }

  update(body) {
    return BaseAPIConfig.put(`${this.controller}`, body);
  }

  delete(body) {
    return BaseAPIConfig.delete(`${this.controller}`, body);
  }
}
