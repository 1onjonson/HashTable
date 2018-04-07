using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashTable;


namespace HashTableTests
{
    [TestClass]
    public class HashTableTests
    {
        [TestMethod]
        public void ThreeElementsTest()
        {
            //тест добавления и поиска трех элементов
            var threeElementsTable = new HashTableClass();
            var size = 3;
            threeElementsTable.HashTableCreate(size);
            threeElementsTable.PutPair(1, "один");
            threeElementsTable.PutPair(2, "два");
            threeElementsTable.PutPair(3, "три");
            
            var tableKeys = new object[] { 1, 2, 3 };
            var tableValues = new object[] { "один", "два", "три" };
            for (int i = 0; i < size; i++)
            {
                if (!(threeElementsTable.GetValueByKey(tableKeys[i])).Equals(tableValues[i]))
                    throw new Exception();
            }
        }

        [TestMethod]

        public void EqualValuesTest()
        {
            // тест на добавление одного и того же ключа дважды с разными значениями, которое сохраняет последнее добавленное значение
            var equalValuesTable = new HashTableClass();
            var size = 2;
            equalValuesTable.HashTableCreate(size);
            equalValuesTable.PutPair(1, "Один");
            equalValuesTable.PutPair(1, "Два");
            var tableKey = 1;
            var tableValue = "Два";
            if (!(equalValuesTable.GetValueByKey(tableKey)).Equals(tableValue))
                throw new Exception();
        }

        [TestMethod]

        public void ManyElementsTest()
        {
            //тест на добавление 10000 элементов и поиск одного
            var manyElements = new HashTableClass();
            var size = 10000;
            manyElements.HashTableCreate(size);
            var tableKey = 135;
            var tableValue = "k135";
            for (int i = 0; i < size; i++)
            {
                manyElements.PutPair(i, "k" + i);
            }
            if (!(manyElements.GetValueByKey(tableKey)).Equals(tableValue))
                throw new Exception();
        }

        [TestMethod]

        public void MissedKeysTest()
        {
            //тест на добавление 10000 элементов и поиск 1000 недобавленных ключей. Возвращает null.
            var missedKeys = new HashTableClass();
            var size = 10000;
            missedKeys.HashTableCreate(size);
            for (int i = 0; i < size; i++)
            {
                missedKeys.PutPair(i, "k" + i);
            }
            for (int i = size; i < size + 1000; i++)
            {
                if (!(missedKeys.GetValueByKey(i)==null))
                    throw new Exception();
            }
        }
    }
}
