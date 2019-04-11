using Microsoft.EntityFrameworkCore;
using RecipeApi.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApi.Models.Repos
{
    public class ApiKeyRepo : IApiKeyRepos

    {
        private readonly RecipeContext context;
        public ApiKeyRepo(RecipeContext context)
        {
            this.context = context;
        }
        public  bool CheckApiKey(string key)
        {
            return  context.Keys.Any(x => x.Name == key);
        }

        public Dictionary<string, string> GetDictionary() // pobiera z bazy i sprawdza czy mamy uprawnienia
        {
            var list = context.Keys.Where(a => a.ExpirationDate >= DateTime.Now).ToList();

            var names = list.Select(a => a.Name).Distinct().ToList();

            var dictionary = new Dictionary<string, string>();

            names.ForEach(n =>

            {

                dictionary.Add(n, list.First(k => k.Name == n).Role);

            });

            return dictionary; // tylko te , ktorych data nie jest przekroczona
        }

        public async Task<List<string>> GetKeys()
        {
            return await context.Keys.Where(a => a.ExpirationDate >= DateTime.Now).Select(a => a.Name).ToListAsync();
        }
    }
}
