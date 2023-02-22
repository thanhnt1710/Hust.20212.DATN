<template>
  <div class="header flex-row-between">
    <div class="header-left flex-row-between">
      <img
        src="../assets/images/logo.svg"
        alt=""
        class="logo"
        @click="dashboard"
      />
      <div class="app-name flex">Học hỏi và chia sẻ kiến thức</div>
    </div>
    <div class="header-mid">
      <base-input
        classInput="search-header"
        placeholder="Tìm kiếm khóa học ..."
        :iconLeft="{ classname: '' }"
      ></base-input>
    </div>
    <base-button textBtn="Đăng xuất" @click="logout"></base-button>
    <div class="header-right flex-row-between">
      <div class="my-course" @click="myCourse">Khóa học của tôi</div>
      <div class="avatar"><img src="../assets/images/avatar.jpg" alt="" /></div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/header.scss";
</style>

<script>
export default {
  name: "TheHeader",
  components: {},
  props: {},
  methods: {
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
  },
};
</script>