# SX3.Tools.Memory
Contains functions for reading &amp; writing memory aswell as functions for computing them.

## Usage
Read & Write Example:
```csharp
using SX3.Tools.Memory;

var processName = "notepad";
var mem = new ProcessMemory(processName);

IntPtr pointer = mem.Read<IntPtr>(0x588FEC);
mem.Write<float>(pointer, 254.4f);
```

## License
[MIT](https://choosealicense.com/licenses/mit/)
