<template>
  <div class="chapter" :class="classChapter">
    <div class="chapter-name">
      <base-input
        :value="dataChapter.ChapterName"
        maxLength="255"
        classInput="chapter-name-input"
        placeholder="Nhập tên chương"
      ></base-input>
    </div>
    <lesson v-for="lesson in lessons" :key="lesson.LessonID" :dataLesson="lesson"></lesson>
    <div class="add-chapter">
        <base-button textBtn="Thêm chương"></base-button>
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
  methods: {},
};
</script>