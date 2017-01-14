using System;

namespace DefensivePrograming.Exceptions
{
    public class CSharpExam : Exam
    {
        private int score;
        private int maxScore;

        public CSharpExam(int score, int maxScore = 100)
        {
            this.Score = score;
            this.MaxScore = maxScore;
        }

        public int Score 
        {
            get
            { 
                return this.score;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Score of CSharpExam can not be negative.");
                }
                if (value > maxScore)
                {
                    throw new ArgumentOutOfRangeException("Score of CSharpExam can not be bigger than the maximum score.");
                }
                this.score = value;
            }
        }

        public int MaxScore
        {
            get
            {
                return this.maxScore;
            }
            private set
            {
                if (this.score > value)
                {
                    throw new ArgumentOutOfRangeException("MaxScore of CSharpExam can not be smaller than the actual score.");
                }
                this.maxScore = value;
            }
        }

        public override ExamResult Check()
        {
            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}
