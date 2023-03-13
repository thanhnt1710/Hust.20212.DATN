<template>
  <div class="statistic flex-column">
    <div class="total flex-row flex-center">
      <div class="total-item total-user">
        Tổng số người dùng: {{ dataStatistic.CountUser }}
      </div>
      <div class="total-item total-course">
        Tổng số khóa học: {{ dataStatistic.CountCourse }}
      </div>
      <div class="total-item total-chapter">
        Tổng số chương: {{ dataStatistic.CountChapter }}
      </div>
      <div class="total-item total-lesson">
        Tổng số bài giảng: {{ dataStatistic.CountLesson }}
      </div>
    </div>
    <div class="detail flex-row-between">
      <div class="course flex-1 flex-column flex-center h-100">
        <div class="course-title">Thống kê khóa học theo danh mục</div>
        <div class="course-chart flex-center">
          <Bar
            :data="chartDataCourse"
            :chart-options="chartOptions"
            :chart-data="chartDataCourse"
            chart-id="course-chart"
            dataset-id-key="label"
            width="300"
          />
        </div>
      </div>
      <div class="user flex-1 flex-column flex-center h-100">
        <div class="user-title">Thống kê tình hình người dùng sử dụng</div>
        <div class="user-chart flex-center">
          <Pie
            :data="chartDataUser"
            :chart-options="chartOptions"
            :chart-data="chartDataUser"
            chart-id="user-chart"
            dataset-id-key="label"
            :height="300"
            :width="300"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import "@/scss/views/statistic.scss";
</style>

<script>
import Vue from "vue";
import { mapState, mapMutations, mapActions } from "vuex";
import { Bar } from "vue-chartjs";
import { Pie } from "vue-chartjs";
import {
  Chart as ChartJS,
  Title,
  Tooltip,
  Legend,
  BarElement,
  CategoryScale,
  LinearScale,
  ArcElement,
} from "chart.js";
ChartJS.register(
  Title,
  Tooltip,
  Legend,
  BarElement,
  CategoryScale,
  LinearScale,
  ArcElement
);
import commonFn from "@/commons/commonFunction.js";
import courseAPI from "@/apis/views/courseAPI";

export default {
  name: "Statistic",
  components: {
    Bar,
    Pie,
  },
  props: {},
  data() {
    return {
      dataStatistic: null,
      chartOptions: {
        responsive: true,
        maintainAspectRatio: false,
      },
    };
  },
  async created() {
    await this.getDataStatistic();
  },
  computed: {
    ...mapState({}),
    chartDataCourse() {
      let result = null;
      if (this.dataStatistic) {
        let data = JSON.parse(this.dataStatistic.StatisticCourse);
        result = {
          labels: [
            "Sales - CSKH",
            "Kỹ năng công việc",
            "Kỹ năng con người",
            "Kỹ năng quản trị",
            "Ngoại ngữ",
            "Thiết kế đồ hoạ",
            "Ứng dụng Phần mềm",
            "Phát triển cá nhân",
            "Marketing và truyền thông",
            "Kinh doanh - Khởi nghiệp",
            "Lập trình - CNTT",
            "Hành chính Nhân sự",
            "Tài chính - Kế toán",
          ],
          datasets: [
            {
              label: "Số lượng khóa học",
              backgroundColor: "#c38d9e",
              data: data,
            },
          ],
        };
      }
      return result;
    },
    chartDataUser() {
      let result = null;
      if (this.dataStatistic) {
        let data = JSON.parse(this.dataStatistic.StatisticUser);
        result = {
          labels: [
            "Không tham gia học, không tạo khóa học",
            "Không tham gia học, có tạo khóa học",
            "Tham gia học, không tạo khóa học",
            "Tham gia học, có tạo khóa học",
          ],
          datasets: [
            {
              backgroundColor: ["#7030a0", "#ff6d00", "#00c853", "#ffff00"],
              data: data,
            },
          ],
        };
      }
      return result;
    },
  },
  methods: {
    ...mapMutations({
      setLoading: "setLoading",
    }),

    async getDataStatistic() {
      const me = this;

      me.setLoading(true);
      await courseAPI
        .getDataStatistic()
        .then((res) => {
          if (res && res.data && res.data.Success) {
            this.dataStatistic = res.data.Data;
          } else {
            Vue.$toast.error("Lấy dữ liệu thống kê không thành công!");
          }
        })
        .catch((err) => {
          console.log(err);
          Vue.$toast.error("Lấy dữ liệu thống kê không thành công!");
        })
        .finally(() => {
          me.setLoading(false);
        });
    },
  },
};
</script>