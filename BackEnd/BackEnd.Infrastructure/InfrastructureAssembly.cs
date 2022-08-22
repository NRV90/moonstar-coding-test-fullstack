using System.Reflection;

namespace BackEnd.Infrastructure
{
    internal class InfrastructureAssembly
    {
        public static readonly Assembly Assembly = typeof(InfrastructureAssembly).Assembly;
    }
}
