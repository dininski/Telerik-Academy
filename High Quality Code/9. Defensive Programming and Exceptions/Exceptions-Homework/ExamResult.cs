namespace ExceptionsHomework
{
    using System;

    public class ExamResult
    {
        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (grade < 0)
            {
                throw new ArgumentOutOfRangeException("The grade cannot be less than 0!");
            }

            if (minGrade < 0)
            {
                throw new ArgumentOutOfRangeException("The minimum grade for the exam cannot be less than 0!");
            }

            if (maxGrade <= minGrade)
            {
                throw new ArgumentException("The maximum grade for the exam cannot be less than the minimum grade!");
            }

            if (comments == null || comments == string.Empty)
            {
                throw new ArgumentNullException("A comment must be entered!");
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade { get; private set; }

        public int MinGrade { get; private set; }

        public int MaxGrade { get; private set; }

        public string Comments { get; private set; }
    }
}