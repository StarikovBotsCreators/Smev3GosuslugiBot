using System.Collections.Generic;
using System.Threading.Tasks;

namespace Parser
{
    public interface IParser
    {
        Task<List<ParsedDataDetail>> GetByName(string namePart);
        Task<List<ParsedDataDetail>> GetByParameters(ParserSettings parserSettings);
        Task Processed();
    }
}