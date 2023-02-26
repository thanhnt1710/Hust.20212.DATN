<template>
  <div
    class="navbar-left flex-column"
    :class="{ 'navbar-left-hide': !showNavLeft }"
  >
    <div class="title flex-row-between">
      <p>Danh mục khóa học</p>
      <!-- <i class="fa-solid fa-bars" @click="toggleNavLeft"></i> -->
    </div>
    <div class="detail">
      <div
        class="detail-item flex-row"
        v-for="item in category"
        :key="item.CategoryID"
        :ref="item.CategoryID ? 'category' + item.CategoryID : 'category'"
        @click="clickCategory(item.CategoryID)"
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
import { mapState, mapMutations, mapActions } from "vuex";
import commonFn from "@/commons/commonFunction.js";
import courseAPI from "@/apis/views/courseAPI";

export default {
  name: "TheNavLeft",
  components: {},
  props: {},
  data() {
    return {
      showNavLeft: true,
      module: "module_category",
      moduleCourse: "module_course",
    };
  },
  created() {
    this.getCategory();
  },
  computed: {
    ...mapState({
      category(state) {
        let category = JSON.parse(JSON.stringify(state[this.module].category));
        if (category && category[0] && category[0].CategoryID != null) {
          category.unshift({
            ClassIcon: "fas fa-globe-asia",
            CategoryID: null,
            CategoryName: "Tất cả",
          });
        }
        return category;
      },
      subCategory(state) {
        return state[this.module].subCategory;
      },
      paramGetCourse(state) {
        return state[this.moduleCourse].paramGetCourse;
      },
    }),
    context() {
      return JSON.parse(localStorage.getItem("context"));
    },
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
      setParamGetCourse: "setParamGetCourse",
      setCourses: "setCourses",
    }),
    ...mapActions(["getCategory"]),

    toggleNavLeft() {
      this.showNavLeft = !this.showNavLeft;
    },

    async clickCategory(categoryID) {
      const me = this;

      // Cập nhật UI
      let refs = me.$refs;
      for (var key in refs) {
        if (refs.hasOwnProperty(key)) {
          refs[key][0].className = "detail-item flex-row";
        }
      }
      let refName = `category${categoryID ? categoryID : ""}`;
      refs[refName][0].className = "detail-item flex-row detail-item-active";

      // Gọi Load Course
      let screenNameCurrent = me.$route.name;
      me.paramGetCourse.CategoryID = categoryID;
      if (me.context) {
        me.paramGetCourse.UserID =
          me.$app.config.ScreenNameLoadMyCourse.includes(screenNameCurrent)
            ? me.context.UserID
            : null;
      }

      me.setLoading(true);
      await courseAPI
        .getListCourse(me.paramGetCourse)
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