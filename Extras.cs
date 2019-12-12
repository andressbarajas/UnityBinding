using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Foundation;

namespace NativeLibrary
{
    public partial class UnityFramework
    {
        public unsafe void RunUIApplicationMainWithArgc(int argc, string[] argv)
        {
            if (argv == null || argv.Length == 0)
            {
                RunUIApplicationMainWithArgc(argc, IntPtr.Zero);
            }
            else
            {
                var allocatedMemory = new List<IntPtr>();

                int sizeOfIntPtr = Marshal.SizeOf(typeof(IntPtr));
                IntPtr pointersToArguments = Marshal.AllocHGlobal(sizeOfIntPtr * argv.Length);

                for (int i = 0; i < argv.Length; ++i)
                {
                    IntPtr pointerToArgument = Marshal.StringToHGlobalAnsi(argv[i]);
                    allocatedMemory.Add(pointerToArgument);
                    Marshal.WriteIntPtr(pointersToArguments, i * sizeOfIntPtr, pointerToArgument);
                }
                RunUIApplicationMainWithArgc(argc, pointersToArguments);
            }
        }

        public unsafe void RunEmbeddedWithArgc(int argc, string[] argv, NSDictionary options)
        {
            if (argv == null || argv.Length == 0)
            {
                RunEmbeddedWithArgc(argc, IntPtr.Zero, options);
            }
            else
            {
                var allocatedMemory = new List<IntPtr>();

                int sizeOfIntPtr = Marshal.SizeOf(typeof(IntPtr));
                IntPtr pointersToArguments = Marshal.AllocHGlobal(sizeOfIntPtr * argv.Length);

                for (int i = 0; i < argv.Length; ++i)
                {
                    IntPtr pointerToArgument = Marshal.StringToHGlobalAnsi(argv[i]);
                    allocatedMemory.Add(pointerToArgument);
                    Marshal.WriteIntPtr(pointersToArguments, i * sizeOfIntPtr, pointerToArgument);
                }
                RunEmbeddedWithArgc(argc, pointersToArguments, options);
            }
        }
    }
}
