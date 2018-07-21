using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathServer.MathUI.Framework
{
    public enum ViewName
    {
        None,

        //Main page
        Alpha,

        //Partition
        Menu,
        Workspace,
        Explorer,
        GraphingExplorer,

        //Menu Partition
        Ribbon1,
        Ribbon2,
        Ribbon3,

        //Explorer Partition
        MiniKeyboard,
        MathFunctions,

        //Workspace Partition
        Worksheet,
        Graphing,

        InputPanel,
        OutputPanel,

        SolutionDisplay,
        Display,
        StepDisplay,

        //MathFunctions
        FunctionList1,
        FunctionList2,
        FunctionList3,


    }

    public class GlobalConst
    {
    }
}
