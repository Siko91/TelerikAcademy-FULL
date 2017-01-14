using System;

namespace DefensivePrograming.Exceptions
{
    public class SimpleMathExam : Exam
    {
        private int problemsSolved;
        private int totalProblems;

        public SimpleMathExam(int problemsSolved, int totalProblems = 2)
        {
            this.ProblemsSolved = problemsSolved;
            this.TotalProblems = totalProblems;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Problems solved count of SimpleMathExam can not be negative.");
                }
                if (value > this.TotalProblems)
                {
                    throw new ArgumentOutOfRangeException("Problems solved count of SimpleMathExam can not be bigger than the total problems count.");
                }
                this.problemsSolved = value;
            }
        }

        public int TotalProblems
        {
            get
            {
                return this.totalProblems;
            }
            private set
            {
                if (this.ProblemsSolved > value)
                {
                    throw new ArgumentOutOfRangeException("Total problems count of SimpleMathExam can not be smaller than the actual solved problems count.");
                }
                this.totalProblems = value;
            }
        }

        public override ExamResult Check()
        {
            if (ProblemsSolved == 0)
            {
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            }
            else if (ProblemsSolved == 1)
            {
                return new ExamResult(4, 2, 6, "Average result: halfly done.");
            }
            else if (ProblemsSolved == 2)
            {
                return new ExamResult(6, 2, 6, "Great result: well done.");
            }

            return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
        }
    }
}