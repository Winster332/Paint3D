using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint3D.Core.Models
{
	public class GBox : GBaseModel
	{
        public GBox(GEngine engine, float x, float y, float z, float rad, float r, float g, float b) : base(engine)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.rad = rad;
			this.r = r;
			this.g = g;
			this.b = b;
		}

		public override void Draw()
		{
			engine.GetGraphics().DrawBox(x, y, z, rad, r, g, b);
		}
	}
}
