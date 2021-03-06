﻿using System;
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

        int gameSizeY = 5;
        int gameSizeX = 5;
        float gameDepth = -10.0f;

        float balMovX = -0.1f;
        float balMovY = -0.1f;

        private double ballX = 0;
        private double ballY = 0;
        private double ballz = 0;
        
        private float bed1X = -5.0f;
        private float bed1Y = 3.4f;
        private float bed1Z = -12.0f;

        private float bed2X = 5.0f;
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
                bed2Y += 0.1f;
            }
            if (pressedKey == Key.Down)
            {
                bed2Y -= 0.1f;
            }
            if (pressedKey == Key.W)
            {
                bed1Y += 0.1f;
            }
            if (pressedKey == Key.S)
            {
                bed1Y -= 0.1f;
            }
            if (pressedKey == Key.Escape)
            {
                Environment.Exit(1);
            }
        }
        


        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = new OpenGL();

            ballX -= balMovX;
            ballY -= balMovY;
            if (Convert.ToInt32(ballX) == -gameSizeX)
            {
                balMovX = -0.08f;
            }
            else if (Convert.ToInt32(ballX) == gameSizeX)
            {
                balMovX = 0.08f;
            }
            if (Convert.ToInt32(ballY) == -gameSizeY)
            {
                balMovY = -0.03f;
            }
            else if (Convert.ToInt32(ballY) == gameSizeY)
            {
                balMovY = 0.03f;
            }
            

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.Translate(gameX, gameY, gameZ);
            gameRect(gl);

            Ball(gl);
            Bed(gl,bed1X, bed1Y, bed1Z, 0.2f, 1.8f);
            Bed(gl,bed2X, bed2Y, bed2Z, 0.2f, 1.8f);
            
            gl.Flush();

        }


        private void OpenGl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            
        }

        private void Ball(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_LINE_LOOP);
            for (int i = 0; i <= 10; i++)
            {
                double angle = (2 * Math.PI * i / 10);
                double x = Math.Cos(angle) - ballX;
                double y = Math.Sin(angle) - ballY;

                gl.Vertex(x, y, ballz);
            }
            gl.End();
        }

        private void Bed(OpenGL gl, double x, double y, double z, double width, double height)
        {
            gl.Begin(OpenGL.GL_QUADS);
           

            gl.Color(1f, 1f, 1f, 1f);
            gl.Vertex(x, y + height, -6.0f);
            gl.Vertex(x, y, -6.0f);
            gl.Vertex(x + width, y, -6.0f);
            gl.Vertex(x + width, y + height, -6.0f);


            gl.End();
        }

        private void gameRect(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_QUADS);

            
            gl.Color(0.5f, 1f, 1f, 1f);
            gl.Vertex(1, 1, -11.0f);
            gl.Vertex(1, 1, -11.0f);
            gl.Vertex(1, 1, -11.0f);
            gl.Vertex(1, 1, -11.0f);


            gl.End();
        }
    }
}
