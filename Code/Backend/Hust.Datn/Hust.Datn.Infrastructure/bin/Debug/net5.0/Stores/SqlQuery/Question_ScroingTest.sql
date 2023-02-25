-- SET @Question = '[{"Answers":[{"Question":"AA","Answer":1},{"Question":"BB","Answer":2},{"Question":"CC","Answer":3},{"Question":"DD","Answer":4}],"CourseID":"b3242692-a7a0-4db4-98b2-4d783fa5816d","QuestionID":1,"QuestionStr":"Câu 1","QuestionResult":2},{"Answers":[{"Question":"DA","Answer":1},{"Question":"CB","Answer":2},{"Question":"BC","Answer":3},{"Question":"AD","Answer":4}],"CourseID":"b3242692-a7a0-4db4-98b2-4d783fa5816d","QuestionID":2,"QuestionStr":"Câu 2","QuestionResult":2}]';

DROP TEMPORARY TABLE IF EXISTS tempQuestion;
CREATE TEMPORARY TABLE tempQuestion SELECT
  a.*
FROM JSON_TABLE (@JsonQuestions, '$[*]' COLUMNS (
QuestionID int PATH '$.QuestionID',
CourseID char(36) PATH '$.CourseID',
QuestionResult int PATH '$.QuestionResult'
)) AS a;

SELECT
  q.QuestionID,
  IF(t.QuestionResult = q.QuestionResult, TRUE, FALSE) AS CorrectAnswer
FROM tempQuestion t
  INNER JOIN Question q
    ON q.QuestionID = t.QuestionID;