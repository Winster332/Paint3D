using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Paint3D.Core.UI
{
	public class GMenuPanel : Panel
	{
		private GButtonFlat[] but;
		public event EventHandler Clicks;
		public GMenuPanel(Control parent, GEngine engine)
		{
			this.BackColor = Color.FromArgb(50, 50, 50);
			this.Width = 180;
			this.Height = 85;
			parent.Controls.Add(this);
			this.Left = parent.Width - this.Width;
			this.Top = parent.Height - this.Height;
			this.TabStop = false;

			but = new GButtonFlat[4];
			int intent = 0;
			for (int i = 0; i < 2; i++)
			{
				but[i] = new GButtonFlat(this);
				but[i].Top += intent;
				but[i].TabStop = false;
				but[i].Width = 90;
				but[i].Click += (o, e) => { Clicks(o, e); };

				intent += but[i].Height;
			}
			intent = 0;
			for (int i = 2; i < 4; i++)
			{
				but[i] = new GButtonFlat(this);
				but[i].Top += intent;
				but[i].Width = 90;
				but[i].Left = but[i].Width;
				but[i].TabStop = false;
				but[i].Click += (o, e) => { Clicks(o, e); };

				intent += but[i].Height;
			}
			but[0].Text = "Продолжить";
			but[1].Text = "Сохранить";
			but[2].Text = "Загрузить";
			but[3].Text = "Выйти";

			this.Visible = false;
		}
	}
}
