<template>
  <div class="header flex-row-between">
    <div class="header-left flex-row-between">
      <div class="logo"><i class="fa-brands fa-slideshare logo-icon"></i></div>
      <div class="app-name flex">Tên của App</div>
    </div>
    <div class="header-mid">
      <base-input classInput="search-header" placeholder="Tìm kiếm khóa học ..." :iconLeft="{classname: ''}"></base-input>
    </div>
    <div class="header-right flex-row-between">
      <div class="my-course" @click="myCourse">Khóa học của tôi</div>
      <div class="avatar"><img src="../assets/images/avatar.jpg" alt=""></div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/base/header.scss";
</style>

<script>
export default {
  name: "TheHeader",
  components: {},
  props: {},
  methods: {
    myCourse() {
      this.$router.push("/main/course-detail");
    }
  },
};
</script>