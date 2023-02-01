using System.Collections;

namespace VTS.Collections
{
    /// <summary>Represents a collection of objects that itself has a collection of properties.</summary>
    /// <remarks>If typeof T implements ICloneable then the items will be cloned instead of just making a reference to an existing object.</remarks>
    public class PropertyedCollection<T> : List<T>
    {
        #region Fields

        private List<DictionaryEntry> dictionaryEntries = new List<DictionaryEntry>();

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of <see cref="PropertyedCollection<typeparamref name="T"/>"/>.</summary>
        public PropertyedCollection()
        {
        }

        /// <summary>Initializes a new instance of <see cref="PropertyedCollection<typeparamref name="T"/>"/>.</summary>
        /// <param name="items">The items to include.</param>
        public PropertyedCollection(PropertyedCollection<T> items)
        {
            foreach (T item in items)
            {
                if (item is ICloneable cloneable) // prefer a clone
                    Add((T)cloneable.Clone());
                else
                    Add(item);
            }

            foreach (DictionaryEntry entry in items.dictionaryEntries)
            {
                AddProperty(new DictionaryEntry(entry.Key, entry.Value));
            }
        }

        #endregion

        #region Methods

        /// <summary>Adds a property to the property collection.</summary>
        /// <param name="key">The key for the item.</param>
        /// <param name="value">The value for the item.</param>
        public void AddProperty(object key, object value)
        {
            dictionaryEntries.Add(new DictionaryEntry(key, value));
        }

        /// <summary>Adds a property to the property collection.</summary>
        /// <param name="entry">The DictionaryEntry to add to the property collection.</param>
        public void AddProperty(DictionaryEntry entry)
        {
            dictionaryEntries.Add(entry);
        }

        /// <summary>Gets the DictionaryEntry at the specified index.</summary>
        /// <param name="index">The index of the desired item.</param>
        /// <returns>The DictionaryEntry at the specified index.</returns>
        public DictionaryEntry GetProperty(int index)
        {
            return dictionaryEntries[index];
        }

        /// <summary>Gets the DictionaryEntry whose key matches the specified key.</summary>
        /// <param name="key">The key to look for.</param>
        /// <returns>The DictionaryEntry that has the matching key, or null if no match found.</returns>
        public DictionaryEntry GetProperty(object key)
        {
            return dictionaryEntries.FirstOrDefault(entry => entry.Key.Equals(key));
        }

        /// <summary>Gets the number of properties.</summary>
        /// <returns>The number of properties.</returns>
        public int GetPropertyCount()
        {
            return dictionaryEntries.Count;
        }

        /// <summary>Removes the first occurence of the specified DictionaryEntry from the list of properties.</summary>
        /// <param name="entry">The dictionaryEntry to remove.</param>
        /// <returns>True if the item is successfully removed, otherwise false. Also returns false if the item is not found.</returns>
        public bool RemoveProperty(DictionaryEntry entry)
        {
            return dictionaryEntries.Remove(entry);
        }

        /// <summary>Removes the first occurence of the DictionaryEntry from the list properties that matches the key.</summary>
        /// <param name="key">The key to look for.</param>
        /// <returns>True if the item is successfully removed, otherwise false. Also returns false if the item is not found.</returns>
        public bool RemoveProperty(object key)
        {
            DictionaryEntry? match = dictionaryEntries.FirstOrDefault(x => x.Key.Equals(key));

            if (match.HasValue) return dictionaryEntries.Remove(match.Value);
            else return false;
        }

        #endregion
    }
}
