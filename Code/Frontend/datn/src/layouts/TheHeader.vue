<template>
  <div class="header flex-row-between">
    <div class="header-left flex-row-between">
      <img
        src="../assets/images/logo.svg"
        alt=""
        class="logo"
        @click="dashboard"
      />
      <div class="app-name flex">Chia sẻ và học hỏi kiến thức</div>
    </div>
    <div class="header-mid">
      <base-input
        classInput="search-header"
        placeholder="Tìm kiếm khóa học ..."
        :iconLeft="{ classname: '' }"
        @enterInput="searchCourse"
      ></base-input>
    </div>
    <div class="header-right flex-row-between">
      <div v-if="isAdmin" class="btn-fn statistic" @click="statistic">Thống kê</div>
      <div class="btn-fn dashboard" @click="dashboard">Trang chủ</div>
      <div class="btn-fn my-course" @click="myCourse">Khóa học của tôi</div>
      <div class="avatar">
        <img src="../assets/images/avatar.jpg" alt="" />
        <div class="logout flex-center" @click="logout">Đăng xuất</div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/header.scss";
</style>

<script>
import { mapState, mapMutations, mapActions } from "vuex";
import commonFn from "@/commons/commonFunction.js";
import courseAPI from "@/apis/views/courseAPI";

export default {
  name: "TheHeader",
  components: {},
  data() {
    return {
      moduleCourse: "module_course",
    };
  },
  computed: {
    ...mapState({
      paramGetCourse(state) {
        return state[this.moduleCourse].paramGetCourse;
      },
    }),
    context() {
      return JSON.parse(localStorage.getItem("context"));
    },
    isAdmin() {
      return this.context.IsAdmin;
    }
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
      setParamGetCourse: "setParamGetCourse",
      setCourses: "setCourses",
    }),
    dashboard() {
      this.$router.push("/main/dashboard");
    },
    myCourse() {
      this.$router.push("/main/my-course");
    },
    logout() {
      localStorage.removeItem("token");
      this.$router.push("/login");
    },
    dashboard() {
      this.$router.push("/");
    },
    async searchCourse(inputFilter) {
      const me = this;
      let payload = me.paramGetCourse;
      let screenNameCurrent = me.$route.name;

      payload.InputFilter = inputFilter ? inputFilter : null;
      if (me.context) {
        payload.UserID = me.$app.config.ScreenNameLoadMyCourse.includes(
          screenNameCurrent
        )
          ? me.context.UserID
          : null;
      }

      me.setLoading(true);
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
    statistic() {
      this.$router.push("/main/statistic");
    }
  },
};
</script>