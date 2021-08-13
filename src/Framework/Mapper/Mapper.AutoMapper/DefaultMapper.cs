using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IObjectMapper = LiModular.Lib.Utils.Core.Map.IObjectMapper;

namespace LiModular.Lib.Mapper.AutoMapper
{
    public class DefaultMapper : IObjectMapper
    {

        private readonly IMapper _mapper;

        public DefaultMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public T Map<T>(object source)
        {
            return _mapper.Map<T>(source);
        }

        public void Map<TSource, TTarget>(TSource source, TTarget target)
        {
            _mapper.Map(source, target);
        }
    }
}
