namespace MeetingApi.Mapper
{
    public interface Converter<F,T>
    {
        public T convert(F from);
    }
}
