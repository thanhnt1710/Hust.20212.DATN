-- UPDATE User u
-- SET u.IsLearn = 0
-- WHERE NOT EXISTS (SELECT
--     c.CourseID
--   FROM Course c
--   WHERE c.CourseID = @CourseID
--   AND c.UserID = @UserID)

SELECT
  (SELECT
      COUNT(u.UserID)
    FROM User u) AS CountUser,
  (SELECT
      COUNT(c.CourseID)
    FROM Course c) AS CountCourse,
  (SELECT
      COUNT(c.ChapterID)
    FROM Chapter c) AS CountChapter,
  (SELECT
      COUNT(l.LessonID)
    FROM Lesson l) AS CountLesson,
  (SELECT
      JSON_ARRAYAGG(a.CountCourse)
    FROM (SELECT
        ca.CategoryID,
        ca.CategoryName,
        COUNT(c.CourseName) AS CountCourse
      FROM Category ca
        LEFT JOIN Course c
          ON c.CategoryID = ca.CategoryID
      GROUP BY ca.CategoryID) AS a) AS StatisticCourse,
  (SELECT
      JSON_ARRAYAGG(a.CountUser)
    FROM (SELECT
        COUNT(DISTINCT u.UserID) AS CountUser
      FROM User u
        LEFT JOIN Course c
          ON u.UserID = c.UserID
      WHERE u.IsLearn = 0
      AND c.CourseID IS NULL
      UNION ALL
      SELECT
        COUNT(DISTINCT u.UserID) AS CountUser
      FROM User u
        LEFT JOIN Course c
          ON u.UserID = c.UserID
      WHERE u.IsLearn = 0
      AND c.CourseID IS NOT NULL
      UNION ALL
      SELECT
        COUNT(DISTINCT u.UserID) AS CountUser
      FROM User u
        LEFT JOIN Course c
          ON u.UserID = c.UserID
      WHERE u.IsLearn = 1
      AND c.CourseID IS NULL
      UNION ALL
      SELECT
        COUNT(DISTINCT u.UserID) AS CountUser
      FROM User u
        LEFT JOIN Course c
          ON u.UserID = c.UserID
      WHERE u.IsLearn = 1
      AND c.CourseID IS NOT NULL) AS a) AS StatisticUser;


