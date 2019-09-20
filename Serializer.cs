using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.IO;

namespace TestSerialize
{
    class Selializer
    {
        public static void save(string path, Object obj)
        {
            BinaryFormatter bformatter = new BinaryFormatter();
            MemoryStream mem = new MemoryStream();
            bformatter.Serialize(mem, obj);


            BinaryWriter bwriter = new BinaryWriter(new FileStream(path, FileMode.Create));
            bwriter.Write(mem.ToArray());
            bwriter.Close();
        }

        static public object load(string path)
        {
            BinaryFormatter bf = new BinaryFormatter();
            BinaryReader breader = new BinaryReader(new FileStream(path, FileMode.Open));

            object obj = bf.Deserialize(breader.BaseStream);
            return obj;
        }
    }
}
