<template>
  <div class="lesson">
    <div class="lesson-name">
      <base-input
        :value="dataLesson.LessonName"
        maxLength="255"
        classInput="lesson-name-input"
        placeholder="Nhập tên bài"
      ></base-input>
    </div>
    <div class="lesson-content">
      <div class="content-video">
        <div class="label-video">Video</div>
        <div class="data-video">
          <input type="file" ref="video" @change="uploadVideo" />
        </div>
      </div>
      <div class="content-file">
        <div class="label-file">File</div>
        <div class="data-file">
          <input type="file" ref="file" @change="uploadFile" />
        </div>
      </div>
    </div>
    <div class="add-lesson">
      <base-button textBtn="Thêm bài giảng"></base-button>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/chapter_lesson.scss";
</style>

<script>
import AttachmentAPI from "@/apis/views/attachmentAPI.js";
import axios from "axios";

export default {
  name: "Lesson",
  components: {},
  props: {
    dataLesson: {
      type: Object,
      default: {},
    },
  },
  data() {
    return {};
  },
  methods: {
    uploadVideo(e) {
      const me = this;
      let video = me.$refs.video.files[0];
      let attachment = new FormData();
      attachment.append("file", video);
      axios.post("https://localhost:44357/Attachment/upload", attachment, {
        "content-type": "multipart/form-data",
        "Content-Type": "multipart/form-data",
      });
      //   AttachmentAPI.uploadAttachment(formData)
      //     .then((res) => {debugger})
      //     .catch((err) => {debugger});
    },
    uploadFile(e) {},
  },
};
</script>