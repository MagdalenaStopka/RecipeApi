using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models.Interfaces
{
   public interface IApiKeyRepos
    {
        bool CheckApiKey(string key);
        Task<List<string>> GetKeys();

        Dictionary<string, string> GetDictionary();
    }
}
