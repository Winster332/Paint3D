using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint3D.Core.UI
{
	public class GMessageShow : Panel
	{
		private Label label;
		private Timer update;
		private int ticks = 50;
		private bool isShow = false;
		public GMessageShow(Control parent)
		{
			parent.Controls.Add(this);
			label = new Label();
			this.Width = 300;
			this.Height = 30;
			this.Controls.Add(label);
			this.BackColor = Color.FromArgb(192,192,192);
			this.label.Text = "Test text";
			this.label.ForeColor = Color.FromArgb(100, 100, 100);
			this.label.Width = this.Width;
			this.label.Font = new Font("Arial", 14);
			this.label.Location = new Point(10, 4);
			this.Left = parent.Width / 2 - this.Width / 2;
			this.Top = -this.Height;

			update = new Timer();
			update.Interval = 30;
			update.Tick += (o, e) =>
			{
				if (isShow)
				{
					if (this.Top < 0)
						this.Top += 1;
					else
					{
						if (ticks > 0)
							ticks--;
						else isShow = false;
					}
				}
				else
				{
					if (this.Top > -this.Height)
						this.Top -= 1;
					else update.Stop();
				}
			};
		}
		public void ShowMessage(string text)
		{
			ticks = 50;
			isShow = true;
			label.Text = text;
			update.Start();
		}
	}
}
