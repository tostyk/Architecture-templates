using System.Reflection;

namespace OnionArchitecture.Application
{
    public static class AssemblyReference
    {
        public static Assembly? GetAssembly()
        {
            return Assembly.GetAssembly(typeof(AssemblyReference));
        }
    }
}
