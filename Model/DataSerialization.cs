using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Logic behind saving data to a file.
    /// </summary>
    public class DataSerialization
    {
        /// <summary>
        /// Method to save game data to file.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>
        /// <param name="serializableObject">Object to save to file.</param>
        /// <param name="fileName">File path to save data to.</param>
        public void SerializeObject<T>(T serializableObject, string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            var binaryFormatter = new BinaryFormatter();

            try
            {
                binaryFormatter.Serialize(fileStream, serializableObject);
            }
            catch (SerializationException e)
            {
                Console.WriteLine(Repository.failedToSerializeMessage + e.Message);
                throw;
            }
            finally
            {
                fileStream.Close();
            }
        }

       /// <summary>
       /// Loads game data from file.
       /// </summary>
       /// <param name="fileName">Path for file to load from.</param>
       /// <returns>Returs object with game data, iteration and alive cell count.</returns>
        public GameData DeSerializeObject(string fileName)
        {
            GameData data = new GameData();
            FileStream fs = new FileStream(fileName, FileMode.Open);

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                data = (GameData)formatter.Deserialize(fs);
            }
            catch( SerializationException e)
            {
                Console.WriteLine(Repository.failedToDeserializeMessage + e.Message);
                throw;
            }
            finally 
            { 
                fs.Close(); 
            }
            return data;
        }
    }
}
