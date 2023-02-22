<template>
  <div class="course-learn flex-column">
    <div class="cl-header">
      <div class="logo"></div>
      <div class="course-name">Bài học đầu tiên</div>
    </div>
    <div class="cl-main flex-row">
      <div class="cl-left flex-column">
        <div class="cl-left-video">
          <video controls class="w-100 ">
            <source
              src="https://localhost:44357/Attachment/view/d141b0ed-8c8e-40fa-ab7b-d0b03b1d2670.mp4"
              type="video/mp4"
            />
          </video>
        </div>
        <div class="cl-left-file">
          <iframe
            src="https://localhost:44357/Attachment/view/4f8d75ba-6e20-4b90-bcb8-18498d1c030f.pdf"
            frameborder="0"
            class="w-100"
          ></iframe>
        </div>
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
  created() {},

  data() {
    return {};
  },
  methods: {},
};
</script>