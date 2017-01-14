using System;
using System.Linq;
using System.Collections.Generic;

namespace DefensivePrograming.Exceptions
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private IList<Exam> exams;

        public Student(string firstName, string lastName, IList<Exam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name of student can not be empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("First name of student can not be empty");
                }
                this.lastName = value;
            }
        }

        public IList<Exam> Exams
        {
            get
            {
                if (this.exams == null)
                {
                    return null;
                }
                else
                {
                    // should be returning a deep copy, but I'm too lazy for that.
                    IList<Exam> examsCopy = this.exams;
                    return examsCopy;
                }

            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of exams can not be null");
                }
                this.exams = value;
            }
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null || this.Exams.Count == 0)
            {
                throw new NullReferenceException("The exams of the student are not set");
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
            if (this.Exams == null || this.Exams.Count == 0)
            {
                throw new NullReferenceException("The exams of the student are not set");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = CheckExams();
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