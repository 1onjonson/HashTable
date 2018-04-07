using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class HashTableClass

    {
        public class PairDto
        {
            public object key { get; set; }
            public object value { get; set; }
        }
        public static List<List<PairDto>> hashTable;
        public static List<int> hash;

        /// <summary>
        /// поиск индекса
        /// </summary>
        public int HashIndex(int bucket)
        {
            return hash.IndexOf(bucket);
        }

        /// <summary>
        /// получение ключа
        /// </summary>
        public int HashKey(object key)
        {
            return key.GetHashCode();
        }

        /// <summary>
        /// Конструктор контейнера
        /// </summary>
        /// <"size"> Размер хэш-таблицы
        public void HashTableCreate(int size)

        {
            hashTable = new List<List<PairDto>>(size);
            hash = new List<int>(size);
            for (int i = 0; i < size; i++)
            {
                hashTable.Add(new List<PairDto>());
            }
        } 

        ///<summary> 
        ///Метод складывающий пару ключь-значение в таблицу
        ///</summary>
        public void PutPair(object key, object value)
        {
            var hashCode = HashKey(key);
            var hashIndex = HashIndex(hashCode);
            var keyValue = new PairDto { key = key, value = value };
            if (hashIndex == -1 && hash.Count < hashTable.Count)
            {
                hash.Add(HashKey(key));
                hashIndex = HashIndex(HashKey(key));
                hashTable[hashIndex].Add(keyValue);
                return;
            }
            foreach (var e in hashTable[hashIndex])
            {
                if (e.key.Equals(key))
                    e.value = value;
            }
        }

        /// <summary>
        /// Поиск значения по ключу
        /// </summary>
        public object GetValueByKey(object key)
        {
            var hashCode = HashKey(key);
            var hashIndex = HashIndex(hashCode);
            if (hashIndex == -1)
                return null;

            foreach (var e in hashTable[hashIndex])
            {
                if (e.key.Equals(key))
                    return e.value;
            }

            return null;
        }
        public static void Main(string[] Args)
        {

        }

    }
}
