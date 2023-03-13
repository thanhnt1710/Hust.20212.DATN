<template>
  <div class="lesson">
    <div class="lesson-name flex-center">
      <base-input
        v-model="internalLesson.LessonName"
        maxLength="255"
        classInput="lesson-name-input"
        placeholder="Nhập tên bài giảng"
      ></base-input>
      <i
        title="Xóa bài"
        class="fas fa-trash-alt remove-lesson"
        @click="removeLesson"
      ></i>
    </div>
    <div class="lesson-content">
      <div class="content-video">
        <!-- <div class="label-video">Video</div> -->
        <div class="data-video flex-center">
          <base-button
            textBtn="Chọn Video"
            classButton="btn-primary-outline video-btn"
            @click="clickUploadVideo"
          ></base-button>
          <div class="video-name">{{ internalLesson.VideoName }}</div>
          <input
            type="file"
            ref="video"
            style="display: none"
            @change="uploadVideo"
          />
        </div>
      </div>
      <div class="content-file">
        <!-- <div class="label-file">File</div> -->
        <div class="data-file flex-center">
          <base-button
            textBtn="Chọn File"
            classButton="btn-primary-outline file-btn"
            @click="clickUploadFile"
          ></base-button>
          <div class="file-name">{{ internalLesson.FileName }}</div>
          <input
            type="file"
            ref="file"
            style="display: none"
            @change="uploadFile"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/chapter_lesson.scss";
::v-deep .file-btn .button {
  width: 120px;
}
</style>

<script>
import Vue from "vue";
import { mapState, mapMutations, mapActions } from "vuex";
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
    ...mapMutations({
      setLoading: "setLoading",
    }),
    removeLesson() {
      this.$emit("removeLesson");
    },

    clickUploadVideo() {
      this.$refs.video.click();
    },

    clickUploadFile() {
      this.$refs.file.click();
    },

    async uploadVideo(e) {
      const me = this;
      let video = me.$refs.video.files[0];
      let extension = video.name.split(".").pop();
      if (!me.$app.config.ExtensionVideo.includes(extension)) {
        me.$refs.video.value = "";
        Vue.$toast.error("Định dạng video không hợp lệ!");
      } else {
        let attachment = new FormData();
        attachment.append("file", video);
        this.setLoading(true);
        await AttachmentAPI.uploadAttachment(attachment)
          .then((res) => {
            if (res && res.data && res.data.Data) {
              me.internalLesson.VideoID = res.data.Data;
              me.internalLesson.VideoName = video.name;
            }
          })
          .catch((err) => {
            Vue.$toast.error("Có lỗi xảy ra vui lòng thử lại sau!");
            console.log(err);
          })
          .finally(() => {
            this.setLoading(false);
          });
      }
    },
    async uploadFile(e) {
      const me = this;
      let file = me.$refs.file.files[0];
      let extension = file.name.split(".").pop();
      if (!me.$app.config.ExtensionFile.includes(extension)) {
        me.$refs.file.value = "";
        Vue.$toast.error("Định dạng file không hợp lệ!");
      } else {
        let attachment = new FormData();
        attachment.append("file", file);
        this.setLoading(true);
        await AttachmentAPI.uploadAttachment(attachment)
          .then((res) => {
            if (res && res.data && res.data.Data) {
              me.internalLesson.FileID = res.data.Data;
              me.internalLesson.FileName = file.name;
            }
          })
          .catch((err) => {
            Vue.$toast.error("Có lỗi xảy ra vui lòng thử lại sau!");
            console.log(err);
          })
          .finally(() => {
            this.setLoading(false);
          });
      }
    },
  },
};
</script>