/*using System;

namespace JustLogic.Core
{
    public static class VariableEncoding
    {
        public static void Unpack(int value, out int variableIndex, out VariableType type)
        {
            type = (VariableType)(byte)(value >> 28);
            variableIndex = (value << 4) >> 4;
        }

        public static int Pack(int variableIndex, VariableType type)
        {
            int clean = (variableIndex << 4) >> 4;
            return clean | ((int)(byte)type << 28);
        }
    }
}*/