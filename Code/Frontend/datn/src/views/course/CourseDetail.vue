<template>
  <div class="course-detail">
    <div class="cd-title flex-column-between">Thêm khóa học</div>
    <div class="cd-infor">
      <div class="title text-bold">Thông tin khóa học</div>
      <div class="detail">
        <div class="item flex-row flex-center">
          <div class="label text-bold mr-12">Tên khóa học</div>
          <div class="data flex-1">
            <base-input
              v-model="course.CourseName"
              maxLength="255"
              classInput="input-data"
              placeholder="Nhập tên khóa học"
            ></base-input>
          </div>
        </div>
        <div class="item flex-row flex-center">
          <div class="label text-bold mr-12">Mô tả khóa học</div>
          <div class="data flex-1">
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
          <div
            class="item flex-row flex-1 flex-center"
            style="margin-right: 12px"
          >
            <div class="label text-bold mr-12">Danh mục</div>
            <div class="data flex-1">
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
            <div class="label text-bold mr-12">Danh mục con</div>
            <div class="data flex-1">
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
          v-for="(chapter, index) in course.Chapters"
          :key="chapter.ChapterID"
          v-model="course.Chapters[index]"
          @addLesson="addLesson(chapter)"
          @removeLesson="removeLesson"
          @removeChapter="removeChapter(chapter, index)"
        >
        </chapter>
      </div>
      <div class="add-chapter">
        <base-button textBtn="Thêm chương" @click="addChapter"></base-button>
      </div>
    </div>
    <div class="cd-footer">
      <base-button
        @click="saveCourse"
        textBtn="Hủy"
        classButton="mr-12"
      ></base-button>
      <base-button
        @click="saveCourse"
        textBtn="Đăng"
        classButton="btn-primary-outline mr-12"
      ></base-button>
      <base-button
        @click="saveCourse"
        textBtn="Lưu"
        classButton="btn-primary"
      ></base-button>
    </div>
  </div>
</template>

<style src="vue-multiselect/dist/vue-multiselect.min.css"></style>
<style lang="scss" scoped>
@import "@/scss/views/course_detail.scss";
</style>

<script>
import Vue from "vue";
import { mapState, mapMutations, mapActions } from "vuex";
import Chapter from "@/components/views/Chapter.vue";
import courseAPI from "@/apis/views/courseAPI.js";

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
      courseIDMax: null,
      chapterIDMax: null,
      lessonIDMax: null,
      course: {},
    };
  },
  async created() {
    await this.getMaxID();
    this.initCourse();
  },
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
  watch: {},
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
    }),
    ...mapActions(["saveCourse"]),
    displayFnCategory({ CategoryID, CategoryName }) {
      return `${CategoryName}`;
    },

    displayFnSubCategory({ SubCategoryID, SubCategoryName }) {
      return `${SubCategoryName}`;
    },

    addChapter(e) {
      let chapterNew = { ...this.chapterNew };
      chapterNew.ChapterID = this.chapterIDMax + 1;
      chapterNew.CourseID = this.courseIDMax;
      if (
        this.course.Chapters &&
        Array.isArray(this.course.Chapters) &&
        this.course.Chapters.length > 0
      ) {
        chapterNew.ChapterPrevID =
          this.course.Chapters[this.course.Chapters.length - 1].ChapterID;
        this.course.Chapters.push(chapterNew);
      } else {
        chapterNew.ChapterPrevID = 0;
        this.course.Chapters = [chapterNew];
      }
      this.chapterIDMax++;
    },

    addLesson(chapter) {
      let lessonNew = { ...this.lessonNew };
      lessonNew.LessonID = this.lessonIDMax + 1;
      lessonNew.CourseID = this.courseIDMax;
      lessonNew.ChapterID = chapter.ChapterID;
      if (
        chapter.Lessons &&
        Array.isArray(chapter.Lessons) &&
        chapter.Lessons.length > 0
      ) {
        lessonNew.LessonPrevID =
          chapter.Lessons[chapter.Lessons.length - 1].LessonID;
        chapter.Lessons.push(lessonNew);
      } else {
        lessonNew.LessonPrevID = 0;
        chapter.Lessons = [lessonNew];
      }
      this.lessonIDMax++;
    },

    removeLesson(chapter) {
      let course = this.course;
      let index = course.Chapters.findIndex((c) => {
        return c.ChapterID == chapter.ChapterID;
      });
      course.Chapters[index] = chapter;
    },

    removeChapter(chapter, index) {
      let course = this.course;
      course.Chapters.splice(index, 1);
      if (course.Chapters.length > 0) {
        if (index == 0) {
          course.Chapters[0].ChapterPrevID = 0;
        } else {
          if (course.Chapters[index]) {
            course.Chapters[index].ChapterPrevID =
              course.Chapters[index - 1].ChapterID;
          }
        }
      }
    },

    async saveCourse() {
      const me = this;
      let payload = me.getPayloadSaveCourse();
      debugger;
      this.setLoading(true);
      await courseAPI
        .saveCourse(payload)
        .then((res) => {
          if (res && res.data && res.data.Success) {
            Vue.$toast.success("Thêm mới khóa học thành công.");
          } else {
            Vue.$toast.error("Có lỗi xảy ra vui lòng thử lại sau!");
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

    getPayloadSaveCourse() {
      const me = this;
      let payload = me.course;
      payload.CategoryID = payload.Category.CategoryID;
      payload.SubCategoryID = payload.SubCategory.SubCategoryID;
      let user = JSON.parse(localStorage.getItem("context"));
      if (user) {
        payload.UserID = user.UserID;
        payload.CreatedBy = user.UserName;
      }
      return payload;
    },

    async getMaxID() {
      const me = this;
      this.setLoading(true);
      await courseAPI
        .getMaxID()
        .then((res) => {
          if (res && res.data && res.data.Data) {
            this.courseIDMax = res.data.Data.CourseID;
            this.chapterIDMax = res.data.Data.ChapterID;
            this.lessonIDMax = res.data.Data.LessonID;
          }
        })
        .catch((err) => {
          console.log(err);
        })
        .finally(() => {
          this.setLoading(false);
        });
    },

    initCourse() {
      this.course = {
        CourseID: this.courseIDMax,
        CourseName: null,
        CourseDescription: null,
        Category: null,
        SubCategory: null,
        Chapters: [
          {
            ChapterID: this.chapterIDMax + 1,
            ChapterName: null,
            CourseID: this.courseIDMax,
            ChapterPrevID: 0,
            Lessons: [],
          },
        ],
      };
      this.chapterIDMax++;
    },
  },
};
</script>