namespace Paint3D
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.glControl = new Tao.Platform.Windows.SimpleOpenGlControl();
			this.SuspendLayout();
			// 
			// glControl
			// 
			this.glControl.AccumBits = ((byte)(0));
			this.glControl.AutoCheckErrors = false;
			this.glControl.AutoFinish = false;
			this.glControl.AutoMakeCurrent = true;
			this.glControl.AutoSwapBuffers = true;
			this.glControl.BackColor = System.Drawing.Color.Black;
			this.glControl.ColorBits = ((byte)(32));
			this.glControl.DepthBits = ((byte)(16));
			this.glControl.Location = new System.Drawing.Point(109, 152);
			this.glControl.Name = "glControl";
			this.glControl.Size = new System.Drawing.Size(50, 50);
			this.glControl.StencilBits = ((byte)(0));
			this.glControl.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 341);
			this.Controls.Add(this.glControl);
			this.Name = "Form1";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private Tao.Platform.Windows.SimpleOpenGlControl glControl;
	}
}

