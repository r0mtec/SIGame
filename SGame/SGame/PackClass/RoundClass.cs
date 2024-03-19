using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    public class RoundClass
    {
        static int countnumbers;
        int number {  get; set; }
        public List<ThemesClass> themeClasses = new List<ThemesClass>();
        
        public void initRound(StreamReader streamReader)
        {
            number = countnumbers;
            countnumbers++;
            String buf = streamReader.ReadLine();
            if (buf == "?? ROUND START ??")
            {
                buf = new String(streamReader.ReadLine());
                ThemesClass buft = new ThemesClass();
                buft.initTheme(streamReader);
                themeClasses.Add(buft);
                buf = new String(streamReader.ReadLine());
                while (buf != "?? ROUND END ??")
                {
                    buft = new ThemesClass();
                    buft.initTheme(streamReader);
                    themeClasses.Add(buft);
                    buf = new String(streamReader.ReadLine());
                }
            }
        }


    }
}
