﻿/*
* PROJECT:          Atomix Development
* LICENSE:          BSD 3-Clause (LICENSE.md)
* PURPOSE:          Ldelem_I1 MSIL
* PROGRAMMERS:      Aman Priyadarshi (aman.eureka@gmail.com)
*/

using System.Reflection;

using Atomix.CompilerExt;

namespace Atomix.IL
{
    [ILOp(ILCode.Ldelem_I1)]
    public class Ldelem_I1 : MSIL
    {
        public Ldelem_I1(Compiler Cmp)
            : base("ldelemi1", Cmp) { }

        public override void Execute(ILOpCode instr, MethodBase aMethod)
        {
            switch (ILCompiler.CPUArchitecture)
            {
                #region _x86_
                case CPUArch.x86:
                    {
                        Ldelem_Ref.Ldelem_x86(1, true);
                    }
                    break;
                #endregion
                #region _x64_
                case CPUArch.x64:
                    {

                    }
                    break;
                #endregion
                #region _ARM_
                case CPUArch.ARM:
                    {

                    }
                    break;
                #endregion
            }
        }
    }
}
