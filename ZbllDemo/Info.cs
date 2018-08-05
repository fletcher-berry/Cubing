using Cubing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZbllDemo
{
    public class Info
    {
        /// <summary>
        /// The home form of the app
        /// </summary>
        public static MainScreen MainForm;

        public static readonly string AlgFilePath = System.Configuration.ConfigurationManager.AppSettings["algFilePath"];

        /// <summary>
        /// Gets the cube for the given alg set
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static ICube GetCube(AlgSet set)
        {
            switch (set){
                case AlgSet.ZBLL:
                    return new ZbllCube();
                case AlgSet.OLL:
                    return new OllCube();
                case AlgSet.OLLCP:
                    return new OllcpCube();
                case AlgSet.ELLCP:
                    return new EllcpCube();
                case AlgSet.VLS:
                    return new VlsCube();
                case AlgSet.OneLookLL:
                    return new OneLookLLCube();
                case AlgSet.EG:
                    return new EgCube();
            }
            return null;
        }

        /// <summary>
        /// gets the alg file name for the given alg set
        /// </summary>
        /// <param name="set"></param>
        /// <returns></returns>
        public static string GetAlgFileName(AlgSet set)
        {
            switch (set)
            {
                case AlgSet.ZBLL:
                    return AlgFilePath + @"\zbll.alg";
                case AlgSet.OLL:
                    return AlgFilePath + @"\oll.alg";
                case AlgSet.OLLCP:
                    return AlgFilePath + @"\ollcp.alg";
                case AlgSet.ELLCP:
                    return AlgFilePath + @"\ellcp.alg";
                case AlgSet.VLS:
                    return AlgFilePath + @"\vls.alg";
                case AlgSet.OneLookLL:
                    return AlgFilePath + @"\oneLookLL.alg";
                case AlgSet.EG:
                    return AlgFilePath + @"\eg.alg";
            }
            return null;
        }

    }


    
}
