using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Paint3D.Core
{
	public class GGraphics
	{
		private GEngine engine;
		public GGraphics(GEngine engine)
		{
			this.engine = engine;

			Glut.glutInit();
			Glut.glutInitDisplayMode(Glut.GLUT_DOUBLE | Glut.GLUT_RGBA);

			Gl.glViewport(0, 0, (int)engine.GetWidth(), (int)engine.GetHeight());
			
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glClearColor(1, 1, 1, 1);
		}
		public void BeginRender()
		{
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(100, engine.GetWidth() / engine.GetHeight(), 0.1f, 1000.0f);
			Glu.gluLookAt(engine.GetCamera().posX, engine.GetCamera().posY, engine.GetCamera().posZ,
				engine.GetCamera().lookX, engine.GetCamera().lookY, engine.GetCamera().lookZ,
				0, 1, 0);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
		}
		public void EndRender()
		{
			Gl.glFlush();
			engine.GetControl().Invalidate();
		}
		public void DrawBox(float x, float y, float z, float rad, float r, float g, float b)
		{
			Gl.glColor3f(r, g, b);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glPushMatrix();
			Gl.glTranslatef(x, y, z);
			Glut.glutWireCube(rad);
			Gl.glPopMatrix();
		}
		public void DrawPolygon()
		{
		}
		public void DrawSphere(float x, float y, float z, float rad, float r, float g, float b)
		{
			Gl.glColor3f(r, g, b);
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glPushMatrix();
			Gl.glTranslatef(x, y, z);
			Glut.glutWireSphere(rad, 32, 32);
			Gl.glPopMatrix();
		}
	}
}
