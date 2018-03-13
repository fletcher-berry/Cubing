using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class ZbllCube : FullCube 
    {
        public ZbllCube(double ratio)
        {
            SizeRatio = ratio;
        }

        public override void SetUpPosition(int num)
        {
            Solve();
            RandomUMove();
            if (num < 432)
            {
                SetUpPll(num % 72);
                SetUpCornerOrientation(num / 72);
            }
            else
            {
                if(num < 456)
                {
                    SetUpPll(num % 12);
                    if(num >= 444)
                    {
                        Ui();
                    }
                }
                else 
                {
                    SetUpPll(num - 408);
                }
                SetUpCornerOrientation(num / 72);
            }
        }

       

        /* Set up the corner orientation based on the orientation number which will
         * be the position number / 72
         * @param num the orientation number
         */
        public void SetUpCornerOrientation(int num)
        {
            if (num == 0)
                TOrientation();
            else if (num == 1)
                UOrientation();
            else if (num == 2)
                LOrientation();
            else if (num == 3)
                SuneOrientation();
            else if (num == 4)
                AntisuneOrientation();
            else if (num == 5)
                PiOrientation();
            else
                HOrientation();
        }

        public override int GetNumPositions()
        {
            return 480;
        }


        
    }

}
