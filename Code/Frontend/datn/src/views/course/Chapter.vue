<template>
  <div class="chapter" :class="classChapter">
    <div class="chapter-name">
      <base-input
        v-model="internalChapter.ChapterName"
        maxLength="255"
        classInput="chapter-name-input"
        placeholder="Nhập tên chương"
      ></base-input>
    </div>
    <lesson
      v-for="(lesson, index) in chapterLesson"
      :key="lesson.LessonID"
      v-model="chapterLesson[index]"
    ></lesson>
    <div class="add-lesson">
      <base-button textBtn="Thêm bài giảng" @click="addLesson"></base-button>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/chapter_lesson.scss";
</style>

<script>
import Lesson from "@/views/course/Lesson.vue";

export default {
  name: "Chapter",
  components: {
    Lesson,
  },
  props: {
    value: {
      default: {},
    },
    classChapter: {
      type: String,
      default: "",
    },
  },
  computed: {
    lessons() {
      return this.internalChapter && this.internalChapter.Lessons
        ? this.internalChapter.Lessons
        : [];
    },
  },
  data() {
    return {
      internalChapter: this.value,
      chapterLesson: [
        {
          LessonID: 1,
          LessonName: "Tên bài 1",
          FileID: "",
          VideoID: "",
          IsMixQuestion: true,
          LessonPrevID: 1,
          ChapterID: 1,
          CourseID: 1,
        },
      ],
    };
  },
  watch: {
    internalChapter: {
      handler: function (newValue, oldValue) {
        this.$emit("input", newValue);
      },
      immediate: true,
    },

    value: {
      handler: function (newValue, oldValue) {
        this.internalChapter = newValue;
      },
      immediate: true,
    },

    chapterLesson: {
      handler: function (newValue, oldValue) {
        this.internalChapter.Lessons = newValue;
      },
      immediate: true,
    },
  },
  methods: {
    addLesson(e) {
      this.$emit("addLesson");
    },
  },
};
</script>