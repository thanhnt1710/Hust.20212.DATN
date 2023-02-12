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
              maxLength="255"
              classInput="input-data"
              placeholder="Nhập tên khóa học"
            ></base-input>
          </div>
        </div>
        <div class="item flex-row flex-center">
          <div class="label">Mô tả khóa học</div>
          <div class="data">
            <base-input
              maxLength="1000"
              classInput="input-data"
              placeholder="Nhập mô tả khóa học"
            ></base-input>
          </div>
        </div>
        <div class="category flex-row-between">
          <div class="item flex-row flex-1 flex-center">
            <div class="label">Danh mục</div>
            <div class="data">
              <base-combobox
                :data="dataCategory"
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
                :data="dataCategory"
                classCombobox="cb-cat cb-subcategory"
                :datas="category"
                :displayFn="displayFnCategory"
                placeholder="Chọn danh mục"
                label="CategoryName"
                track-by="CategoryID"
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
          v-for="chapter in course.Chapters"
          :key="chapter.ChapterID"
          :dataChapter="chapter"
        >
        </chapter>
      </div>
    </div>
    <div class="cd-footer"></div>
  </div>
</template>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
<style lang="scss" scoped>
@import "@/scss/views/course_detail.scss";
</style>

<script>
import { mapState, mapActions } from "vuex";
import Chapter from "@/views/course/Chapter.vue";
export default {
  name: "CourseDetail",
  components: {
    Chapter,
  },
  props: {},
  data() {
    return {
      moduleCategory: "module_category",
      dataCategory: null,
      course: {
        CourseID: 1,
        CourseName: "Tên khóa học",
        CategoryID: 1,
        CategoryName: "Tên danh mục",
        SubCategoryID: 1,
        SubCategoryName: "Tên danh mục con",
        Chapters: [
          {
            ChapterID: 1,
            ChapterName: "Tên chương 1",
            ChapterParentID: 0,
            Lessons: [
              {
                LessonID: 1,
                LessonName: "Tên bài 1",
                LessonParentID: 0,
                FileID: "",
                VideoID: "",
                IsMixQuestion: true,
              },
              {
                LessonID: 2,
                LessonName: "Tên bài 2",
                LessonParentID: 1,
                FileID: "",
                VideoID: "",
                IsMixQuestion: true,
              },
            ],
          },
          {
            ChapterID: 2,
            ChapterName: "Tên chương 2",
            ChapterParentID: 1,
            Lesons: [],
          },
        ],
      },
    };
  },
  created() {},
  computed: {
    category() {
      return this.$store.state[this.moduleCategory].navbarCategory
        ? this.$store.state[this.moduleCategory].navbarCategory
        : [];
    },
  },
  methods: {
    displayFnCategory({ CategoryID, CategoryName }) {
      return `${CategoryName}`;
    },
  },
};
</script>