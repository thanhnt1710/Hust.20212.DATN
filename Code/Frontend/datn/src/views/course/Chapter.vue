<template>
  <div class="chapter" :class="classChapter">
    <div class="chapter-name">
      <base-input
        :v-model="dataChapter.ChapterName"
        maxLength="255"
        classInput="chapter-name-input"
        placeholder="Nhập tên chương"
      ></base-input>
    </div>
    <lesson v-for="lesson in lessons" :key="lesson.LessonID" :dataLesson="lesson"></lesson>
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
    classChapter: {
      type: String,
      default: "",
    },
    dataChapter: {
      type: Object,
      default: {},
    },
  },
  computed: {
    lessons() {
      return this.dataChapter.Lessons ? this.dataChapter.Lessons : [];
    },
  },
  data() {
    return {};
  },
  methods: {
    addLesson(e) {
      this.$emit("addLesson");
    }
  },
};
</script>