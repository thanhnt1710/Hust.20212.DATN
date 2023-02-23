<template>
  <div class="course-learn flex-column">
    <div class="cl-header">
      <div class="logo"></div>
      <div class="course-name">{{course.CourseName}}</div>
    </div>
    <div class="cl-main flex-row flex-1">
      <div class="cl-left flex-column">
        <div class="cl-left-tab flex-row-between">
          <div
            class="tab tab-video flex-1"
            :class="{ 'tab-active': showVideo }"
            @click="showVideo = true"
          >
            Nội dung Video
          </div>
          <div
            class="tab tab-file flex-1"
            :class="{ 'tab-active': !showVideo }"
            @click="showVideo = false"
          >
            Nội dung File
          </div>
        </div>
        <div class="cl-left-content flex-center flex-1 scroll">
          <video
            v-if="showVideo"
            controls
            :src="srcVideo"
            type="video/mp4"
            class="cl-left-video flex-row-between"
          ></video>
          <iframe
            v-if="!showVideo"
            :src="srcFile"
            frameborder="0"
            class="cl-left-file"
          ></iframe>
        </div>
      </div>
      <div class="cl-right scroll">
        <div class="cl-right-title">Nội dung khóa học</div>
        <div class="cl-right-content">
          <div
            v-for="chapter in course.Chapters"
            :key="chapter.ChapterID"
            class="cl-item-chapter"
          >
            <div class="cl-item-chapter-name" :title="chapter.ChapterName">
              {{ chapter.ChapterName }}
            </div>
            <div
              v-for="lesson in chapter.Lessons"
              :key="lesson.LessonID"
              class="cl-item-lesson"
              :title="lesson.LessonName"
              @click="learnLesson(lesson)"
            >
              {{ lesson.LessonName }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/course_learn.scss";
</style>

<script>
import { mapState, mapMutations, mapActions } from "vuex";
import APIConfig from "@/apis/base/apiConfig.js";

export default {
  name: "CourseLearn",
  components: {},
  created() {},

  data() {
    return {
      showVideo: true,
      moduleCourse: "module_course",
      srcVideo: null,
      srcFile: null,
    };
  },
  computed: {
    ...mapState({
      course(state) {
        return state[this.moduleCourse].currentCourseLearn;
      },
    }),
  },
  methods: {
    learnLesson(lesson) {
      const me = this;
      if (lesson.VideoID) {
        this.srcVideo = `${APIConfig}Attachment/view/${lesson.VideoID}`;
      }
      if (lesson.FileID) {
        this.srcFile = `${APIConfig}Attachment/view/${lesson.FileID}`;
      }
    },
  },
};
</script>