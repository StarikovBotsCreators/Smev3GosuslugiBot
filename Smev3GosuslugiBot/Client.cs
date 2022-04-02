using System.Collections.Generic;
using Smev3GosuslugiBot.State;

namespace Smev3GosuslugiBot
{
    public class Client
    {
        private Dictionary<string, object> _temporaryData = new Dictionary<string, object>();

        public T GetData<T>(string key)
        {
            return (T)_temporaryData[key];
        }
        
        public T AddData<T>(string key)
        {
            return (T)_temporaryData[key];
        }
        
        public void ReleaseData(string key)
        {
            _temporaryData.Remove(key);
        }
        
        public void Clear()
        {
            _temporaryData.Clear();
        }

        public IState CurrentState { get; set; }
    }
}