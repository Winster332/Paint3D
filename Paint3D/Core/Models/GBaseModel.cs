using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint3D.Core.Models
{
	public abstract class GBaseModel
	{
		public float x;
		public float y;
		public float z;
		public float rad;
		public float r;
		public float g;
		public float b;
		protected GEngine engine;

		public GBaseModel(GEngine engine)
		{
			this.engine = engine;
		}
		public abstract void Draw();
	}
}
