<template>
  <div class="course-learn">
    <div class="cl-header"></div>
    <div class="cl-main">
      <div class="cl-left">
        <iframe
          src="https://www.w3schools.com"
          title="W3Schools Free Online Web Tutorials"
          style="width: 1000px; height: 700px"
        ></iframe>
      </div>
      <div class="cl-right"></div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/course_learn.scss";
</style>

<script>
export default {
  name: "CourseLearn",
  components: {},
  props: {},
  data() {
    return {};
  },
  methods: {},
};
</script>