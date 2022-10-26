using System.Collections;

namespace VTS.Collections
{
    /// <summary>Represents a collection of objects that itself has a collection of properties.</summary>
    public class PropertyedCollection<T> : List<T>
    {
        private List<DictionaryEntry> dictionaryEntries = new List<DictionaryEntry>();

        public void AddProperty(string key, string value)
        {
            dictionaryEntries.Add(new DictionaryEntry(key, value));
        }

        public void AddProperty(DictionaryEntry entry)
        {
            dictionaryEntries.Add(entry);
        }

        public bool RemoveProperty(DictionaryEntry entry)
        {
            return dictionaryEntries.Remove(entry);
        }

        public bool RemoveProperty(string key)
        {
            DictionaryEntry? match = dictionaryEntries.FirstOrDefault(x => x.Key.Equals(key));

            if (match.HasValue) return dictionaryEntries.Remove(match.Value);
            else return false;
        }
    }
}
