using System.Reflection;

namespace OnionArchitecture.Infrastructure
{
    public static class AssemblyReference
    {
        public static Assembly? GetAssembly()
        {
            return Assembly.GetAssembly(typeof(AssemblyReference));
        }
    }
}
