namespace Landy.Domain.Infrastructure.MessageBrokers
{
    public class Message<T>
    {
        public MetaData MetaData { get; set; }

        public T Data { get; set; }
    }
}