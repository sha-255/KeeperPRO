namespace KeeperPRO.Api.Common.Exeptions
{
    public class NotFoundExeption<T> : Exception
    {
        public NotFoundExeption(dynamic key)
            : base($"Entity \"{typeof(T).Name}\" ({key}) not found.") { }

        public NotFoundExeption()
            : base($"Entity \"{typeof(T).Name}\" not found.") { }
    }
}