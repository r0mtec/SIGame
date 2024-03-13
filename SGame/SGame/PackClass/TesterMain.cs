using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    internal static class TesterMain
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("C:\\Users\\ne_kroman\\Source\\Repos\\SIGame\\SGame\\SGame\\PackClass\\Data\\TestFileQuestionRead.txt");
            QuestionClass question = new QuestionClass();
            question.initQuestion(streamReader);
            Console.WriteLine(question.question + "\n" + question.answer + "\n" + question.price);
        }
    }
}
