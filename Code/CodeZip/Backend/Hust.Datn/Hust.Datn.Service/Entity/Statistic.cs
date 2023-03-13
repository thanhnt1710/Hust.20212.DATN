using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Entity
{
    public class Statistic
    {
        public int CountUser { get; set; }

        public int CountCourse { get; set; }

        public int CountChapter { get; set; }

        public int CountLesson { get; set; }

        public string StatisticCourse { get; set; }

        public string StatisticUser { get; set; }
    }
}
