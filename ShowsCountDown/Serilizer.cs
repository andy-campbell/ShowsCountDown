using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

namespace ShowsCountDown
{
    class Serilizer <T>
    {
        String fileName;
        T data;
        public Serilizer (string fileName)
        {
            this.fileName = fileName;
        }

        /**
         * Sets the data to serilize and then serilizes it.
         */
        public void setData (T data)
        {
            this.data = data;

            toBin();
        }

        /** 
         * Get the data from the file given
         */
        public T getData (T inputData)
        {
            data = inputData;
            fromBin();
            return data;
        }


        private void toBin()
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, data);
                }
            }
            catch (IOException)
            {
            }
        }

        private void fromBin ()
        {
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    BinaryFormatter binFormater = new BinaryFormatter();
                    data = (T)binFormater.Deserialize(stream);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
            }
        }
    }
}
