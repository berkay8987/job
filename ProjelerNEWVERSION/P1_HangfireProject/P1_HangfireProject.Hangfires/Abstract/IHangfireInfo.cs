using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_HangfireProject.Hangfires.Abstract
{
    public interface IHangfireInfo
    {
        void HangfireStartText();

        void HangfireEndText();

        void HangfireNoChangeText();
    }
}
