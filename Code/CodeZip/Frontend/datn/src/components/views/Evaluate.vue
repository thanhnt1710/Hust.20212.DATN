<template>
  <div
    class="evaluate flex-column scroll"
    :class="{ 'hide-evaluate': !showEvaluate }"
  >
    <div class="evaluate-header flex-row-between">
      <div class="title line-break-1" :title="infoCourse.CourseName">
        {{ "Đánh giá khóa học: " + infoCourse.CourseName }}
      </div>
      <i class="fas fa-times icon-close" title="Đóng" @click="hideEvaluate"></i>
    </div>
    <div class="evaluate-input-wrap">
      <div class="evaluate-input flex-row">
        <img src="../../assets/images/avatar.jpg" class="avatar" alt="" />
        <textarea
          ref="evaluateContent"
          rows="4"
          cols="50"
          maxLength="10000"
          class="flex-1"
          placeholder="Bạn có đánh giá gì về khóa học này?"
        ></textarea>
      </div>
      <base-button
        class="evaluate-btn flex-center btn-primary"
        textBtn="Đánh giá"
        @click="insertEvaluate"
      ></base-button>
    </div>
    <div class="evaluate-other">
      <div
        v-for="evaluate in evaluates"
        :key="evaluate.EvaluateID"
        class="evaluate-item flex-row"
      >
        <img src="../../assets/images/avatar.jpg" class="avatar" alt="" />
        <div class="evaluate-content-wrap flex-1">
          <div class="evaluate-content">
            <div class="user-name">{{ evaluate.UserName }}</div>
            <textarea
              v-model="evaluate.EvaluateContent"
              class="evaluate-text scroll"
              rows="4"
              cols="50"
              readonly="true"
            ></textarea>
          </div>
          <div class="evaluate-time flex-center">
            {{ evaluate.CreatedDateStr }}
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/evaluate.scss";
</style>

<script>
import Vue from "vue";
import { mapState, mapMutations, mapActions } from "vuex";
import evaluateAPI from "@/apis/views/evaluateAPI";

export default {
  name: "Evaluate",
  components: {},
  data() {
    return {
      moduleEvaluate: "module_evaluate",
    };
  },
  computed: {
    ...mapState({
      showEvaluate(state) {
        return state[this.moduleEvaluate].showEvaluate;
      },
      infoCourse(state) {
        return state[this.moduleEvaluate].infoCourse;
      },
      evaluates(state) {
        return state[this.moduleEvaluate].evaluates;
      },
    }),
  },
  watch: {
    showEvaluate: {
      handler: function (newValue, oldValue) {
        if (newValue) {
          this.getEvaluates();
        } else {
          this.$refs.evaluateContent.value = null;
        }
      },
    },
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
      setShowEvaluate: "setShowEvaluate",
    }),
    ...mapActions(["getEvaluates"]),
    hideEvaluate() {
      this.setShowEvaluate(false);
    },
    async insertEvaluate() {
      const me = this;
      let evaluateContent = me.$refs.evaluateContent.value;
      if (evaluateContent) {
        let payload = {
          CourseID: me.infoCourse.CourseID,
          UserID: JSON.parse(localStorage.getItem("context")).UserID,
          EvaluateContent: evaluateContent,
        };

        me.setLoading(true);
        await evaluateAPI
          .insertEvaluate(payload)
          .then((res) => {
            if (res && res.data && res.data.Success) {
              me.$refs.evaluateContent.value = null;
              Vue.$toast.success("Thêm đánh giá khoá học thành công!");
              me.getEvaluates();
            } else {
              Vue.$toast.error("Thêm đánh giá khoá học không thành công!");
            }
          })
          .catch((err) => {
            console.error(err);
            Vue.$toast.error("Thêm đánh giá khoá học không thành công!");
          })
          .finally(() => {
            me.setLoading(false);
          });
      }
    },
  },
};
</script>