<template>
  <div
    class="course flex-column"
  >
    <!-- <div v-show="overlay" class="course-overlay"></div> -->
    <div class="course-img">
      <img src="../assets/images/imageproxy.webp" alt="" />
    </div>
    <div class="course-data">
      <div class="course-category line-break-2">{{ course.CategoryName }}</div>
      <div class="course-name line-break-2">{{ course.CourseName }}</div>
      <div class="course-des line-break-3" :title="course.Description">
        {{ course.Description }}
      </div>
      <div class="course-author">{{ course.AuthorName }}</div>
    </div>
  </div>
</template>

<style lang="scss">
@import "@/scss/base/course.scss";
</style>

<script>
export default {
  name: "Course",
  components: {},
  props: {
    course: {
      type: Object,
      default: {},
    },
  },
  data() {
    return {
    };
  },
};
</script>