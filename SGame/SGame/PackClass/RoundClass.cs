using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.PackClass
{
    public class RoundClass
    {
        public List<ThemesClass> questionClasses = new List<ThemesClass>();
        public void Init(StreamReader streamReader)
        {
            ThemesClass theme = new ThemesClass();
            theme.initTheme(streamReader);
            questionClasses.Add(theme);
        }
    }
}
