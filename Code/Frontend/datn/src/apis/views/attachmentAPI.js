import BaseAPI from "@/apis/base/baseAPI.js";
import axios from "axios";

class AttachmentAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Attachment";
  }

  uploadAttachment(attachment) {
    return axios.post(`${this.baseURL}${this.controller}/upload`, attachment, {
      headers: {
        "Authorization": `Bearer ${localStorage.getItem("token")}`,
        "Access-Control-Allow-Origin": "*",
        "content-type": "multipart/form-data",
        "Content-Type": "multipart/form-data",
      },
    });
  }
}

export default new AttachmentAPI();
