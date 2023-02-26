<template>
  <div class="course-learn flex-column">
    <div class="cl-header flex-center">
      <i class="fas fa-arrow-left back" @click="$router.back()"></i>
      <div class="course-name">{{ course.CourseName }}</div>
    </div>
    <div class="cl-main flex-row flex-1">
      <div
        v-if="srcFile || srcVideo"
        v-show="screenType != $app.enums.ScreenLearnType.Test"
        class="cl-left flex-column"
      >
        <div class="cl-left-tab flex-row-between">
          <div
            class="tab tab-video flex-1"
            :class="{
              'tab-active': screenType == $app.enums.ScreenLearnType.Video,
            }"
            @click="screenType = $app.enums.ScreenLearnType.Video"
          >
            Nội dung Video
          </div>
          <div
            class="tab tab-file flex-1"
            :class="{
              'tab-active': screenType == $app.enums.ScreenLearnType.File,
            }"
            @click="screenType = $app.enums.ScreenLearnType.File"
          >
            Nội dung File
          </div>
        </div>
        <div class="cl-left-content flex-center flex-1 scroll">
          <video
            v-if="screenType == $app.enums.ScreenLearnType.Video"
            controls
            :src="srcVideo"
            type="video/mp4"
            class="cl-left-video flex-row-between"
          ></video>
          <iframe
            v-if="screenType == $app.enums.ScreenLearnType.File"
            :src="srcFile"
            frameborder="0"
            class="cl-left-file"
          ></iframe>
        </div>
      </div>
      <div
        v-if="srcFile || srcVideo"
        v-show="screenType == $app.enums.ScreenLearnType.Test"
        class="cl-left-test flex-column scroll"
      >
        <div class="cl-test-header flex-row-between">
          <div class="cl-test-title">
            Bài kiểm tra khóa học: {{ course.CourseName }}
          </div>
          <div class="cl-test-scroing">
            <base-button
              classButton="btn-primary"
              textBtn="Nộp bài"
              @click="scroingTest"
            ></base-button>
          </div>
        </div>
        <div class="cl-test-content">
          <question
            v-for="(question, index) in course.Questions"
            :key="question.QuestionID"
            v-model="course.Questions[index]"
            :ref="'question' + question.QuestionID"
            :readonly="true"
          >
          </question>
        </div>
      </div>
      <div v-else class="no-select-lesson flex-column flex-center">
        <img src="../../assets/images/welcome_course.jpg" alt="" />
        <div class="welcome-text">
          <div class="welcome-str flex-center flex-column">
            Chào mừng bạn đến với khóa học:
            <div class="course-name">{{ course.CourseName }}</div>
          </div>
          <div class="guide">Chọn bài giảng bên phải để bắt đầu</div>
        </div>
      </div>
      <div class="cl-right scroll">
        <div class="cl-right-title flex-row-between">
          <p>Nội dung khóa học</p>
          <i
            class="fas fa-comment-dots icon-evaluate"
            title="Đánh giá khóa học"
            @click="evaluateCourse"
          ></i>
        </div>
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
              :class="{ 'cl-item-lesson-active': lesson.isActive }"
              :title="lesson.LessonName"
              @click="learnLesson(lesson)"
            >
              {{ lesson.LessonName }}
            </div>
          </div>
          <div
            v-if="course.Questions && course.Questions.length > 0"
            class="cl-test flex-center"
            @click="screenType = $app.enums.ScreenLearnType.Test"
          >
            Làm bài kiểm tra khóa học
          </div>
        </div>
      </div>
    </div>
    <evaluate :showEvaluate="showEvaluate"></evaluate>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/course_learn.scss";
</style>

<script>
import Vue from "vue";
import { mapState, mapMutations, mapActions } from "vuex";
import APIConfig from "@/apis/base/apiConfig.js";
import Question from "@/components/views/Question.vue";
import Evaluate from "@/components/views/Evaluate.vue";
import questionAPI from "@/apis/views/questionAPI.js";

export default {
  name: "CourseLearn",
  components: {
    Question,
    Evaluate,
  },
  created() {},

  data() {
    const me = this;

    return {
      screenType: me.$app.enums.ScreenLearnType.Video, // 1-video, 2-file, 3-test
      moduleCourse: "module_course",
      moduleEvaluate: "module_evaluate",
      srcVideo: null,
      srcFile: null,
    };
  },
  computed: {
    ...mapState({
      course(state) {
        return state[this.moduleCourse].currentCourseLearn;
      },
      showEvaluate(state) {
        return state[this.moduleEvaluate].showEvaluate;
      },
    }),
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
      setShowEvaluate: "setShowEvaluate",
      setInfoCourse: "setInfoCourse",
    }),
    learnLesson(lesson) {
      const me = this;

      // Css hiển thị
      let chapters = me.course.Chapters;
      chapters.map((c) => {
        c.Lessons.map((l) => {
          l.isActive = false;
        });
      });
      lesson.isActive = true;

      me.screenType = me.$app.enums.ScreenLearnType.Video;
      this.srcVideo = lesson.VideoID
        ? `${APIConfig}Attachment/view/${lesson.VideoID}`
        : `${APIConfig}Attachment/view`;
      this.srcFile = lesson.FileID
        ? `${APIConfig}Attachment/view/${lesson.FileID}`
        : `${APIConfig}Attachment/view`;
    },

    async scroingTest() {
      const me = this;

      this.setLoading(true);

      await questionAPI
        .scroingTest(me.course.Questions)
        .then((res) => {
          if (res && res.data && res.data.Success) {
            me.handleDisplayResultTest(res.data.Data);
            Vue.$toast.success(res.data.UserMsg);
          }
        })
        .catch((err) => {
          console.log(err);
          Vue.$toast.error("Có lỗi xảy ra vui lòng thử lại sau!");
        })
        .finally(() => {
          this.setLoading(false);
        });
    },

    handleDisplayResultTest(resultTest) {
      const me = this;
      let questions = me.course.Questions;
      if (resultTest && Array.isArray(resultTest) && resultTest.length > 0) {
        resultTest.map((item) => {
          let refName = `question${item.QuestionID}`;
          me.$refs[refName][0].setCorrectAnswer(item.CorrectAnswer);
        });
      }
    },

    evaluateCourse() {
      // Cập nhật thông tin khóa học lấy đánh giá
      this.setInfoCourse({
        CourseID: this.course.CourseID,
        CourseName: this.course.CourseName,
      });

      // Mở form xem đánh giá
      this.setShowEvaluate(true);
    },
  },
};
</script>