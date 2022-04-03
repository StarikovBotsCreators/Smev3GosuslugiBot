using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parser
{
    public class IParser
    {
        Task Process();
        Task<List<Model>> GetByName(string namePart);
        Task<List<Model>> GetByParameters(ParserSettings parserSettings);
    }
}