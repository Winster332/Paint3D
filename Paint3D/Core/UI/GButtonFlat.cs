using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Paint3D.Core.UI
{
	public class GButtonFlat : Button
	{
		public GButtonFlat(Control parent)
		{
			parent.Controls.Add(this);
			this.FlatStyle = FlatStyle.Flat;
			this.FlatAppearance.BorderSize = 0;
			this.BackColor = Color.FromArgb(0, 140, 200);
			this.Text = "Button";
			this.Font = new Font("Calibri", 10);
			this.ForeColor = Color.FromArgb(250,250,250);
		}
	}
}
