namespace Utils.Attribiutes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InjectableAttribute : Attribute
    {
        public Type ImplementedInterface { get; }
        public DependencyInjectionScope Scope { get; }

        public InjectableAttribute(Type implementedInterface, DependencyInjectionScope scope = DependencyInjectionScope.Singleton)
        {
            ImplementedInterface = implementedInterface;
            Scope = scope;
        }
    }

    public enum DependencyInjectionScope
    {
        Singleton,
        PerDependency,
        Scoped
    }
}