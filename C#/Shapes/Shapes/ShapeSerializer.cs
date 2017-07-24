using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;
namespace Serializer
{
    public static class ShapeSerializer
    {
        private static MemoryStream stream;
        private static DataContractJsonSerializer jsonSerializer = null;
        private static DataContractSerializer xmlSerializer;
        private static Type shapeType = typeof(ShapeDTO);
        private static ShapeDTO shape;
       
        public static string ShapeToJson(ShapeDTO data)
        {
            
            stream = new MemoryStream();
            jsonSerializer = new DataContractJsonSerializer(shapeType);
            jsonSerializer.WriteObject(stream, data);
            byte[] serializeData = stream.ToArray();
            stream.Close();

            return Encoding.UTF8.GetString(serializeData);
        }
        public static string ShapeToXML(ShapeDTO data)
        {
            
            stream = new MemoryStream();
            xmlSerializer = new DataContractSerializer(shapeType);
            xmlSerializer.WriteObject(stream, data);
            byte[] serializeData = stream.ToArray();
            stream.Close();

            return Encoding.UTF8.GetString(serializeData);
        }
        public static ShapeDTO JsonToShape(string data)
        {
            using (stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                shape = jsonSerializer.ReadObject(stream) as ShapeDTO;
            }
            return shape;
        }
        public static ShapeDTO XmlToShape(string data)
        {
            using (stream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                shape = xmlSerializer.ReadObject(stream) as ShapeDTO;
            }
            return shape;
        }
    }
}
