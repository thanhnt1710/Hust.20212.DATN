<template>
  <div class="lesson">
    <div class="lesson-name">
      <base-input
        v-model="internalLesson.LessonName"
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
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/chapter_lesson.scss";
</style>

<script>
import Vue from "vue";
import AttachmentAPI from "@/apis/views/attachmentAPI.js";
import axios from "axios";

export default {
  name: "Lesson",
  components: {},
  props: {
    value: {
      default: {},
    },
  },
  data() {
    return {
      internalLesson: this.value,
    };
  },
  watch: {
    internalLesson: {
      handler: function (newValue, oldValue) {
        this.$emit("input", newValue);
      },
      immediate: true,
    },

    value: {
      handler: function (newValue, oldValue) {
        this.internalLesson = newValue;
      },
      immediate: true,
    },
  },
  methods: {
    async uploadVideo(e) {
      const me = this;
      let video = me.$refs.video.files[0];
      let extension = video.name.split(".").pop();
      if (!me.$app.config.extensionVideo.includes(extension)) {
        me.$refs.video.value = "";
        Vue.$toast.error("Định dạng video không hợp lệ!");
      } else {
        let attachment = new FormData();
        attachment.append("file", video);
        await AttachmentAPI.uploadAttachment(attachment)
          .then((res) => {
            if (res && res.Data) {
              me.internalLesson.VideoID = res.Data;
            }
          })
          .catch((err) => {
            console.log(err);
          });
      }
    },
    async uploadFile(e) {
      const me = this;
      let file = me.$refs.file.files[0];
      let extension = file.name.split(".").pop();
      if (!me.$app.config.extensionFile.includes(extension)) {
        me.$refs.file.value = "";
        Vue.$toast.error("Định dạng file không hợp lệ!");
      } else {
        let attachment = new FormData();
        attachment.append("file", file);
        await AttachmentAPI.uploadAttachment(attachment)
          .then((res) => {
            if (res && res.Data) {
              me.internalLesson.FileID = res.Data;
            }
          })
          .catch((err) => {
            console.log(err);
          });
      }
    },
  },
};
</script>