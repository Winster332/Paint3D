using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Paint3D.Core.UI
{
	public class GPropPanel : Panel
	{
		private GButtonFlat[] but;
		public GTextBox[] textBox;
		public event EventHandler Clicks;
		public GPropPanel(Control parent)
		{
			this.BackColor = Color.FromArgb(50, 50, 50);
			this.Width = 280;
			this.Height = 85;
			parent.Controls.Add(this);
			this.Left = 0;
			this.Top = parent.Height - this.Height;
			this.TabStop = false;

			but = new GButtonFlat[2];
			but[0] = new GButtonFlat(this);
			but[1] = new GButtonFlat(this);
			but[0].TabStop = false;
			but[1].TabStop = false;
			but[0].Text = "Кубик";
			but[1].Text = "Сфера";
			but[1].Top = but[0].Height;
			but[0].Click += (o, e) =>
			{
				Clicks(o, e);
			};
			but[1].Click += (o, e) =>
			{
				Clicks(o, e);
			};

			textBox = new GTextBox[2];
			textBox[0] = new GTextBox(this);
			textBox[0].Location = new Point(this.Width - textBox[0].Width, 0);
			textBox[1] = new GTextBox(this);
			textBox[1].Location = new Point(this.Width - textBox[0].Width, but[1].Top+4);
			textBox[0].Text = "R:0.0 G:1.0 B:0.0";
			textBox[1].Text = "1";

			Label[] lab = new Label[2];
			lab[0] = new Label();
			lab[0].ForeColor = Color.FromArgb(192,192,192);
			lab[0].Text = "Цвет: ";
			lab[0].Left = but[0].Right;
			lab[0].Top = 3;
			this.Controls.Add(lab[0]);

			lab[1] = new Label();
			lab[1].ForeColor = Color.FromArgb(192, 192, 192);
			lab[1].Text = "Размер: ";
			lab[1].Left = but[1].Right;
			lab[1].Top = but[1].Top+5;
			this.Controls.Add(lab[1]);

			this.Visible = false;
		}
		public float GetSize()
		{
			return float.Parse(textBox[1].Text);
		}
		public float[] GetColor()
		{
			float[] res = new float[3];

			res[0] = float.Parse(textBox[0].Text.Substring(textBox[0].Text.IndexOf("R:")+1, 3));
			res[1] = float.Parse(textBox[0].Text.Substring(textBox[0].Text.IndexOf("G:")+1, 3));
			res[2] = float.Parse(textBox[0].Text.Substring(textBox[0].Text.IndexOf("B:")+1, 3));

			return res;
		}
	}
}
