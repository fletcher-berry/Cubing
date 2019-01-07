using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Represents a cube for ZBLL positions
    /// </summary>
    public class ZbllCube : FullCube 
    {
        /// <summary>
        /// Creates a new ZBLL cube
        /// </summary>
        public ZbllCube()
        {
        }

        public ZbllCube(LastLayerCubeStickers stickers) : base(stickers) { }

        /// <summary>
        /// Sets up a ZBLL case on this cube
        /// </summary>
        /// <param name="num"></param>
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

       

        /// <summary>
        /// Set up corner orientation
        /// </summary>
        /// <param name="num">The corner orientation number (0 - 6)</param>
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

        /// <summary>
        /// Get the number of possible ZBLL positions on this cube
        /// </summary>
        /// <returns></returns>
        public override int GetNumPositions()
        {
            return 480;
        }


        
    }

}
