select Student.Student_No, Student.SName, Leasing.Leasing_No,
Room.Room_No, Room.Dormitory_No, Room.Appart_No
from Student
join Leasing on Student.Student_No = Leasing.Student_No
join Room on Leasing.Place_No = Room.Place_No
where Student.Student_No = 1