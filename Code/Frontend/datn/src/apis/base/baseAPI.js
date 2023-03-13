import APIConfig from "./apiConfig.js";
import axios from "axios";

export default class BaseAPI {
  constructor() {
    this.controller = null;
    this.baseURL = APIConfig;
    this.BaseAPIConfig = axios.create({
      baseURL: APIConfig,
      headers: {
        "Content-type": "application/json",
        // "Access-Control-Allow-Origin": "origin",
        "Access-Control-Allow-Origin": "*",
        Authorization: `Bearer ${localStorage.getItem("token")}`,
      },
    });
  }

  setHeaderAPI() {
    this.BaseAPIConfig.defaults.headers.Authorization = `Bearer ${localStorage.getItem(
      "token"
    )}`;
  }

  handleResponse(response) {
    response.catch((err) => {
      if (err.response && err.response.status == 401) {
        location.replace(`${window.location.origin}/login`);
      }
    });
  }

  getAxios(url) {
    this.setHeaderAPI();
    let response = this.BaseAPIConfig.get(url);
    this.handleResponse(response);
    return response;
  }

  postAxios(url, payload) {
    this.setHeaderAPI();
    let response = this.BaseAPIConfig.post(url, payload);
    this.handleResponse(response);
    return response;
  }

  putAxios(url, payload) {
    this.setHeaderAPI();
    let response = this.BaseAPIConfig.put(url, payload);
    this.handleResponse(response);
    return response;
  }

  deleteAxios(url, payload) {
    this.setHeaderAPI();
    let response = this.BaseAPIConfig.delete(url, payload);
    this.handleResponse(response);
    return response;
  }

  getAll() {
    return this.getAxios(`${this.controller}`);
  }
}
