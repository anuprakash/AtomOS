﻿/*
* PROJECT:          Atomix Development
* LICENSE:          Copyright (C) Atomix Development, Inc - All Rights Reserved
*                   Unauthorized copying of this file, via any medium is
*                   strictly prohibited Proprietary and confidential.
* PURPOSE:          Shl MSIL
* PROGRAMMERS:      Aman Priyadarshi (aman.eureka@gmail.com)
*/

using System;
using System.Reflection;

using Atomix.Assembler;
using Atomix.CompilerExt;
using Atomix.Assembler.x86;
using Core = Atomix.Assembler.AssemblyHelper;

namespace Atomix.IL
{
    [ILOp(ILCode.Shl)]
    public class ILShl : MSIL
    {
        public ILShl(Compiler Cmp)
            : base("shl", Cmp) { }

        public override void Execute(ILOpCode instr, MethodBase aMethod)
        {
            var xStackItem_ShiftAmount = Core.vStack.Pop();
            var xStackItem_Value = Core.vStack.Peek();
            
            switch (ILCompiler.CPUArchitecture)
            {
                #region _x86_
                case CPUArch.x86:
                    {
                        if (xStackItem_Value.Size > 4)
                        {
                            throw new Exception("@Shl: xStackItem_Value > 4 not implemented!");
                        }
                        else
                        {
                            Core.AssemblerCode.Add(new Pop { DestinationReg = Registers.ECX }); //Shift Amount
                            Core.AssemblerCode.Add(new ShiftLeft { DestinationReg = Registers.ESP, DestinationIndirect = true, SourceReg = Registers.CL });
                        }
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
