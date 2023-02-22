<template>
  <div
    class="navbar-left flex-column"
    :class="{ 'navbar-left-hide': !showNavLeft }"
  >
    <div class="title flex-row-between">
      <p>Danh mục khóa học</p>
      <i class="fa-solid fa-bars" @click="toggleNavLeft"></i>
    </div>
    <div class="detail">
      <div
        class="detail-item flex-row"
        :class="{ active: item.Active }"
        v-for="item in category"
        :key="item.CategoryID"
      >
        <i
          class="icon"
          :class="item.ClassIcon"
          :title="item.CategoryName"
        ></i>
        <div class="text">{{ item.CategoryName }}</div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/navleft.scss";
</style>

<script>
import { mapState, mapActions } from "vuex";

export default {
  name: "TheNavLeft",
  components: {},
  props: {},
  data() {
    return {
      showNavLeft: true,
      module: "module_category",
    };
  },
  created() {
    this.getCategory();
  },
  computed: {
    ...mapState({
      category(state) {
        return state[this.module].category;
      },
      subCategory(state) {
        return state[this.module].subCategory;
      },
    }),
  },
  methods: {
    ...mapActions(["getCategory"]),

    toggleNavLeft() {
      this.showNavLeft = !this.showNavLeft;
    },
  },
};
</script>