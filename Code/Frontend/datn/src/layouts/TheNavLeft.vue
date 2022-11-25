<template>
  <div class="navbar-left flex-column" :class="{ 'navbar-left-hide': !showNavLeft}">
    <div class="title flex-row-between">
      <p>Danh mục khóa học</p>
      <i class="fa-solid fa-bars" @click="toggleNavLeft"></i>
    </div>
    <div class="detail">
      <div class="detail-item flex-row" :class="{ 'active': item.Active}" v-for="item in category" :key="item.ID">
        <i class="fa-solid fa-music icon" :class="item.ClassLogoUI" :title="item.CategoryName"></i>
        <div class="text">{{ item.CategoryName }}</div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/base/navleft.scss";
</style>

<script>
export default {
  name: "TheNavLeft",
  components: {},
  props: {},
  data() {
    return {
      showNavLeft: true,
      category: [
        {
          CategoryID: 1,
          CategoryName: "Kỹ năng công việc",
          ClassLogoUI: "a",
          SubCategory: [
            {
              SubCategoryID: 1,
              SubCategoryName: "Thuyết trình",
            },
            {
              SubCategoryID: 2,
              SubCategoryName: "Nâng cao hiệu suất",
            },
          ],
        },
        {
          CategoryID: 2,
          CategoryName: "Kỹ năng con người",
          ClassLogoUI: "b",
          Active: true,
          SubCategory: [
            {
              SubCategoryID: 1,
              SubCategoryName: "Giao tiếp",
            },
            {
              SubCategoryID: 2,
              SubCategoryName: "abc",
            },
          ],
        },
        {
          CategoryID: 2,
          CategoryName: "Kỹ năng con người các thứ",
          ClassLogoUI: "b",
          SubCategory: [
            {
              SubCategoryID: 1,
              SubCategoryName: "Giao tiếp",
            },
            {
              SubCategoryID: 2,
              SubCategoryName: "abc",
            },
          ],
        },
      ],
    };
  },
  methods: {
    toggleNavLeft() {
      this.showNavLeft = !this.showNavLeft;
    }
  }
};
</script>