<template>
  <div
    class="question"
    :class="{
      'question-correct': correctAnswer,
      'question-wrong': correctAnswer === false,
    }"
  >
    <div class="question-string flex-row-between">
      <base-input
        v-model="value.QuestionStr"
        maxLength="1000"
        classInput="flex-1"
        placeholder="Nhập câu hỏi"
        :readonly="readonly"
      ></base-input>
      <i
        v-if="!readonly"
        class="fas fa-eraser remove-question"
        title="Xóa câu hỏi"
        @click="removeQuestion"
      ></i>
    </div>
    <div class="answers">
      <div class="answer-item flex-row-between">
        <input
          type="radio"
          v-model="value.QuestionResult"
          class="check-radio"
          :name="value.QuestionID"
          :value="value.Answers[0].Answer"
          @change="changeAnswer(value.Answers[0].Answer)"
        />
        <base-input
          v-model="value.Answers[0].Question"
          maxLength="1000"
          classInput="flex-1"
          placeholder="Nhập câu trả lời"
          :readonly="readonly"
        ></base-input>
      </div>
      <div class="answer-item flex-row-between">
        <input
          type="radio"
          v-model="value.QuestionResult"
          class="check-radio"
          :name="value.QuestionID"
          :value="value.Answers[1].Answer"
          @change="changeAnswer(value.Answers[1].Answer)"
        />
        <base-input
          v-model="value.Answers[1].Question"
          maxLength="1000"
          classInput="flex-1"
          placeholder="Nhập câu trả lời"
          :readonly="readonly"
        ></base-input>
      </div>
      <div class="answer-item flex-row-between">
        <input
          type="radio"
          v-model="value.QuestionResult"
          class="check-radio"
          :name="value.QuestionID"
          :value="value.Answers[2].Answer"
          @change="changeAnswer(value.Answers[2].Answer)"
        />
        <base-input
          v-model="value.Answers[2].Question"
          maxLength="1000"
          classInput="flex-1"
          placeholder="Nhập câu trả lời"
          :readonly="readonly"
        ></base-input>
      </div>
      <div class="answer-item flex-row-between">
        <input
          type="radio"
          v-model="value.QuestionResult"
          class="check-radio"
          :name="value.QuestionID"
          :value="value.Answers[3].Answer"
          @change="changeAnswer(value.Answers[3].Answer)"
        />
        <base-input
          v-model="value.Answers[3].Question"
          maxLength="1000"
          classInput="flex-1"
          placeholder="Nhập câu trả lời"
          :readonly="readonly"
        ></base-input>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
.question-correct {
  border: 1px solid green !important;
}
.question-wrong {
  border: 1px solid red !important;
}
.question {
  border: 1px solid #bbbbbb;
  border-radius: 4px;
  padding: 10px;
  margin-bottom: 18px;
  background-color: white;
  .question-string {
    .remove-question {
      cursor: pointer;
      font-size: 24px;
      width: 26px;
      color: red;
      margin-left: 12px;
    }
  }
  .answers {
    .answer-item {
      margin: 10px;
      .check-radio {
        margin-right: 10px;
      }
    }
  }
}
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
    readonly: {
      type: Boolean,
      default: false,
    },
  },
  data() {
    return {
      internalQuestion: this.value,
      correctAnswer: null,
    };
  },
  watch: {
    internalQuestion: {
      handler: function (newValue, oldValue) {
        this.$emit("input", newValue);
      },
      immediate: true,
      deep: true,
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
    },

    removeQuestion() {
      this.$emit("removeQuestion");
    },
    setCorrectAnswer(value) {
      this.correctAnswer = value;
    },
  },
};
</script>