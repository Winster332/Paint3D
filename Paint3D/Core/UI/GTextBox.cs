using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Paint3D.Core.UI
{
	public class GTextBox : Panel
	{
		private TextBox textBox;
		private Button button;

		public override string Text
		{
			get
			{
				return textBox.Text;
			}
			set
			{
				textBox.Text = value;
			}
		}

		public GTextBox(Control parent)
		{
			textBox = new TextBox();
			button = new Button();

			button.Width = 20;
			button.Height = textBox.Height-1;
			button.Top = 1;
			button.Left = 150 - button.Width+1;
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			button.Font = new Font("Arial", 10);
			button.Text = "x";
			button.BackColor = Color.FromArgb(200,200,200);

			textBox.Location = new Point(1, 1);
			textBox.Width = 150 - button.Width;
			textBox.Font = new Font("Arial", 12);
			this.Width = 152;
			this.Height = textBox.Height;
			this.textBox.BorderStyle = BorderStyle.None;
			this.TabStop = false;
			textBox.TabStop = false;
			button.TabStop = false;
			this.Height = 21;
			textBox.ForeColor = Color.FromArgb(100, 100, 100);
			button.Click += (o, e) => {
				textBox.Text = "";
			};

			this.Controls.Add(textBox);
			this.Controls.Add(button);

			parent.Controls.Add(this);
		}
	}
}
