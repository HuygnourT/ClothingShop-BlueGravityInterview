namespace RPG.Core
{
    public static class InstanceRegister<T> where T : class, new()
    {
        public static T instance = new T();
    }
}