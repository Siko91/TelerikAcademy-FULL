using System;

namespace DefensivePrograming.Exceptions
{
    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            } 
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Grade of ExamResult can not be negative");
                }
                this.grade = value;
            } 
        }
        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Minimum grade of ExamResult can not be negative");
                }
                this.minGrade = value;
            }
        }
        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }
            private set
            {
                if (value < minGrade)
                {
                    throw new ArgumentOutOfRangeException("Maximum grade of ExamResult can not be smaller than the minimum grade");
                }
                this.maxGrade = value;
            }
        }
        public string Comments
        {
            get
            {
                return this.comments;
            }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Comments field of ExamResult can not be empty");
                }
                this.comments = value;
            }
        }

    }
}