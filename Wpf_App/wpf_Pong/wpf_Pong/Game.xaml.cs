using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SharpGL;

namespace wpf_Pong
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
        }
        
        float y = 0.0f;
        float x = 3.4f;
        float z = -12.0f;

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            if (Keyboard.IsKeyDown(Key.Up))
            {
                y += 0.1f;
            }

            if (Keyboard.IsKeyDown(Key.Down))
            {
                y -= 0.1f;
            }

            if (Keyboard.IsKeyDown(Key.Right))
            {
                x += 0.1f;
            }

            if (Keyboard.IsKeyDown(Key.Left))
            {
                x -= 0.1f;
            }

            if (Keyboard.IsKeyDown(Key.A))
            {
                z += 0.1f;
            }

            if (Keyboard.IsKeyDown(Key.Z))
            {
                z -= 0.1f;
            }

            Point position = Mouse.GetPosition(this);
            //y = float.Parse((position.Y/100).ToString());
   
            //  Get the OpenGL instance that's been passed to us.
            OpenGL gl = args.OpenGL;

            //  Clear the color and depth buffers.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Reset the modelview matrix.
            gl.LoadIdentity();

            //  Move the geometry into a fairly central position.
            // gl.Translate(-1.5f, 0.0f, -6.0f);

            //  Reset the modelview.
            gl.LoadIdentity();

            //  Move into a more central position.
            gl.Translate(x, y, z);

            //  Rotate the cube.
            //gl.Rotate(rquad, 1.0f, 1.0f, 1.0f);

            //  Provide the cube colors and geometry.
            gl.Begin(OpenGL.GL_QUADS);
     
            gl.Color(1f,1f,1f,1f);
            gl.Vertex(1.0f, 1.0f, 1.0f);
            gl.Vertex(0.8f, 1.0f, 1.0f);
            gl.Vertex(0.8f, -1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);

            gl.End();

            //  Flush OpenGL.
            gl.Flush();
        }
    }
}
