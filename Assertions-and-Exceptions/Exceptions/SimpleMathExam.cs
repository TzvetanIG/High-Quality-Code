using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class SimpleMathExam : Exam
{
    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
      this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get { return this.problemsSolved; }

        private set
        {
            if (this.problemsSolved < 0 || this.problemsSolved > 10)
            {
                throw new ArgumentOutOfRangeException("problemsSolved", "The value should be in range [0..10].");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved == 0)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (this.ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
