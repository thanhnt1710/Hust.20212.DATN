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
    <div class="line-center"></div>
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
        <div class="add-chapter">
          <base-button
            classButton="btn-primary"
            textBtn="Thêm chương"
            @click="addChapter"
          ></base-button>
        </div>
      </div>
    </div>
    <div class="line-center"></div>
    <div class="cd-test">
      <div class="test-title">Bài kiểm tra khóa học</div>
      <div class="test-content">
        <question
          v-for="(question, index) in course.Questions"
          :key="question.QuestionID"
          v-model="course.Questions[index]"
          @removeQuestion="removeQuestion(question, index)"
        >
        </question>
        <div class="add-question">
          <base-button
            classButton="btn-primary"
            textBtn="Thêm câu hỏi"
            @click="addQuestion"
          ></base-button>
        </div>
      </div>
    </div>
    <div class="cd-footer">
      <base-button
        @click="cancel"
        textBtn="Hủy"
        classButton="mr-12"
      ></base-button>
      <!-- <base-button
        @click="saveCourse"
        textBtn="Đăng"
        classButton="btn-primary-outline mr-12"
      ></base-button> -->
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
import Question from "@/components/views/Question.vue";
import courseAPI from "@/apis/views/courseAPI.js";
import questionAPI from "@/apis/views/questionAPI.js";

export default {
  name: "CourseDetail",
  components: {
    Chapter,
    Question,
  },
  props: {},
  data() {
    return {
      moduleCategory: "module_category",
      moduleCourse: "module_course",
      moduleQuestion: "module_question",
      dataCategory: null,
      courseIDMax: 0,
      chapterIDMax: 0,
      lessonIDMax: 0,
      questionIDMax: 0,
    };
  },
  async created() {
    await this.getMaxID();
    await this.getMaxIDQuestion();
    this.initCourse();
  },
  computed: {
    ...mapState({
      course(state) {
        return state[this.moduleCourse].currentCourseDetail;
      },
      formType(state) {
        return state[this.moduleCourse].setFormTypeCourseDetail;
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
      questionNew(state) {
        return state[this.moduleQuestion].questionNew;
      },
    }),
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
      setCurrentCourseDetail: "setCurrentCourseDetail",
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
      chapterNew.CourseID = this.course.CourseID;
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
      lessonNew.CourseID = this.course.CourseID;
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

    addQuestion() {
      const me = this;
      let newQuestion = JSON.parse(JSON.stringify(this.questionNew));
      newQuestion.QuestionID = this.questionIDMax + 1;
      newQuestion.CourseID = this.course.CourseID;
      this.course.Questions.push(newQuestion);
      this.questionIDMax++;
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

    removeQuestion(question, index) {
      let course = this.course;
      course.Questions.splice(index, 1);
    },

    async saveCourse() {
      const me = this;
      let payload = me.getPayloadSaveCourse();
      this.setLoading(true);
      await courseAPI
        .saveCourse(payload)
        .then((res) => {
          if (res && res.data && res.data.Success) {
            Vue.$toast.success("Lưu khóa học thành công.");
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

    async getMaxIDQuestion() {
      const me = this;
      this.setLoading(true);
      await questionAPI
        .getMaxID()
        .then((res) => {
          if (res && res.data && res.data.Data) {
            this.questionIDMax = res.data.Data;
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
      // Form thêm mới khóa học mới khởi tạo
      if (this.$store.state[this.moduleCourse].formTypeCourseDetail == 1) {
        let course = {
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
          Questions: [],
        };
        this.chapterIDMax++;
        this.setCurrentCourseDetail(course);
      }
    },

    cancel() {
      this.$router.back();
    },
  },
};
</script>