<template>
  <div class="course-detail">
    <div class="cd-title">Thêm khóa học</div>
    <div class="cd-infor">
      <div class="title">Thông tin khóa học</div>
      <div class="detail">
        <div class="item flex-row flex-center">
          <div class="label">Tên khóa học</div>
          <div class="data">
            <base-input
              v-model="course.CourseName"
              maxLength="255"
              classInput="input-data"
              placeholder="Nhập tên khóa học"
            ></base-input>
          </div>
        </div>
        <div class="item flex-row flex-center">
          <div class="label">Mô tả khóa học</div>
          <div class="data">
            <textarea
              v-model="course.CourseDescription"
              rows="4"
              cols="50"
              maxLength="1000"
              placeholder="Nhập mô tả khóa học"
            ></textarea>
          </div>
        </div>
        <div class="category flex-row-between">
          <div class="item flex-row flex-1 flex-center">
            <div class="label">Danh mục</div>
            <div class="data">
              <base-combobox
                v-model="course.Category"
                classCombobox="cb-cat cb-category"
                :datas="category"
                :displayFn="displayFnCategory"
                placeholder="Chọn danh mục"
                label="CategoryName"
                track-by="CategoryID"
              ></base-combobox>
            </div>
          </div>
          <div class="item flex-row flex-1 flex-center">
            <div class="label">Danh mục con</div>
            <div class="data">
              <base-combobox
                v-model="course.SubCategory"
                classCombobox="cb-cat cb-subcategory"
                :datas="subCategory"
                :displayFn="displayFnSubCategory"
                placeholder="Chọn danh mục con"
                label="SubCategoryName"
                track-by="SubCategoryID"
              ></base-combobox>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="cd-content">
      <div class="title">Nội dung khóa học</div>
      <div class="main-content">
        <chapter
          v-for="(chapter, index) in courseChapter"
          :key="chapter.ChapterID"
          v-model="courseChapter[index]"
          @addLesson="addLesson(chapter)"
        >
        </chapter>
      </div>
      <div class="add-chapter">
        <base-button textBtn="Thêm chương" @click="addChapter"></base-button>
      </div>
    </div>
    <div class="cd-footer">
      <base-button @click="saveCourse" textBtn="Lưu"></base-button>
    </div>
  </div>
</template>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
<style lang="scss" scoped>
@import "@/scss/views/course_detail.scss";
</style>

<script>
import { mapState, mapActions } from "vuex";
import Chapter from "@/views/course/Chapter.vue";
import CourseAPI from "@/apis/views/courseAPI.js"

export default {
  name: "CourseDetail",
  components: {
    Chapter,
  },
  props: {},
  data() {
    return {
      moduleCategory: "module_category",
      moduleCourse: "module_course",
      dataCategory: null,
      courseChapter: [
        {
          ChapterID: 1,
          ChapterName: "Tên chương 1",
          ChapterPrevID: 0,
          CourseID: 1,
        },
        {
          ChapterID: 2,
          ChapterName: "Tên chương 2",
          ChapterPrevID: 1,
          CourseID: 1,
        },
      ],
      course: {
        CourseID: 1,
        CourseName: "Tên khóa học",
        CourseDescription: "123",
        CategoryID: 1,
        SubCategoryID: 1,
        Category: {
          CategoryID: 3,
          CategoryName: "Kỹ năng con người",
          CreatedBy: "",
          CreatedDate: "2022-11-26T00:04:07",
          ModifiedBy: "",
          ModifiedDate: "2022-11-26T00:04:07",
        },
        SubCategory: {},
      },
    };
  },
  created() {},
  computed: {
    ...mapState({
      formType(state) {
        return state[this.moduleCourse].formTypeCourseDetail;
      },
      category(state) {
        return state[this.moduleCategory].category;
      },
      subCategory(state) {
        return state[this.moduleCategory].subCategory;
      },
      chapterNew(state) {
        return state[this.moduleCourse].chapterNew;
      },
      lessonNew(state) {
        return state[this.moduleCourse].lessonNew;
      },
    }),
  },
  watch: {
    courseChapter: {
      handler: function (newValue, oldValue) {
        this.course.Chapters = newValue;
      },
      immediate: true,
    },
  },
  methods: {
    ...mapActions(["saveCourse"]),
    displayFnCategory({ CategoryID, CategoryName }) {
      return `${CategoryName}`;
    },

    displayFnSubCategory({ SubCategoryID, SubCategoryName }) {
      return `${SubCategoryName}`;
    },

    addChapter(e) {
      if (this.course.Chapters && Array.isArray(this.course.Chapters)) {
        this.course.Chapters.push(this.chapterNew);
      } else {
        this.course.Chapters = [this.chapterNew];
      }
    },

    addLesson(chapter) {
      if (chapter.Lessons && Array.isArray(chapter.Lessons)) {
        chapter.Lessons.push(this.lessonNew);
      } else {
        chapter.Lessons = [this.lessonNew];
      }
    },

    async saveCourse() {
      const me = this;

      await CourseAPI.saveCourse(me.course)
        .then((res) => {})
        .catch((err) => {});
    },
  },
};
</script>