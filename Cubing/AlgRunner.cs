using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    /// <summary>
    /// Used to run the application on a set of algorithms
    /// </summary>
    public class AlgRunner
    {
        /// <summary>
        /// The Cube representing the algorithm set to run
        /// </summary>
        public ICube Cube;

        /// <summary>
        /// The generator used to determine the positions to generate
        /// </summary>
        public IAlgNumberGenerator Gen;

        /// <summary>
        /// The time this AlgRunner was created
        /// </summary>
        public DateTime Start;

        /// <summary>
        /// The current position number of this AlgRunner
        /// </summary>
        public int PosNum;

        /// <summary>
        /// The AlgClient used to retrieve algorithms for positions
        /// </summary>
        public IAlgClient AlgClient;

        /// <summary>
        /// Creates a new AlgRunner with the given cube, alg number generator and alg client
        /// </summary>
        /// <param name="cube">The cube with the algorithm set to run</param>
        /// <param name="gen">A generator with the positions to generate</param>
        /// <param name="algClient">An algClient uwed to retrieve algorithms for positions</param>
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

        /// <summary>
        /// Generate the next position
        /// </summary>
        public void NextPosition()
        {
            PosNum = Gen.Generate();
        }

        /// <summary>
        /// Gets the number of positions to run
        /// </summary>
        /// <returns></returns>
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

