using System;
using System.Collections.Generic;

public class Question
{
    public string Text { get; set; }
    public List<string> Variants { get; set; }
    public int CorrectVariant { get; set; }
}

public class Quiz
{
    public string Name { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();
}

class Program
{
    static List<Quiz> quizzes = new List<Quiz>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Create new quiz");
            Console.WriteLine("2. Solve a quiz");
            Console.WriteLine("3. Show quizzes");
            Console.WriteLine("0. Quit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewQuiz();
                    break;
                case "2":
                    SolveQuiz();
                    break;
                case "3":
                    ShowQuizzes();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewQuiz()
    {
        Console.Write("Enter the name of the quiz: ");
        string name = Console.ReadLine();

        Quiz quiz = new Quiz
        {
            Name = name
        };

        Console.Write("Enter the number of questions in the quiz: ");
        int numQuestions = int.Parse(Console.ReadLine());

        for (int i = 0; i < numQuestions; i++)
        {
            Question question = new Question();

            Console.Write($"Enter the text for Question {i + 1}: ");
            question.Text = Console.ReadLine();

            question.Variants = new List<string>();

            Console.Write("Enter the number of variants: ");
            int numVariants = int.Parse(Console.ReadLine());

            for (int j = 0; j < numVariants; j++)
            {
                Console.Write($"Enter Variant {j + 1}: ");
                question.Variants.Add(Console.ReadLine());
            }

            Console.Write("Enter the correct variant (1, 2, 3, ...): ");
            question.CorrectVariant = int.Parse(Console.ReadLine());

            quiz.Questions.Add(question);
        }

        quizzes.Add(quiz);
        Console.WriteLine("Quiz created successfully.");
    }

    static void ShowQuizzes()
    {
        Console.WriteLine("Available quizzes:");
        for (int i = 0; i < quizzes.Count; i++)
        {
            Console.WriteLine($"Quiz {i + 1}: {quizzes[i].Name}");
        }
    }

    static void SolveQuiz()
    {
        ShowQuizzes();

        Console.Write("Enter the number of the quiz you want to solve: ");
        int quizNumber = int.Parse(Console.ReadLine()) - 1;

        if (quizNumber < 0 || quizNumber >= quizzes.Count)
        {
            Console.WriteLine("Invalid quiz number. Please try again.");
            return;
        }

        int score = 0;
        Quiz quiz = quizzes[quizNumber];

        for (int i = 0; i < quiz.Questions.Count; i++)
        {
            Question question = quiz.Questions[i];
            Console.WriteLine($"Question {i + 1}: {question.Text}");

            for (int j = 0; j < question.Variants.Count; j++)
            {
                Console.WriteLine($"{j + 1}. {question.Variants[j]}");
            }

            Console.Write("Your answer (1, 2, 3, ...): ");
            int userAnswer = int.Parse(Console.ReadLine());

            if (userAnswer == question.CorrectVariant)
            {
                score++;
            }
        }

        Console.WriteLine($"You scored {score} out of {quiz.Questions.Count}.");
    }
}
