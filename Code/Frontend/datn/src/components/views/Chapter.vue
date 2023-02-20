<template>
  <div class="chapter" :class="classChapter">
    <div class="chapter-name flex-center">
      <base-input
        v-model="internalChapter.ChapterName"
        maxLength="255"
        classInput="chapter-name-input"
        placeholder="Nhập tên chương"
      ></base-input>
      <i
        title="Xóa chương"
        class="fas fa-folder-minus remove-chapter"
        @click="removeChapter"
      ></i>
    </div>
    <lesson
      v-for="(lesson, index) in value.Lessons"
      :key="lesson.LessonID"
      v-model="value.Lessons[index]"
      @removeLesson="removeLesson(lesson, index)"
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
import Lesson from "@/components/views/Lesson.vue";

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
    // lessons() {
    //   return this.internalChapter && this.internalChapter.Lessons
    //     ? this.internalChapter.Lessons
    //     : [];
    // },
  },
  data() {
    return {
      internalChapter: this.value,
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
  },
  methods: {
    addLesson(e) {
      this.$emit("addLesson");
    },

    removeChapter() {
      this.$emit("removeChapter");
    },

    removeLesson(lesson, index) {
      let chapter = this.value;

      chapter.Lessons.splice(index, 1);
      if (chapter.Lessons.length > 0) {
        if (index == 0) {
          chapter.Lessons[0].LessonPrevID = 0;
        } else {
          if (chapter.Lessons[index]) {
            chapter.Lessons[index].LessonPrevID =
              chapter.Lessons[index - 1].LessonID;
          }
        }
      }

      this.$emit("removeLesson", chapter);
    },
  },
};
</script>