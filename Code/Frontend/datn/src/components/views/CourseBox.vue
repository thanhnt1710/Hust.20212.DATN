<template>
  <div class="course-box flex-column" @click="clickCourse">
    <div class="course-function">
      <i
        class="fas fa-eye icon-fn icon-fn-view"
        title="Xem"
        @click="viewCourse"
      ></i>
      <i
        v-if="editable"
        class="fas fa-tools icon-fn icon-fn-edit"
        title="Sửa"
        @click="editCourse"
      ></i>
      <i
        v-if="editable"
        class="fas fa-trash-alt icon-fn icon-fn-remove"
        title="Xóa"
        @click="removeCourse"
      ></i>
      <i
        class="fas fa-comment-dots icon-fn icon-fn-evaluate"
        title="Đánh giá"
        @click="evaluateCourse"
      ></i>
    </div>
    <div class="course-img">
      <img src="../../assets/images/imageproxy.webp" alt="" />
    </div>
    <div class="course-data">
      <div class="course-category line-break-2">{{ course.CategoryName }}</div>
      <div class="course-name line-break-2">{{ course.CourseName }}</div>
      <div class="course-des line-break-3" :title="course.CourseDescription">
        {{ course.CourseDescription }}
      </div>
      <div class="course-author">{{ course.AuthorName }}</div>
    </div>
  </div>
</template>

<style lang="scss">
@import "@/scss/views/course_box.scss";
</style>

<script>
import { mapState, mapMutations, mapActions } from "vuex";

export default {
  name: "CourseBox",
  components: {},
  props: {
    course: {
      type: Object,
      default: {},
    },
    editable: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      moduleCategory: "module_category",
    };
  },
  computed: {
    ...mapState({
      category(state) {
        return state[this.moduleCategory].category;
      },
      subCategory(state) {
        return state[this.moduleCategory].subCategory;
      },
    }),
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
      setFormTypeCourseDetail: "setFormTypeCourseDetail",
      setCurrentCourseLearn: "setCurrentCourseLearn",
      setCurrentCourseDetail: "setCurrentCourseDetail",
      setShowEvaluate: "setShowEvaluate",
      setInfoCourse: "setInfoCourse",
    }),
    clickCourse() {
      this.$emit("clickCourse", this.course);
    },
    viewCourse() {
      this.setCurrentCourseLearn(this.course);
      this.$router.push("/course-learn");
    },
    editCourse() {
      // Thêm dữ liệu category cho course
      this.course.Category = this.category.find((c) => {
        return c.CategoryID == this.course.CategoryID;
      });
      this.course.SubCategory = this.subCategory.find((s) => {
        return s.SubCategoryID == this.course.SubCategoryID;
      });
      this.setFormTypeCourseDetail(2); // form sửa
      this.setCurrentCourseDetail(this.course);
      this.$router.push("/main/course-detail");
    },
    removeCourse() {
      this.$emit("removeCourse");
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