-- Run one query at a time in Microsoft Access SQL View.
SELECT A.ApplicationNo, S.StudentName, A.Status, A.RegistrationFee
FROM Applications AS A INNER JOIN Students AS S ON A.StudentId=S.StudentId;

SELECT A.ApplicationNo, H.Version, H.Status, H.Action, H.Reason, H.CreatedAt
FROM Applications AS A INNER JOIN ApplicationHistory AS H ON A.ApplicationId=H.ApplicationId
ORDER BY A.ApplicationNo, H.HistoryId;

SELECT S.StudentName, S.UniversityRollNo, C.RegistrationCode
FROM Students AS S INNER JOIN StudentCards AS C ON S.StudentId=C.StudentId;
