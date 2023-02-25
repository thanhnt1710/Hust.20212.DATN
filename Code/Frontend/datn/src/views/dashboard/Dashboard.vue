<template>
  <div class="dashboard-data flex-column">
    <div v-if="!isFilter" class="data-common">
      <the-slide-show></the-slide-show>
      <list-course
        titleList="Khóa học nổi bật"
        :type="$app.enums.CourseType.Top"
      ></list-course>
      <list-course
        titleList="Khóa học mới nhất"
        :type="$app.enums.CourseType.New"
      ></list-course>
      <list-course
        titleList="Khóa học được yêu thích nhất"
        :type="$app.enums.CourseType.Love"
      ></list-course>
    </div>
    <div v-else class="data-filter">
      <div class="filter-title">Trang chủ</div>
      <div class="filter-result">
        <div
          class="filter-item"
          v-for="course in courses"
          :key="course.CourseID"
        >
          <course-box :course="course"></course-box>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/dashboard.scss";
</style>

<script>
import Vue from "vue";
import { mapState, mapMutations, mapActions } from "vuex";
import commonFn from "@/commons/commonFunction.js";
import courseAPI from "@/apis/views/courseAPI";
import TheSlideShow from "@/layouts/TheSlideShow.vue";
import ListCourse from "@/components/views/ListCourseBox.vue";
import CourseBox from "@/components/views/CourseBox.vue";

export default {
  name: "Dashboard",
  components: {
    ListCourse,
    TheSlideShow,
    CourseBox,
  },
  props: {},
  data() {
    return {
      showNavLeft: true,
      isFilter: true, // Trạng thái đang lọc hay không
      moduleCourse: "module_course",
    };
  },
  async created() {
    await this.getListCourse();
  },
  computed: {
    ...mapState({
      paramGetCourse(state) {
        return state[this.moduleCourse]
          ? state[this.moduleCourse].paramGetCourse
          : {};
      },
      courses(state) {
        return state[this.moduleCourse] ? state[this.moduleCourse].courses : [];
      },
    }),
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
      setCourses: "setCourses",
    }),

    async getListCourse() {
      const me = this;

      this.setLoading(true);
      let payload = this.paramGetCourse;
      payload.UserID = null;

      await courseAPI
        .getListCourse(payload)
        .then((res) => {
          if (res && res.data && res.data.Success) {
            this.setCourses(commonFn.convertCourse(res.data.Data));
          } else {
            Vue.$toast.error("Lấy danh sách khóa học không thành công!");
          }
        })
        .catch((err) => {
          console.log(err);
          Vue.$toast.error("Lấy danh sách khóa học không thành công!");
        })
        .finally(() => {
          this.setLoading(false);
        });
    },
  },
};
</script>