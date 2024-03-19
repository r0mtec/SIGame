using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    public class ThemesClass
    {
        public String? themeName {  get; private set; }

        public List<QuestionClass> questionClasses = new List<QuestionClass>();


        public void initTheme(StreamReader streamReader)
        {
            themeName = "";
            String buf = streamReader.ReadLine();
            if (buf == "?? THEME START ??") {
                buf = new string(streamReader.ReadLine());
                while (buf != "<<<>>>")
                {
                    themeName += buf;
                    buf = new string(streamReader.ReadLine());
                }
                QuestionClass bufq = new QuestionClass();
                bufq.initQuestion(streamReader);
                questionClasses.Add(bufq);
                buf = new string(streamReader.ReadLine());
                while (buf != "?? THEME END ??")
                {
                    bufq = new QuestionClass();
                    bufq.initQuestion(streamReader);
                    questionClasses.Add(bufq);
                    buf = new string(streamReader.ReadLine());
                }
            }
        }
    
    }
}
