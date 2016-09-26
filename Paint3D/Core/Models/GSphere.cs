using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint3D.Core.Models
{
	public class GSphere : GBaseModel
	{
		public GSphere(GEngine engine, float x, float y, float z, float rad, float r, float g, float b) : base(engine)
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
			engine.GetGraphics().DrawSphere(x, y, z, rad, r, g, b);
		}
	}
}
