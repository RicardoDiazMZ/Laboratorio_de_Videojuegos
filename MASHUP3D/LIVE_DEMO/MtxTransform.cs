using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LIVE_DEMO
{
    public class MtxTransform
    {
        public Mtx Mtx;
        public int time;
        public MtxTransform(Mtx mtx, int time)
        {
            this.Mtx = mtx;
            this.time = time;
        }
    }
}
