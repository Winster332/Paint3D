using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Paint3D.Core.UI;

namespace Paint3D.Core.UI
{
	public partial class SaveObjects : Form
	{
		private GTextBox textBox;
		private GEngine engine;
        public SaveObjects(GEngine engine)
		{
			InitializeComponent();
			this.engine = engine;
		}

		private void SaveObjects_Load(object sender, EventArgs e)
		{
			this.Width = 320;
			this.Height = 100;
			Label lab = new Label();
			lab.ForeColor = Color.FromArgb(192, 192, 192);
			lab.Text = "Имя проекта: ";
			lab.Left = 0;
			lab.Top = 3;
			this.Controls.Add(lab);

			textBox = new GTextBox(this);
			textBox.Location = new Point(150, 1);

			GButtonFlat but = new GButtonFlat(this);
			but.Text = "Сохранить";
			but.Location = new Point(this.Width / 2 - but.Width / 2, 30);
			but.Click += (o, ee) =>
			{
				List<Models.GSaveObject> objects = new List<Models.GSaveObject>();
				var mod = engine.GetWorld().GetListModels();
				for (int i = 0; i < mod.Count; i++)
				{
					Models.GSaveObject obj = new Models.GSaveObject();
					obj.x = mod[i].x;
					obj.y = mod[i].y;
					obj.z = mod[i].z;
					obj.r = mod[i].r;
					obj.g = mod[i].g;
					obj.b = mod[i].b;
					obj.rad = mod[i].rad;

					if (mod[i].GetType() == typeof(Models.GBox))
						obj.type = Models.GSaveObject.TYPE.Cube;
					else if (mod[i].GetType() == typeof(Models.GSphere))
						obj.type = Models.GSaveObject.TYPE.Sphere;

					objects.Add(obj);
				}

				engine.GetManagerFile().SetDataXMLFile(textBox.Text, objects);
				this.Close();
			};
		}
	}
}
