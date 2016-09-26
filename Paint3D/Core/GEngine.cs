////////////////////////////
/// Главный класс который предоставляет API
/// для всего пространства имен Core
////////////////////////////

using System;

namespace Paint3D.Core
{
	public class GEngine
	{
		private System.Windows.Forms.Control parent;
        private System.Windows.Forms.Timer update;
		private GGraphics graphics;
		private GManagerFile managerFile;
		private GLogger logger;
		/// <summary>
		/// Создает объект класса GEngine
		/// </summary>
		/// <param name="parent">Parent элемент в котором создается GEngine</param>
		public GEngine(System.Windows.Forms.Control parent)
		{
			this.parent = parent;
			graphics = new GGraphics();
			managerFile = new GManagerFile();
			logger = new GLogger();

			update = new System.Windows.Forms.Timer();
			update.Interval = 30;
			update.Tick += Update_Tick;
		}
		public void Run()
		{
			update.Start();
		}
		private void Update_Tick(object sender, EventArgs e)
		{
			// TODO: Need write loop function
		}

		#region GET
		public GLogger GetLogger()
		{
			return logger;
		}
		public GManagerFile GetManagerFile()
		{
			return managerFile;
		}
		public GGraphics GetGraphics()
		{
			return graphics;
		}
		#endregion
	}
}
