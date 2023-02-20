<template>
  <div class="list-course">
    <div class="title">{{ titleList }}</div>
    <div class="content">
      <div v-for="course in courses" :key="course.ID" class="content-item">
        <course :course="course"></course>
      </div>
    </div>
  </div>
</template>

<style lang="scss" scoped>
@import '@/scss/views/list_course.scss';
</style>

<script>
import Course from "@/components/views/CourseBox.vue";

export default {
  name: "ListCourse",
  components: {
    Course,
  },
  props: {
    titleList: {
      type: String,
      required: true,
      default: null,
    },

    // Kiểu danh sách khóa khọc (Thịnh hành, Yêu thích, ...)
    type: {
      type: Number,
      default: null,
    },
  },
  data() {
    return {
      courses: [
        {
          ID: 1,
          CategoryName: "CNTT",
          CourseName: "Python cơ bản",
          Description:
            "Python là một ngôn ngữ lập trình bậc cao cho các mục đích lập trình đa năng. Python được thiết kế với ưu điểm mạnh là dễ đọc, dễ học và dễ nhớ. Python là ngôn ngữ có hình thức rất sáng sủa, cấu trúc rõ ràng, thuận tiện cho người mới học lập trình và là ngôn ngữ lập trình dễ học. Cấu trúc của Python còn cho phép người sử dụng viết mã lệnh với số lần gõ phím tối thiểu. Python vì vậy được dùng rộng rãi trong cộng đồng khoa học dữ liệu và đặc biệt là trong học máy và phát triển trí tuệ nhân tạo. Đến với khóa học này, các bạn sẽ được trang bị những kiến thức, kỹ năng và phương pháp lập trình sử dụng các tính năng cốt lõi của Python như cú pháp câu lệnh, biến và các kiểu dữ liệu cơ bản, vòng lặp, hàm dựng sẵn và nhiều tính năng khác. Đồng thời, các bạn sẽ tự tay viết và chạy chương trình của chính mình bằng những công cụ lập trình Python chuyên nghiệp như PyCharm và Google Colab.",
          AuthorName: "Nguyễn Đình Hoa Cương",
          SrcImage:
            "http://upload.wikimedia.org/wikipedia/commons/7/7a/Basketball.png",
        },
        {
          ID: 2,
          CategoryName: "Phát Triển Bản Thân",
          CourseName: "Ứng tuyển thành công - Phỏng vấn hiệu quả",
          Description:
            "Là khoá học được thiết kế dựa trên trình tự từ khi bắt đầu tìm kiếm công việc cho đến khi hoàn tất quy trình phỏng vấn, “Ứng tuyển thành công – Phỏng vấn hiệu quả” sẽ mang đến những kiến thức, kinh nghiệm mới, sát với thực tế của doanh nghiệp từ chuyên gia có uy tín trong lĩnh vực tuyển dụng & tìm kiếm nhân tài. Bạn sẽ có được những kiến thức & kỹ năng cần thiết cho quá trình ứng tuyển & phỏng vấn như xác định định hướng nghề nghiệp, chuẩn bị CV & Cover letter, trả lời phỏng vấn với mô hình STAR, lựa chọn trang phục chuyên nghiệp, đặt câu hỏi cho nhà tuyển dụng, tạo sự tự tin trong buổi phỏng vấn & những điều nên thực hiện sau phỏng vấn. Từ đó, bạn có thể gia tăng cơ hội thành công khi ứng tuyển vị trí công việc mong muốn.",
          AuthorName: "Bùi Thị Kim Dung",
          SrcImage:
            "http://upload.wikimedia.org/wikipedia/commons/7/7a/Basketball.png",
        },
        {
          ID: 3,
          CategoryName: "Thiết kế",
          CourseName: "Học After Effects & Premiere Pro trọn bộ",
          Description:
            "Khóa học thiết kế Adobe này trang bị cho học viên các thao tác trên After Effect và Adobe Premiere. After Effect là một phần mềm của Adobe chuyên về xử lý video, được ví như Photoshop của video trong khi Adobe Premiere là một phần mềm của Adobe chuyên về cắt ghép, sắp xếp, thao tác các đoạn video để có được một video hoàn chỉnh.",
          AuthorName: "Nguyễn Đức Việt",
          SrcImage:
            "http://upload.wikimedia.org/wikipedia/commons/7/7a/Basketball.png",
        },
        {
          ID: 3,
          CategoryName: "Thiết kế",
          CourseName: "Học After Effects & Premiere Pro trọn bộ",
          Description:
            "Khóa học thiết kế Adobe này trang bị cho học viên các thao tác trên After Effect và Adobe Premiere. After Effect là một phần mềm của Adobe chuyên về xử lý video, được ví như Photoshop của video trong khi Adobe Premiere là một phần mềm của Adobe chuyên về cắt ghép, sắp xếp, thao tác các đoạn video để có được một video hoàn chỉnh.",
          AuthorName: "Nguyễn Đức Việt",
          SrcImage:
            "http://upload.wikimedia.org/wikipedia/commons/7/7a/Basketball.png",
        },
        {
          ID: 3,
          CategoryName: "Thiết kế",
          CourseName: "Học After Effects & Premiere Pro trọn bộ",
          Description:
            "Khóa học thiết kế Adobe này trang bị cho học viên các thao tác trên After Effect và Adobe Premiere. After Effect là một phần mềm của Adobe chuyên về xử lý video, được ví như Photoshop của video trong khi Adobe Premiere là một phần mềm của Adobe chuyên về cắt ghép, sắp xếp, thao tác các đoạn video để có được một video hoàn chỉnh.",
          AuthorName: "Nguyễn Đức Việt",
          SrcImage:
            "http://upload.wikimedia.org/wikipedia/commons/7/7a/Basketball.png",
        },
      ],
    };
  },
};
</script>