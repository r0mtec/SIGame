using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    public class GamePackClass
    {
        public List<RoundClass> roundClasses = new List<RoundClass>();
   
        public void initGame(StreamReader streamreader)
        {
            String buf = streamreader.ReadLine();
            if (buf == "?? START PACK ??") {
                buf =new String(streamreader.ReadLine());
                RoundClass bufr = new RoundClass();
                bufr.initRound(streamreader);
                roundClasses.Add(bufr);
                buf = new String(streamreader.ReadLine());
                while (buf != "?? PACK END ??") {
                    bufr = new RoundClass();
                    bufr.initRound(streamreader);
                    roundClasses.Add(bufr);
                    buf = new String(streamreader.ReadLine());
                }
            }
        }
    }
}
