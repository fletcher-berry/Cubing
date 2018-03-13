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
        public static MainScreen MainForm;

        public static readonly string AlgFilePath = System.Configuration.ConfigurationManager.AppSettings["algFilePath"];

        public static ICube GetScreenCube(AlgSet set)
        {
            switch (set){
                case AlgSet.ZBLL:
                    return new ZbllCube(MainScreen.PreviewCubeSize);
                case AlgSet.OLL:
                    return new OllCube(MainScreen.PreviewCubeSize);
                case AlgSet.OLLCP:
                    return new OllcpCube(MainScreen.PreviewCubeSize);
                case AlgSet.ELLCP:
                    return new EllcpCube(MainScreen.PreviewCubeSize);
                case AlgSet.VLS:
                    return new VlsCube(MainScreen.PreviewCubeSize);
                case AlgSet.OneLookLL:
                    return new OneLookLLCube(MainScreen.PreviewCubeSize);
            }
            return null;
        }

        public static ICube GetRunnerCube(AlgSet set)
        {
            switch (set)
            {
                case AlgSet.ZBLL:
                    return new ZbllCube(MainScreen.CubeSize);
                case AlgSet.OLL:
                    return new OllCube(MainScreen.CubeSize);
                case AlgSet.OLLCP:  
                    return new OllcpCube(MainScreen.CubeSize);
                case AlgSet.ELLCP:
                    return new EllcpCube(MainScreen.CubeSize);
                case AlgSet.VLS:
                    return new VlsCube(MainScreen.CubeSize);
                case AlgSet.OneLookLL:
                    return new OneLookLLCube(MainScreen.CubeSize);
            }
            return null;
        }

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
            }
            return null;
        }

    }


    
}
