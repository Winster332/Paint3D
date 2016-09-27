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
		private Core.UI.GMenuPanel menuPanel;
		private Core.UI.GPropPanel propPanel;
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
						ShowUI();
					}
					else
					{
						engine.GetCamera().IsMouseLock = true;
						Cursor.Hide();
						HideUI();
					}
				}
			};

			menuPanel = new Core.UI.GMenuPanel(glControl, engine);
			menuPanel.Clicks += (o, ee) => 
			{
				string name = ((Button)o).Text.ToString();

				switch (name)
				{
					case "Продолжить":
						engine.GetCamera().IsMouseLock = true;
						Cursor.Hide();
						HideUI();
						glControl.Focus();
						break;
					case "Загрузить":
						OpenFileDialog ofd = new OpenFileDialog();
						ofd.Multiselect = false;
						DialogResult res = ofd.ShowDialog(this);
						if (res == DialogResult.OK)
						{
							string file = ofd.FileName;

							List<Core.Models.GSaveObject> objs = (List<Core.Models.GSaveObject>)
							engine.GetManagerFile().GetDataXMLFile(file, typeof(List<Core.Models.GSaveObject>));

							for (int i = 0; i < objs.Count; i++)
							{
								if (objs[i].type == Core.Models.GSaveObject.TYPE.Cube)
									engine.GetWorld().AddBox(objs[i].x, objs[i].y, objs[i].z, objs[i].rad, objs[i].r, objs[i].g, objs[i].b);
								else if (objs[i].type == Core.Models.GSaveObject.TYPE.Sphere)
									engine.GetWorld().AddSphere(objs[i].x, objs[i].y, objs[i].z, objs[i].rad, objs[i].r, objs[i].g, objs[i].b);
							}
						}
					
						break;
					case "Сохранить":
						Core.UI.SaveObjects so = new Core.UI.SaveObjects(engine);
						so.ShowDialog(this);
						break;
					case "Выйти": Application.Exit(); break;
				}
			};
			bool IsCube = true;

			propPanel = new Core.UI.GPropPanel(glControl);
			propPanel.Clicks += (o, ee) =>
			{
				string name = ((Button)o).Text.ToString();
				double[] color = propPanel.GetColor();

				switch (name)
				{
					case "Кубик":
						IsCube = true;
						break;
					case "Сфера":
						IsCube = false;
						break;
                };

				this.Text = name + " размер[" + propPanel.GetSize() + "] Цвет[R:" + color[0] + " G:" + color[1] + " B:" + color[2] + "]";
			};

			glControl.MouseDown += (o, ee) =>
			{
				if (engine.GetCamera().IsMouseLock)
				{
					double[] color = propPanel.GetColor();
					float size = propPanel.GetSize();
                    glControl.Focus();
					
					if (IsCube)
						engine.GetWorld().AddBox(engine.GetCamera().posX + engine.GetCamera().lookX / 50, engine.GetCamera().posY + engine.GetCamera().lookY / 50, engine.GetCamera().posZ + engine.GetCamera().lookZ / 50, size, (float)color[0], (float)color[1], (float)color[2]);
					else engine.GetWorld().AddSphere(engine.GetCamera().posX + engine.GetCamera().lookX / 50, engine.GetCamera().posY + engine.GetCamera().lookY / 50, engine.GetCamera().posZ + engine.GetCamera().lookZ / 50, size, (float)color[0], (float)color[1], (float)color[2]);
				}
			};
		}

		private void ShowUI()
		{
			menuPanel.Visible = true;
			propPanel.Visible = true;
			
		}
		private void HideUI()
		{
			menuPanel.Visible = false;
			propPanel.Visible = false;
		}
	}
}
