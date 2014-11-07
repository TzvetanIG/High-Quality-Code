using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (maxGrade <= minGrade)
        {
            throw new ArithmeticException("The minGrade should be less than maxGrade.");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade
    {
        get { return this.grade; }

        private set
        {
            Validation.CheckForPositiveNumber(value, "grade");
            this.grade = value;
        }
    }

    public int MinGrade
    {
        get { return this.minGrade; }

        private set
        {
            Validation.CheckForPositiveNumber(value, "minGrade");
            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get { return this.maxGrade; }

        private set
        {
            Validation.CheckForPositiveNumber(value, "maxGrade");
            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get { return this.comments; }

        private set
        {
            Validation.CheckForEmtyOrNull(value, "comments");
            this.comments = value;
        }
    }
}
