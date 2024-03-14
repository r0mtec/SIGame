using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    public class QuestionClass
    {
        private String question = "";

        private int price = 0;

        private String? answer = "";
        
        private bool type = false;


        void initQuestion (StreamReader fileStream)
        {
            String buf;
            String question = "";
            String answer = "";
            if (fileStream.ReadLine() == "?? PRICE ??") {
                try
                {
                    price = int.Parse(fileStream.ReadLine());
                }
                catch {
                    price = 100;
                }
            }
            if (fileStream.ReadLine() == "?? QUESTION ??")
            {
                buf = fileStream.ReadLine();
                while (buf != "?? QUESTION END ??") {
                    question += buf;
                    buf = fileStream.ReadLine();
                }
            }
            else if (fileStream.ReadLine() == "?? QUESTION PHOTO ??")
            {
                buf = fileStream.ReadLine();
                while (buf != "?? QUESTION PHOTO END ??")
                {
                    question += buf;
                    buf = fileStream.ReadLine();
                }
            }
            if (fileStream.ReadLine() == "?? ANSWER ??")
            {
                buf = fileStream.ReadLine();
                while (buf != "?? ANSWER END ??")
                {
                    answer += buf;
                    buf = fileStream.ReadLine();
                }
            }
        }

    }
}
