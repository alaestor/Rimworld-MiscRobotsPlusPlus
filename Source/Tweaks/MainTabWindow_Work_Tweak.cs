using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscRobotsPlusPlus.Tweaks
{
    public class MainTabWindow_Work_Tweak : MainTabWindow_Dual
    {
        public static Type MainTabWindowType { get; set; }

        protected override Type InnerTabType => MainTabWindowType;
    }
}
