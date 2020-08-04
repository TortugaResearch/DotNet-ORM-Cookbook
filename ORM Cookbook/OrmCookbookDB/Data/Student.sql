
GO
DECLARE @Student TABLE
(
    StudentId INT NOT NULL,
    Name NVARCHAR(50) NOT NULL,
    Subject NVARCHAR(50) NOT NULL,
    SchoolId INT NOT NULL
);

INSERT INTO @Student
(
    StudentId,
    Name,
    Subject,
    SchoolId
)
VALUES
(1, 'n1', 's1', 1),
(2, 'n2', 's2', 1),
(3, 'n3', 's3', 2),
(4, 'n4', 's4', 2);

SET IDENTITY_INSERT School.Student ON;

MERGE INTO School.Student t
USING @Student s
ON s.StudentId = t.StudentId
WHEN NOT MATCHED THEN
    INSERT
    (
        StudentId,
        Name,
        Subject,
        SchoolId
    )
    VALUES
    (s.StudentId, s.Name, s.Subject, s.SchoolId)
WHEN MATCHED THEN
    UPDATE SET Name = s.Name,
               Subject = s.Subject,
               SchoolId = s.SchoolId
WHEN NOT MATCHED BY SOURCE THEN
    DELETE;

SET IDENTITY_INSERT School.Student OFF;