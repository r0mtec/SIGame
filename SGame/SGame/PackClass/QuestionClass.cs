using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    public class QuestionClass
    {
        public String? question {  get; private set; }

        public int? price { get; private set; }

        List<String> varinats = new List<String>();

        public List<String>? getVariantsAnswer()
        {
            if (varinats.Count == 0)
            {
                return null;
            }
            return varinats;
        }

        public String? answer { get; private set; }
        
        public bool? type { get; private set; }

        public void initQuestion (StreamReader fileStream)
        {
            type = false;
            String buf = "";
            
            question = "";
            answer = "";
            if (fileStream.ReadLine().Contains("PRICE")) {
                try
                {
                    price = int.Parse(fileStream.ReadLine());
                }
                catch {
                    price = 100;
                }
            }
            buf = new string(fileStream.ReadLine());
            if (buf.Contains("QUESTION"))
            {
                buf = new string(fileStream.ReadLine());
                question += buf;
                buf = new string(fileStream.ReadLine());    
                while (!buf.Contains("QUESTION END")) {
                    varinats.Add(buf);
                    buf = new string(fileStream.ReadLine());
                }
            }
            else if (buf.Contains("QUESTION PHOTO"))
            {
                buf = new string(fileStream.ReadLine());
                while (!buf.Contains("QUESTION PHOTO END"))
                {
                    question += buf;
                    buf = new string(fileStream.ReadLine());
                }
            }

            if (fileStream.ReadLine().Contains("ANSWER"))
            {
                buf = new string(fileStream.ReadLine());
                while (!buf.Contains("ANSWER END"))
                {
                    answer += buf;
                    buf = new string(fileStream.ReadLine());
                }
            }
        }

    }
}
