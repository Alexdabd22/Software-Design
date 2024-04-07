using ComposerClassLibrary;
using System;

namespace LightweightClassLibrary
{
    public class MemoryMeasurement
    {
        public static long CalculateMemoryUsage(LightElementNode rootNode)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long memorySizeStart = GC.GetTotalMemory(true);
            string html = rootNode.OuterHtml(0);
            long memorySizeEnd = GC.GetTotalMemory(true);

            return memorySizeEnd - memorySizeStart;
        }
    }
}
