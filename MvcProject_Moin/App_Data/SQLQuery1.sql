Create Table Class
(
ClassID int Primary Key Identity,
ClassName varchar(20)
)

Create Table Student
(
StudentID int Primary Key Identity,
StudentName varchar(30),
FatherName varchar(30),
DOB date,
StudentImage  varchar(100),
ContactNo varchar(15),
Address varchar(100),
Email varchar(20),
ClassID  int Foreign Key References  Class(ClassID )
)

Create Table Teacher
(
TeacherID int Primary Key Identity,
TeacherName varchar(20),
DOB date,
ContactNo varchar(15),
Address varchar(100),
Email varchar(20)
)