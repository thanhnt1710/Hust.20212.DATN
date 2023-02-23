<template>
  <div class="question">
    <div class="question-string">
      <base-input
        v-model="value.QuestionStr"
        maxLength="1000"
        classInput=""
        placeholder="Nhập câu hỏi"
      ></base-input>
    </div>
    <div class="answers">
      <div class="answer-item">
        <input
          type="radio"
          v-model="value.QuestionResult"
          :name="value.QuestionID"
          :value="value.Answers[0].Answer"
          @change="changeAnswer(value.Answers[0].Answer)"
        />
        <base-input
          v-model="value.Answers[0].Question"
          maxLength="1000"
          classInput=""
          placeholder="Nhập câu trả lời"
        ></base-input>
      </div>
      <div class="answer-item">
        <input
          type="radio"
          v-model="value.QuestionResult"
          :name="value.QuestionID"
          :value="value.Answers[1].Answer"
          @change="changeAnswer(value.Answers[1].Answer)"
        />
        <base-input
          v-model="value.Answers[1].Question"
          maxLength="1000"
          classInput=""
          placeholder="Nhập câu trả lời"
        ></base-input>
      </div>
      <div class="answer-item">
        <input
          type="radio"
          v-model="value.QuestionResult"
          :name="value.QuestionID"
          :value="value.Answers[2].Answer"
          @change="changeAnswer(value.Answers[2].Answer)"
        />
        <base-input
          v-model="value.Answers[2].Question"
          maxLength="1000"
          classInput=""
          placeholder="Nhập câu trả lời"
        ></base-input>
      </div>
      <div class="answer-item">
        <input
          type="radio"
          v-model="value.QuestionResult"
          :name="value.QuestionID"
          :value="value.Answers[3].Answer"
          @change="changeAnswer(value.Answers[3].Answer)"
        />
        <base-input
          v-model="value.Answers[3].Question"
          maxLength="1000"
          classInput=""
          placeholder="Nhập câu trả lời"
        ></base-input>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/question.scss";
</style>

<script>
import Vue from "vue";

export default {
  name: "Question",
  components: {},
  props: {
    value: {
      default: {},
    },
  },
  data() {
    return {
      internalQuestion: this.value,
    };
  },
  watch: {
    internalQuestion: {
      handler: function (newValue, oldValue) {
        this.$emit("input", newValue);
      },
      immediate: true,
      deep: true
    },
    value: {
      handler: function (newValue, oldValue) {
        this.internalQuestion = newValue;
      },
      immediate: true,
    },
  },
  methods: {
    changeAnswer(value) {
        this.internalQuestion.QuestionResult = value;
        this.$emit("input", this.internalQuestion);
    }
  },
};
</script>