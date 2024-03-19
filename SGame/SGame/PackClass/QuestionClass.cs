using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    public class QuestionClass
    {
        public String? question {  get; set; }

        public int? price { get; set; }

        List<String> varinats = new List<String>();

        public List<String>? getVariantsAnswer()
        {
            if (varinats.Count == 0)
            {
                return null;
            }
            return varinats;
        }

        public String? answer { get; set; }
        
        public bool? type { get; set; }

        public void initQuestion (StreamReader fileStream)
        {
            type = false;
            String buf = "";
            
            question = "";
            answer = "";
            if (fileStream.ReadLine() == "?? PRICE ??") {
                try
                {
                    price = int.Parse(fileStream.ReadLine());
                }
                catch {
                    price = 100;
                }
            }
            buf = new string(fileStream.ReadLine());
            if (buf == "?? QUESTION ??")
            {
                buf = new string(fileStream.ReadLine());
                question += buf;
                buf = new string(fileStream.ReadLine());    
                while (buf != "?? QUESTION END ??") {
                    varinats.Add(buf);
                    buf = new string(fileStream.ReadLine());
                }
            }
            else if (buf == "?? QUESTION PHOTO ??")
            {
                buf = new string(fileStream.ReadLine());
                while (buf != "?? QUESTION PHOTO END ??")
                {
                    question += buf;
                    buf = new string(fileStream.ReadLine());
                }
            }

            if (fileStream.ReadLine() == "?? ANSWER ??")
            {
                buf = new string(fileStream.ReadLine());
                while (buf != "?? ANSWER END ??")
                {
                    answer += buf;
                    buf = new string(fileStream.ReadLine());
                }
            }
        }

    }
}
