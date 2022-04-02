using System.Threading.Tasks;
using Parser;

namespace Smev3GosuslugiBot
{
    public class Application
    {
        public IParser Parser { get; }

        public async Task Init()
        {
            await Parser.Processed();
        }
    }
}