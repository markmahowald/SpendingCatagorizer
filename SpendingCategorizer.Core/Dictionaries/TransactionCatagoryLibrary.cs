using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SpendingCategorizer.Core.Models
{
    public class TransactionCatagoryLibrary
    {
        private const string JsonFilePath = "categories.json";
        public Dictionary<string, string[]> Categories { get; private set; } = new Dictionary<string, string[]>();

        public TransactionCatagoryLibrary()
        {
            LoadCategoriesFromJson();
        }

        private void LoadCategoriesFromJson()
        {
            if (!File.Exists(JsonFilePath))
            {
                Console.WriteLine("JSON file not found, using default empty dictionary.");
                return;
            }

            try
            {
                var json = File.ReadAllText(JsonFilePath);
                Categories = JsonSerializer.Deserialize<Dictionary<string, string[]>>(json) ?? new Dictionary<string, string[]>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
                Categories = new Dictionary<string, string[]>(); // Fallback to empty if corrupted
            }
        }

        public void SaveCategoriesToJson()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(JsonFilePath, JsonSerializer.Serialize(Categories, options));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON: {ex.Message}");
            }
        }

        public void AddCategory(string category, string[] keywords)
        {
            Categories[category] = keywords;
        }

        public void RemoveCategory(string category)
        {
            if (Categories.ContainsKey(category))
                Categories.Remove(category);
        }

        public void AddKeywordToCategory(string category, string keyword)
        {
            if (!Categories.ContainsKey(category))
            {
                Categories[category] = new[] { keyword };
            }
            else
            {
                var keywordList = Categories[category].ToList();
                if (!keywordList.Contains(keyword))
                {
                    keywordList.Add(keyword);
                    Categories[category] = keywordList.ToArray();
                }
            }
        }

        public void RemoveKeywordFromCategory(string category, string keyword)
        {
            if (Categories.ContainsKey(category))
            {
                var keywordList = Categories[category].ToList();
                keywordList.Remove(keyword);
                Categories[category] = keywordList.ToArray();
            }
        }
    }
}
