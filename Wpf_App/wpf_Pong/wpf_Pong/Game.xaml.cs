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
using System.Threading;
using SharpGL;

namespace wpf_Pong
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        private float gameY = 0.0f;
        private float gameX = 0.0f;
        private float gameZ = -10.0f;

        private double ballX = 0;
        private double ballY = 0;
        
        private float bed1X = 0.0f;
        private float bed1Y = 3.4f;
        private float bed1Z = -12.0f;

        private float bed2X = 0.0f;
        private float bed2Y = 3.4f;
        private float bed2Z = -12.0f;
              
        private bool firsttime = false;

        public Game(/*dictionary meegeven(players - pos,kleur,naam etc..*/)
        {
            InitializeComponent();
            this.KeyDown += Game_KeyDown;
            this.Closing += Game_Closing;
        }

        void Game_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(1);
        }

        void Game_KeyDown(object sender, KeyEventArgs e)
        {
            Key pressedKey = e.Key;

            if (pressedKey == Key.Up)
            {
                bed1Y -= 0.1f;
            }
            if (pressedKey == Key.Down)
            {
                bed1Y += 0.1f;
            }
            if (pressedKey == Key.W)
            {
                bed2Y += 0.01f;
            }
            if (pressedKey == Key.S)
            {
                bed2Y -= 0.01f;
            }
        }
        


        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            
            ballY += 0.01f;
            ballX += 0.01f;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(-1.5f, 0.0f, -6.0f);

            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i <= 10; i++)
            {
                double angle = (2 * Math.PI * i / 10);
                double x = Math.Cos(angle) - ballX;
                double y = Math.Sin(angle) - ballY;

                gl.Vertex(x, y, -93.0f);  
            }
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(0.5f, 1f, 1f, 1f);
            gl.Vertex(0.8f, 1.0f - bed1Y, -6.0f);
            gl.Vertex(0.8f, -1.0f - bed1Y, -6.0f);
            gl.Vertex(1.0f, -1.0f - bed1Y, -6.0f);
            gl.Vertex(1.0f, 1.0f - bed1Y, -6.0f);


            gl.End();
            gl.Flush();

        }


        private void OpenGl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            
        }
    }
}
