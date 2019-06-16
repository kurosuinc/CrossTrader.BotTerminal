#if NETSTANDARD1_5
using System;
namespace System.Runtime
{
    internal sealed class TargetedPatchingOptOutAttribute : Attribute
    {
        public TargetedPatchingOptOutAttribute(string s) { }
    }
}
#endif