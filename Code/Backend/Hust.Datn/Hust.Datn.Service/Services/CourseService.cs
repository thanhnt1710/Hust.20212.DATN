using Dapper;
using Hust.Datn.Service.Const;
using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        #region Declare
        protected readonly ICourseRepo _courseRepo;
        #endregion

        #region Constructor
        public CourseService(ICourseRepo courseRepo, IFileSystemService fileSystemService, IConfiguration configuration) : base(courseRepo, fileSystemService, configuration)
        {
            _courseRepo = courseRepo;
        }

        #endregion

        #region Methods
        public async Task<ServiceResult> SaveCourse(Course course)
        {
            var result = new ServiceResult();
            IDbTransaction tran = null;
            var cnn = _dbConnection;
            cnn.Open();

            using (tran = cnn.BeginTransaction())
            {
                try
                {
                    var resultInsert = false;
                    var sqlInsert = new StringBuilder();
                    var paramInsert = new Dictionary<string, object>();
                    var countInsert = 0;

                    // Xóa trước khi insert
                    paramInsert.Add("CourseID", course.CourseID);
                    await cnn.ExecuteAsync("DELETE FROM Course WHERE CourseID = @CourseID;", paramInsert, tran);

                    // Insert khóa học
                    var sqlInsertCourse = @"INSERT INTO Course (CourseID, CourseName, CourseDescription, CategoryID, SubCategoryID, UserID, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                                                VALUES (@CourseID, @CourseName, @CourseDescription, @CategoryID, @SubCategoryID, @UserID, @CreatedBy, '', NOW(), NOW());";
                    sqlInsert.Append(sqlInsertCourse);
                    countInsert++;
                    paramInsert.Add("CourseName", course.CourseName);
                    paramInsert.Add("CourseDescription", course.CourseDescription);
                    paramInsert.Add("CategoryID", course.CategoryID);
                    paramInsert.Add("SubCategoryID", course.SubCategoryID);
                    paramInsert.Add("UserID", course.UserID);
                    paramInsert.Add("CreatedBy", course.CreatedBy);

                    // Insert chương
                    if (course.Chapters != null)
                    {
                        for (int i = 0; i < course.Chapters.Count; i++)
                        {
                            var chapter = course.Chapters[i];

                            var sqlInsertChapter = @$"INSERT INTO Chapter (ChapterID, ChapterName, CourseID, ChapterPrevID)
                                                              VALUES (@C_ChapterID_{i}, @C_ChapterName_{i}, @C_CourseID_{i}, @C_ChapterPrevID_{i});";
                            sqlInsert.Append(sqlInsertChapter);
                            countInsert++;
                            paramInsert.Add($"C_ChapterID_{i}", chapter.ChapterID);
                            paramInsert.Add($"C_ChapterName_{i}", chapter.ChapterName);
                            paramInsert.Add($"C_CourseID_{i}", chapter.CourseID);
                            paramInsert.Add($"C_ChapterPrevID_{i}", chapter.ChapterPrevID);

                            // Insert bài
                            if (chapter.Lessons != null)
                            {
                                for (int k = 0; k < chapter.Lessons.Count; k++)
                                {
                                    var lesson = chapter.Lessons[k];

                                    var sqlInsertLesson = $@"INSERT INTO Lesson (LessonID, LessonName, LessonPrevID, ChapterID, CourseID, FileID, FileName, VideoID, VideoName, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                                                                VALUES (@L_LessonID_{i}_{k}, @L_LessonName_{i}_{k}, @L_LessonPrevID_{i}_{k}, @L_ChapterID_{i}_{k}, @L_CourseID_{i}_{k}, @L_FileID_{i}_{k}, @L_FileName_{i}_{k}, @L_VideoID_{i}_{k}, @L_VideoName_{i}_{k}, '', '', NOW(), NOW());";
                                    sqlInsert.Append(sqlInsertLesson);
                                    countInsert++;
                                    paramInsert.Add($"L_LessonID_{i}_{k}", lesson.LessonID);
                                    paramInsert.Add($"L_LessonName_{i}_{k}", lesson.LessonName);
                                    paramInsert.Add($"L_LessonPrevID_{i}_{k}", lesson.LessonPrevID);
                                    paramInsert.Add($"L_ChapterID_{i}_{k}", lesson.ChapterID);
                                    paramInsert.Add($"L_CourseID_{i}_{k}", lesson.CourseID);
                                    paramInsert.Add($"L_FileID_{i}_{k}", lesson.FileID);
                                    paramInsert.Add($"L_FileName_{i}_{k}", lesson.FileName);
                                    paramInsert.Add($"L_VideoID_{i}_{k}", lesson.VideoID);
                                    paramInsert.Add($"L_VideoName_{i}_{k}", lesson.VideoName);
                                }
                            }
                        }
                    }

                    // Insert bài kiểm tra
                    if(course.Questions != null)
                    {
                        for (int i = 0; i < course.Questions.Count; i++)
                        {
                            var question = course.Questions[i];
                            var sqlInsertQuestion = $@"INSERT INTO Question (QuestionID, QuestionStr, CourseID, Type, Answers, QuestionResult)
                                                        VALUES (@Q_QuestionID_{i}, @Q_QuestionStr_{i}, @Q_CourseID_{i}, 1, @Q_Answers_{i}, @Q_QuestionResult_{i});";
                            sqlInsert.Append(sqlInsertQuestion);
                            countInsert++;
                            paramInsert.Add($"Q_QuestionID_{i}", question.QuestionID);
                            paramInsert.Add($"Q_QuestionStr_{i}", question.QuestionStr);
                            paramInsert.Add($"Q_CourseID_{i}", question.CourseID);
                            paramInsert.Add($"Q_Answers_{i}", JsonSerializer.Serialize(question.Answers));
                            paramInsert.Add($"Q_QuestionResult_{ i}", question.QuestionResult);
                        }
                    }

                    var effectRow = await cnn.ExecuteAsync(sqlInsert.ToString(), paramInsert, tran);
                    if (effectRow == countInsert)
                    {
                        result.Data = true;
                        tran.Commit();
                    }
                    else
                    {
                        result.Success = false;
                        tran.Rollback();
                    }
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Data = false;
                    result.DevMsg = e.Message;
                    tran.Rollback();
                }
            }
            _dbConnection.Close();

            return result;
        }

        public async Task<ServiceResult> RemoveCourse(Guid id)
        {
            var result = new ServiceResult();
            var sql = @"DELETE FROM Course WHERE CourseID = @CourseID;";
            var param = new
            {
                CourseID = id
            };
            result.Success = await _courseRepo.RemoveCourse(sql, param);

            return result;
        }

        public async Task<ServiceResult> GetMaxID()
        {
            var result = new ServiceResult();
            var maxID = new MaxID();

            var sql = @"SELECT
                        MAX(c.ChapterID) ChapterID,
                        MAX(l.LessonID) LessonID
                    FROM Chapter c
                        LEFT JOIN Lesson l
                        ON c.ChapterID = l.ChapterID;";
            maxID = await _courseRepo.GetMaxID(sql);
            maxID.CourseID = Guid.NewGuid();
            result.Data = maxID;

            return result;
        }

        public async Task<ServiceResult> GetListCourse(ParamGetCourse paramGetCourse)
        {
            var result = new ServiceResult();

            var sql = await _fileSystemService.GetFileString(FileType.SqlQuery, "Course_GetListCourse.sql");
            result.Data = await _courseRepo.GetListCourse(sql, paramGetCourse);

            return result;
        }

        public async Task<ServiceResult> GetDataStatistic()
        {
            var result = new ServiceResult();

            var sql = await _fileSystemService.GetFileString(FileType.SqlQuery, "Statistic_GetData.sql");
            result.Data = await _courseRepo.GetDataStatistic(sql);

            return result;
        }
        #endregion
    }
}
