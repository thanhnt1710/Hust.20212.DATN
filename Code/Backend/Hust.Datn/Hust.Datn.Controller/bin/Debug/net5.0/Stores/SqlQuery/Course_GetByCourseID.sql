-- SET @ID = 'b0798db8-b074-11ed-9343-d8d0903201c1';
DROP TEMPORARY TABLE IF EXISTS tempChapter;
CREATE TEMPORARY TABLE tempChapter AS (SELECT
    c.ChapterID,
    c.ChapterName,
    c.CourseID,
    c.ChapterPrevID,
    JSON_ARRAYAGG(JSON_OBJECT('LessonID', l.LessonID, 'LessonName', l.LessonName,
    'LessonPrevID', l.LessonPrevID, 'ChapterID', l.ChapterID, 'CourseID', l.CourseID,
    'FileID', l.FileID, 'VideoID', l.VideoID, 'IsMixQuestion', l.IsMixQuestion
    )) AS Lessons
  FROM Chapter c
    LEFT JOIN Lesson l
      ON c.ChapterID = l.ChapterID
  GROUP BY c.ChapterID);

SELECT
  a.*,
  b.JsonQuestions
FROM (SELECT
    c.CourseID,
    c.CourseName,
    c.CourseDescription,
    c.CategoryID,
    c.SubCategoryID,
    sc.SubCategoryName,
    c.UserID,
    u.FullName AS AuthorName,
    ca.CategoryName,
    c.CreatedBy,
    c.ModifiedBy,
    c.CreatedDate,
    c.ModifiedDate,
    JSON_ARRAYAGG(JSON_OBJECT('ChapterID', tc.ChapterID, 'ChapterName',
    tc.ChapterName, 'CourseID', tc.CourseID, 'ChapterPrevID',
    tc.ChapterPrevID, 'Lessons', tc.Lessons)) AS JsonChapters
  FROM Course c
    LEFT JOIN tempChapter tc
      ON c.CourseID = tc.CourseID
    INNER JOIN User u
      ON c.UserID = u.UserID
    INNER JOIN Category ca
      ON c.CategoryID = ca.CategoryID
    INNER JOIN SubCategory sc
      ON c.SubCategoryID = sc.SubCategoryID
  WHERE c.CourseID = @ID
  GROUP BY c.CourseID) AS a
  INNER JOIN (SELECT
      c.CourseID,
      IF(q.QuestionID, JSON_ARRAYAGG(JSON_OBJECT('QuestionID', q.QuestionID,
      'QuestionStr', q.QuestionStr, 'CourseID', q.CourseID,
      'Answers', q.Answers)), NULL) AS JsonQuestions
    FROM Course c
      LEFT JOIN Question q
        ON c.CourseID = q.CourseID
    WHERE c.CourseID = @ID
    GROUP BY c.CourseID) AS b
    ON a.CourseID = b.CourseID