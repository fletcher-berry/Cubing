using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public class AlgRunner
    {
        public ICube Cube;
        public IAlgNumberGenerator Gen;
        public DateTime Start;
        public int PosNum;
        public IAlgClient AlgClient;

        public AlgRunner(ICube cube, IAlgNumberGenerator gen, IAlgClient algClient)
        {
            Start = DateTime.Now;
            Cube = cube;
            Gen = gen;
            PosNum = Gen.Generate();
            AlgClient = algClient;
        }

        public ICube GetCube()
        {
            return Cube;
        }


        public DateTime GetStartTime()
        {
            return Start;
        }


        public int GetCurrentPosNum()
        {
            return PosNum;
        }

        public void NextPosition()
        {
            PosNum = Gen.Generate();
        }

        public int GetNumPositions()
        {
            return Gen.GetNumAlgs();
        }

        public IAlgClient GetAlgClient()
        {
            return AlgClient;
        }
    }
}

