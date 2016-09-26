////////////////////////////
/// Класс для сериализации объектов
////////////////////////////

using System;
using System.Xml.Serialization;
using System.IO;

namespace Paint3D.Core
{
	public class GManagerFile
	{
		/// <summary>
		/// Путь к сохраненным файлам
		/// </summary>
		public const String PATH_DATA = @"Data\";
		/// <summary>
		/// Сериализует объект
		/// </summary>
		/// <param name="name">Имя файла</param>
		/// <param name="obj">Объект</param>
		public void SetDataXMLFile(string name, object obj)
		{
			String all_path = PATH_DATA + name + "//" + name + ".xml";
			XmlSerializer serializer = new XmlSerializer(obj.GetType());

			if (!Directory.Exists(PATH_DATA))
				Directory.CreateDirectory(PATH_DATA);
			Directory.CreateDirectory(name);

			using (Stream stream = new FileStream(all_path, FileMode.Create))
			{
				serializer.Serialize(stream, obj);
			}
		}
		/// <summary>
		/// Десериализует объект
		/// </summary>
		/// <param name="name">Имя файла</param>
		/// <param name="type">Тип объекта</param>
		/// <returns></returns>
		public object GetDataXMLFile(string name, Type type)
		{
			String all_path = PATH_DATA + name + "//" + name +  ".xml";
			XmlSerializer serializer = new XmlSerializer(type);
			Object obj_res = null;

			if (!Directory.Exists(PATH_DATA))
				Directory.CreateDirectory(PATH_DATA);

			using (Stream stream = new FileStream(all_path, FileMode.Open))
			{
				obj_res = serializer.Deserialize(stream);
			}

			return obj_res;
		}
	}
}
