(function () {
    "use strict";

    var Person = {
        init: function (fName, lName, age) {
            this.fName = fName;
            this.lName = lName;
            this.age = age;
        },
        introduce: function () {
            return "Name: " + this.fName + " " + this.lName + " Age: " + this.age;
        }
    }

    var Student = Person.extend({
        init: function (fname, lname, age, grade) {
            this._super = Object.create(this._super);
            this._super.init(fname, lname, age);
            this.grade = grade;
        },
        introduce: function () {
            return this._super.introduce() + " Grade: " + this.grade;
        }
    });

    var Teacher = Person.extend({
        init: function (fname, lname, age, specialty) {
            this._super = Object.create(this._super);
            this._super.init(fname, lname, age);
            this.specialty = specialty;
        },
        introduce: function () {
            return this._super.introduce() + " Speciality: " + this.specialty;
        }
    });

    var Course = {
        init: function (name, teacher, students, capacity) {
            this.name = name;
            this.teacher = teacher;
            this.students = students;
            this.capacity = capacity;
        },
        introduce: function () {
            var introduction = "Course: " + this.name +
                ", Teacher: " + this.teacher.introduce() +
                ", Students: ";
            for (var i = 0; i < this.students.length; i++) {
                introduction += this.students[i].introduce() + ", ";
            }

            introduction = introduction.substr(0, introduction.length - 2);
            introduction += " Maximum capacity: " + this.capacity;

            return introduction;
        }
    }

    var School = {
        init: function (name, town, courses) {
            this.name = name;
            this.town = town;
            this.courses = courses;
        },
        introduce: function () {
            var introduction = "School name: " + this.name +
                " Town: " + this.town +
                " Courses: ";
            for (var i = 0; i < this.courses.length; i++) {
                introduction += this.courses[i].introduce() + ", ";
            }

            return introduction.substr(0, introduction.length - 2);;
        }
    }

    var studentIvan = Object.create(Student);
    studentIvan.init("Ivan", "Ivanov", 22, "B+");
    console.log(studentIvan.introduce());

    var studentDragan = Object.create(Student);
    studentDragan.init("Dragan", "Draganov", 25, "C-");
    console.log(studentDragan.introduce());

    var nakov = Object.create(Teacher);
    nakov.init("Svetlin", "Nakov", 99, "Farming");
    console.log(nakov.introduce());

    var classOfStudents = [];
    classOfStudents.push(studentIvan);
    classOfStudents.push(studentDragan);

    var jsCourse = Object.create(Course);
    jsCourse.init("C#", nakov, classOfStudents, 20);
    console.log(jsCourse.introduce());

    var fmi = Object.create(School);
    fmi.init("FMI", "Sofia", [jsCourse]);
    console.log(fmi.introduce());
})();