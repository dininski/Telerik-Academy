namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Student
    {
        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException("You must specify a first name!");
            }

            if (lastName == null)
            {
                throw new ArgumentNullException("You must specify a last name!");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null)
            {
                throw new ArgumentNullException("The exams must be initialized!");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArgumentNullException("There must be at least one exam!");
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null)
            {
                throw new ArgumentNullException("The exams must be initialized!");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArgumentNullException("There must be at least one exam!");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}