import BaseAPI from "@/apis/base/baseAPI.js";

class AttachmentAPI extends BaseAPI {
  constructor() {
    super();
    this.controller = "Attachment";
  }

  uploadAttachment(attachment) {
    return axios.post('https://localhost:44357/Attachment/upload', attachment,{
        'content-type': "multipart/form-data",
        'Content-Type': "multipart/form-data",
    })
  }
}

export default new AttachmentAPI();
