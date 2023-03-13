<template>
  <div class="list-my-course flex-column">
    <div class="lmc-data">
      <div class="lmc-header flex-row-between">
        <div class="lmc-title">Khóa học của tôi</div>
        <base-button
          textBtn="Thêm khóa học"
          classButton="btn-primary lmc-add-btn"
          @click="addCourse"
        ></base-button>
      </div>
      <div class="lmc-result">
        <div class="lmc-item" v-for="course in courses" :key="course.CourseID">
          <course-box
            :course="course"
            :editable="true"
            @clickCourse="clickCourse(course)"
            @removeCourse="removeCourse(course)"
          ></course-box>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/list_my_course.scss";
</style>

<script>
import Vue from "vue";
import { mapState, mapMutations, mapActions } from "vuex";
import CourseBox from "@/components/views/CourseBox.vue";
import courseAPI from "@/apis/views/courseAPI";
import commonFn from "@/commons/commonFunction.js";

export default {
  name: "ListMyCorse",
  components: {
    CourseBox,
  },
  async created() {
    await this.getMyCourse();
  },
  data() {
    return {
      module: "module_course",
    };
  },
  computed: {
    ...mapState({
      paramGetCourse(state) {
        return state[this.module]
          ? state[this.module].paramGetCourse
          : {};
      },
      courses(state) {
        return state[this.module] ? state[this.module].courses : [];
      },
    }),
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
      setFormTypeCourseDetail: "setFormTypeCourseDetail",
      setCurrentCourseLearn: "setCurrentCourseLearn",
      setCurrentCourseDetail: "setCurrentCourseDetail",
      setCourses: "setCourses",
    }),

    async getMyCourse() {
      const me = this;
      let userID = null;
      let context = JSON.parse(localStorage.getItem("context"));
      if (context) {
        userID = context.UserID;
      }
      if (userID) {
        this.setLoading(true);
        let payload = this.paramGetCourse;
        payload.UserID = userID;

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
      }
    },

    clickCourse(course) {
      this.setCurrentCourseLearn(course);
    },

    addCourse() {
      this.setFormTypeCourseDetail(1); // form thêm
      this.setCurrentCourseDetail({});
      this.$router.push("/main/course-detail");
    },

    async removeCourse(course) {
      const me = this;

      this.setLoading(true);
      await courseAPI
        .removeCourse(course.CourseID)
        .then(async (res) => {
          if (res && res.data && res.data.Success) {
            Vue.$toast.success("Xóa khóa học thành công.");
            await this.getMyCourse();
          }
        })
        .catch((err) => {
          console.log(err);
          Vue.$toast.error("Xóa khóa học không thành công!");
        })
        .finally(() => {
          this.setLoading(false);
        });
    },
  },
};
</script>