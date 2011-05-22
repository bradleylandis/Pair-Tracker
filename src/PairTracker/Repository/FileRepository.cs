using System;
using System.IO;
using Newtonsoft.Json;

namespace PairTracker.Repository
{
    public class FileRepository<T> : Repository<T>
    {
        string fileLocation;

        public FileRepository(string fileLocation)
        {
            this.fileLocation = fileLocation;
        }

        public void Save(T model)
        {
            using (var streamWriter = new StreamWriter(Path.Combine(fileLocation, "session" + Guid.NewGuid() + ".txt"), false))
            {
                var jsonSerializer = new JsonSerializer();
                jsonSerializer.Serialize(streamWriter, model);
            }
        }
    }
}
