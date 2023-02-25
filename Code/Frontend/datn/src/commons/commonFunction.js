const commonFn = {
  convertCourse(courses) {
    if (courses && Array.isArray(courses)) {
      courses.map((course) => {
        // Chương
        if (course.JsonChapters) {
          course.Chapters = JSON.parse(course.JsonChapters);
        } else {
          course.Chapters = [];
        }

        // Bài kiểm tra
        if (course.JsonQuestions) {
          let questions = JSON.parse(course.JsonQuestions);
          if (questions && Array.isArray(questions)) {
            questions.map((q) => {
              q.Answers = JSON.parse(q.Answers);
            });
          }
          course.Questions = questions;
        } else {
          course.Questions = [];
        }
      });
    }
    return courses;
  },
};

export default commonFn;
