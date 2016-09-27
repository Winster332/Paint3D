using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paint3D.Core.Models;

namespace Paint3D.Core
{
	public class GWorld
	{
		private GEngine engine;
		private List<GBaseModel> models;
		public GWorld(GEngine engine)
		{
			this.engine = engine;
			this.models = new List<GBaseModel>();
		}
		public void Draw()
		{
			for (int i = 0; i < models.Count; i++)
				models[i].Draw();
		}
		public void AddBox(float x, float y, float z, float rad, float r, float g, float b)
		{
			models.Add(new GBox(engine, x, y, z, rad, r, g, b));
		}
		public void AddSphere(float x, float y, float z, float rad, float r, float g, float b)
		{
			models.Add(new GSphere(engine, x, y, z, rad, r, g, b));
		}
		public List<GBaseModel> GetListModels()
		{
			return this.models;
		}
	}
}
