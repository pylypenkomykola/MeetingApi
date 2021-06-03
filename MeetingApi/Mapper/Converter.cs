using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Mapper
{
    public interface Converter<F,T>
    {
        public T convert(F from);
    }
}
