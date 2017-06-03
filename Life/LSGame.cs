using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Life
{
    class LSGame
    {
        public LSGame()
        {

        }

        public Tablica Load()
        {
            var myList = new List<int>();
            var path = @".\array.txt";
            using (var reader = new StreamReader(path))
            {
                while(!reader.EndOfStream)
                {
                    myList.Add(int.Parse(reader.ReadLine()));
                }
            }
            var size = (int)Math.Sqrt(myList.Count);
            var lsArray = new Tablica(size);
            lsArray.Array = LoadArrayFromFile(path, size);
            path = @".\hidearray.txt";
            lsArray.HideArray = LoadArrayFromFile(path, size);
            path = @".\colourarray.txt";
            lsArray.ColourArray = LoadArrayFromFile(path, size);

            return lsArray;
        }

        public void Save(Tablica arrToSave)
        {
            var path = @".\array.txt";
            SaveArrayToFile(path, arrToSave.Array);
            path = @".\hidearray.txt";
            SaveArrayToFile(path, arrToSave.HideArray);
            path = @".\colourarray.txt";
            SaveArrayToFile(path, arrToSave.ColourArray);
        }

        public void SaveArrayToFile(string path, int [,] array)
        {
            using (var writer = File.CreateText(path))
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        writer.WriteLine(array[i, j]);
                    }
                }

            }

        }

        public int[,] LoadArrayFromFile(string path, int size)
        {
            var tempArray = new int[size, size];
            using (var reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    for (int i = 0; i < tempArray.GetLength(0); i++)
                    {
                        for (int j = 0; j < tempArray.GetLength(1); j++)
                        {
                            tempArray[i, j] = int.Parse(reader.ReadLine());
                        }

                    }
                }
            }
            return tempArray;

        }
    }
}
