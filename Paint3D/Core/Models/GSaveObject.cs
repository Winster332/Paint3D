using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint3D.Core.Models
{
	[Serializable]
	public class GSaveObject
	{
		public enum TYPE { Cube, Sphere };
		public TYPE type;
		public float x;
		public float y;
		public float z;
		public float rad;
		public float r;
		public float g;
		public float b;
	}
}
