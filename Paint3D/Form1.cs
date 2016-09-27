using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint3D
{
	public partial class Form1 : Form
	{
		private Core.GEngine engine;
		public Form1()
		{
			InitializeComponent();
			glControl.InitializeContexts();

			Cursor.Hide();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			glControl.Location = new Point(0, 0);
			glControl.Size = new Size(this.Width, this.Height);
			engine = new Core.GEngine(glControl);
			engine.Run();

			glControl.KeyDown += (o, ee) =>
			{
				if (ee.KeyCode == Keys.Escape)
				{
					if (engine.GetCamera().IsMouseLock)
					{
						engine.GetCamera().IsMouseLock = false;
						Cursor.Show();
					}
					else
					{
						engine.GetCamera().IsMouseLock = true;
						Cursor.Hide();
					}
				}
			};

			engine.GetWorld().AddBox(1, 1, -2, 1, 1, 0, 1);
			engine.GetWorld().AddSphere(0, 0, -2, 1, 0, 1, 1);

			var tb = new Core.UI.GMessageShow(glControl);
			tb.ShowMessage("Stas");
			//.Location = new Point(100, 100);
		}
	}
}
