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
		private GWorld world;
		private GGraphics graphics;
		private GManagerFile managerFile;
		private GLogger logger;
		private GControlCamera controlCamera;
		/// <summary>
		/// Создает объект класса GEngine
		/// </summary>
		/// <param name="parent">Parent элемент в котором создается GEngine</param>
		public GEngine(System.Windows.Forms.Control parent)
		{
			this.parent = parent;
			
			logger = new GLogger();
			graphics = new GGraphics(this);
			managerFile = new GManagerFile();
			controlCamera = new GControlCamera(parent);
			world = new GWorld(this);

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
			controlCamera.Update();
			graphics.BeginRender();

			world.Draw();

			graphics.EndRender();
		}

		#region GET
		public System.Windows.Forms.Control GetControl()
		{
			return this.parent;
		}
		/// <summary>
		/// Возвращает объект мира
		/// </summary>
		/// <returns></returns>
		public GWorld GetWorld()
		{
			return this.world;
		}
		/// <summary>
		/// Возвращает ширину области рендеринга
		/// </summary>
		/// <returns></returns>
		public float GetWidth()
		{
			return this.parent.Width;
		}
		/// <summary>
		/// Возвращает высоту области рендеринга
		/// </summary>
		/// <returns></returns>
		public float GetHeight()
		{
			return this.parent.Height;
		}
		/// <summary>
		/// Возвращает объект для логгирования данных
		/// </summary>
		/// <returns></returns>
		public GLogger GetLogger()
		{
			return logger;
		}
		/// <summary>
		/// Возвращает объект управления файлами
		/// </summary>
		/// <returns></returns>
		public GManagerFile GetManagerFile()
		{
			return managerFile;
		}
		/// <summary>
		/// Возвращает объект класс для работы с OpenGL
		/// </summary>
		/// <returns></returns>
		public GGraphics GetGraphics()
		{
			return graphics;
		}
		/// <summary>
		/// Возвращает объект для работы с камерой OpenGL
		/// </summary>
		/// <returns></returns>
		public GControlCamera GetCamera()
		{
			return controlCamera;
		}
		#endregion
	}
}
