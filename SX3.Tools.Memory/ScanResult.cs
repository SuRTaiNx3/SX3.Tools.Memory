using System;

namespace SX3.Tools.Memory
{
    /// <summary>
    /// Struct that holds basic data about the outcome of a signature-scan
    /// </summary>
    public struct ScanResult
    {
        public bool Success;
        public IntPtr Address;
        public IntPtr Base;
        public IntPtr Offset;
    }
}
