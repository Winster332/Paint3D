////////////////////////////
/// Класс для управления камерой
/// устройства OpenGL
////////////////////////////

using System;

namespace Paint3D.Core
{
	public class GControlCamera
	{
		private System.Windows.Forms.Control parent;
		private bool KEY_A = false;
		private bool KEY_D = false;
		private bool KEY_W = false;
		private bool KEY_S = false;
		private bool KEY_SPACE = false;
		private bool KEY_CTRL = false;
		private float speedMove;
		public float lookX;
		public float lookY;
		public float lookZ;
		public float posX;
		public float posY;
		public float posZ;
		public bool IsMouseLock;
		/// <summary>
		/// Инициализирует класс
		/// </summary>
		/// <param name="parent">Парент элемент</param>
		public GControlCamera(System.Windows.Forms.Control parent)
		{
			this.parent = parent;
			
			IsMouseLock = true;
			speedMove = 0.05f;
			lookX = 0;
			lookY = 0;
			lookZ = -1;

			posX = 0;
			posY = 0;
			posZ = 0;

			parent.MouseMove += Parent_MouseMove;
			parent.KeyDown += Parent_KeyDown;
			parent.KeyUp += Parent_KeyUp;
		}
		private void Parent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case System.Windows.Forms.Keys.A: this.KEY_A = true; break;
				case System.Windows.Forms.Keys.D: this.KEY_D = true; break;
				case System.Windows.Forms.Keys.W: this.KEY_W = true; break;
				case System.Windows.Forms.Keys.S: this.KEY_S = true; break;
				case System.Windows.Forms.Keys.Space: this.KEY_SPACE = true; break;
				case System.Windows.Forms.Keys.ControlKey: this.KEY_CTRL = true; break;
			}
		}
		private void Parent_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case System.Windows.Forms.Keys.A: this.KEY_A = false; break;
				case System.Windows.Forms.Keys.D: this.KEY_D = false; break;
				case System.Windows.Forms.Keys.W: this.KEY_W = false; break;
				case System.Windows.Forms.Keys.S: this.KEY_S = false; break;
				case System.Windows.Forms.Keys.Space: this.KEY_SPACE = false; break;
				case System.Windows.Forms.Keys.ControlKey: this.KEY_CTRL = false; break;
			}
		}
		private void Parent_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (IsMouseLock)
			{
				float x = e.X - parent.Width / 2;
				float y = e.Y - parent.Height / 2;

				float nx = (float)Math.Cos(x / 50) * 40;
				float ny = -(float)Math.Sin(y / 150) * 100;
				float nz = (float)Math.Sin(x / 50) * 40;

				lookX = nx;
				lookY = ny;
				lookZ = nz;

				if (e.X > parent.Width / 2 + 230)
				{
					System.Windows.Forms.Cursor.Position = new System.Drawing.Point((parent.Width / 2) - 70,
						e.Y + 30);
				}
				if (e.X < 5)
				{
					System.Windows.Forms.Cursor.Position = new System.Drawing.Point((parent.Width / 2) + 70,
						e.Y + 30);
				}
			}
		}
		/// <summary>
		/// Обновление видового вектора
		/// </summary>
		public void Update()
		{
			if (IsMouseLock)
			{
				if (this.KEY_A)
				{
					this.posX += lookZ / 500;
					this.posZ -= lookX / 500;
				}
				if (this.KEY_D)
				{
					this.posX -= lookZ / 500;
					this.posZ += lookX / 500;
				}
				if (this.KEY_W)
				{
					this.posX += lookX / 500;
					this.posY += lookY / 500;
					this.posZ += lookZ / 500;
				}
				if (this.KEY_S)
				{
					this.posX -= lookX / 500;
					this.posY -= lookY / 500;
					this.posZ -= lookZ / 500;
				}
				if (this.KEY_SPACE)
				{
					this.posY += speedMove;
				}
				if (this.KEY_CTRL)
				{
					this.posY -= speedMove;
				}
			}
		}
	}
}
