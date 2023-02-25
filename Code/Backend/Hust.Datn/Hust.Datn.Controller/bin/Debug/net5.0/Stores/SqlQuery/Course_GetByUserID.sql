
-- Trường nào truyền Null thì không lọc (không where)
-- SET @CategoryID = NULL;
-- SET @InputFilter = NULL;
-- SET @UserID = NULL;

SELECT
  EXISTS (SELECT
      1
    FROM User u
    WHERE u.UserID = @UserID) INTO @ExistUser;

DROP TEMPORARY TABLE IF EXISTS tempChapter;
CREATE TEMPORARY TABLE tempChapter AS (SELECT
    c.ChapterID,
    c.ChapterName,
    c.CourseID,
    c.ChapterPrevID,
    JSON_ARRAYAGG(JSON_OBJECT('LessonID', l.LessonID, 'LessonName', l.LessonName,
    'LessonPrevID', l.LessonPrevID, 'ChapterID', l.ChapterID, 'CourseID', l.CourseID,
    'FileID', l.FileID, 'FileName', l.FileName, 'VideoID', l.VideoID, 'VideoName', l.VideoName
    )) AS Lessons
  FROM Chapter c
    LEFT JOIN Lesson l
      ON c.ChapterID = l.ChapterID
  GROUP BY c.ChapterID);

SELECT
  a.*,
  b.JsonQuestions
FROM (SELECT
    a.CourseID,
    a.CourseName,
    a.CourseDescription,
    a.CategoryID,
    a.SubCategoryID,
    a.SubCategoryName,
    a.UserID,
    a.AuthorName,
    a.CategoryName,
    a.CreatedBy,
    a.ModifiedBy,
    a.CreatedDate,
    a.ModifiedDate,
    JSON_ARRAYAGG(a.JsonChapter) AS JsonChapters
  FROM (SELECT
      ROW_NUMBER() OVER (
      ORDER BY tc.ChapterID) AS SortChapter,
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
      JSON_OBJECT('ChapterID', tc.ChapterID, 'ChapterName',
      tc.ChapterName, 'CourseID', tc.CourseID, 'ChapterPrevID',
      tc.ChapterPrevID, 'Lessons', tc.Lessons) AS JsonChapter
    FROM Course c
      LEFT JOIN tempChapter tc
        ON c.CourseID = tc.CourseID
      INNER JOIN User u
        ON c.UserID = u.UserID
      INNER JOIN Category ca
        ON c.CategoryID = ca.CategoryID
      INNER JOIN SubCategory sc
        ON c.SubCategoryID = sc.SubCategoryID
    WHERE IF(@CategoryID IS NOT NULL, c.CategoryID = @CategoryID, 1 = 1)
    AND IF(@InputFilter IS NOT NULL, c.CourseName LIKE CONCAT('%', @InputFilter, '%'), 1 = 1)
    AND IF(@UserID IS NOT NULL, c.UserID = @UserID, 1 = 1)) AS a
  GROUP BY a.CourseID) AS a
  INNER JOIN (SELECT
      c.CourseID,
      IF(q.QuestionID, JSON_ARRAYAGG(JSON_OBJECT('QuestionID', q.QuestionID,
      'QuestionStr', q.QuestionStr, 'CourseID', q.CourseID,
      'Answers', q.Answers, 'QuestionResult', IF(@ExistUser, q.QuestionResult, 0))), NULL) AS JsonQuestions
    FROM Course c
      INNER JOIN User u
        ON c.UserID = u.UserID
      LEFT JOIN Question q
        ON c.CourseID = q.CourseID
    WHERE IF(@CategoryID IS NOT NULL, c.CategoryID = @CategoryID, 1 = 1)
    AND IF(@InputFilter IS NOT NULL, c.CourseName LIKE CONCAT('%', @InputFilter, '%'), 1 = 1)
    AND IF(@UserID IS NOT NULL, c.UserID = @UserID, 1 = 1)
    GROUP BY c.CourseID) AS b
    ON a.CourseID = b.CourseID