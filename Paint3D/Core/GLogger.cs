////////////////////////////
/// Класс для логирования данных
////////////////////////////
using System;
using System.Text;
using System.IO;

namespace Paint3D.Core
{
	public class GLogger
	{
		/// <summary>
		/// Путь к файлам логов
		/// </summary>
		public const string PATH_LOG = @"logs\";
		public GLogger() {  }
		/// <summary>
		/// Лог/сообщение
		/// </summary>
		/// <param name="value">Записываемые данные</param>
		public void Log(string value)
		{
			string nameFile = GetCurrentFileName();
			ExistsDirectory(nameFile);

			using (Stream stream = new FileStream(PATH_LOG + nameFile, FileMode.Append))
			{
				StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
				writer.WriteLine("LOG[" + System.DateTime.Now.ToShortTimeString() + "]: " + value);
				writer.Close();
				stream.Close();
			}
		}
		/// <summary>
		/// Информативный лог
		/// </summary>
		/// <param name="value">Записываемые данные</param>
		public void Info(string value)
		{
			string nameFile = GetCurrentFileName();
			ExistsDirectory(nameFile);

			using (Stream stream = new FileStream(PATH_LOG + nameFile, FileMode.Append))
			{
				StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
				writer.WriteLine("INFO[" + System.DateTime.Now.ToShortTimeString() + "]: " + value);
				writer.Close();
				stream.Close();
			}
		}
		/// <summary>
		/// Лог о ошибке
		/// </summary>
		/// <param name="ex">Экземпляр ошибки</param>
		public void Error(Exception ex)
		{
			string nameFile = GetCurrentFileName();
			ExistsDirectory(nameFile);

			using (Stream stream = new FileStream(PATH_LOG + nameFile, FileMode.Append))
			{
				StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
				writer.WriteLine("ERROR[" + System.DateTime.Now.ToShortTimeString() + "]: " + ex);
				writer.Close();
				stream.Close();
			}
		}
		/// <summary>
		/// Проверяет файл лога, если его нет - создает новый
		/// </summary>
		/// <param name="nameFile">Имя файла</param>
		private void ExistsDirectory(string nameFile)
		{
			try
			{
				if (!Directory.Exists(PATH_LOG))
					Directory.CreateDirectory(PATH_LOG);
				if (!File.Exists(PATH_LOG + nameFile))
					File.Create(PATH_LOG + nameFile).Close();
			}
			catch (Exception ex) { System.Windows.Forms.MessageBox.Show("Не удается получить доступ к файловой системе. По ошибке: " + ex.Message, "Ошибка"); }
		}
		/// <summary>
		/// Возвращает текущее имя файла лога
		/// </summary>
		/// <returns></returns>
		public string GetCurrentFileName()
		{
			return System.DateTime.Now.ToShortDateString().Replace(".", "_") + ".log";
		}
	}
}
