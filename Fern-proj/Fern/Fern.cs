using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FernNamespace
{
    class BarnsleyFern
    {
        private static Random random = new Random();

        private double canvasWidth;
        private double canvasHeight;
        private double size;
        private double redux;
        private double turnBias;

        public BarnsleyFern(Canvas canvas, double size, double redux, double turnBias)
        {
            this.size = size;
            this.redux = redux;
            this.turnBias = turnBias;

            // Store the canvas size
            canvasWidth = canvas.ActualWidth;
            canvasHeight = canvas.ActualHeight;

            canvas.Children.Clear();
            DrawBarnsleyFern(canvas);
        }

        private void DrawBarnsleyFern(Canvas canvas)
        {
            double x = 0, y = 0;

            for (int i = 0; i < 20000; i++)
            {
                double nextX, nextY;

                double r = random.NextDouble();
                if (r <= 0.01)
                {
                    nextX = 0;
                    nextY = 0.16 * y;
                }
                else if (r <= 0.08)
                {
                    nextX = 0.2 * x - 0.26 * y;
                    nextY = 0.23 * x + 0.22 * y + 1.6;
                }
                else if (r <= 0.15)
                {
                    nextX = -0.15 * x + 0.28 * y;
                    nextY = 0.26 * x + 0.24 * y + 0.44;
                }
                else
                {
                    nextX = 0.85 * x + 0.04 * y;
                    nextY = -0.04 * x + 0.85 * y + 1.6;
                }

                x = nextX;
                y = nextY;

                DrawPoint(canvas, x, y);
            }
        }

        private void DrawPoint(Canvas canvas, double x, double y)
        {
            Ellipse point = new Ellipse();
            point.Width = size;
            point.Height = size;
            point.Fill = Brushes.Green;

            // Center the point on the canvas
            double centerX = canvasWidth / 2 -size/2;
           
            double adjustedY;

            if (Math.Abs(turnBias) < 1e-10)
            {
                // If turnBias is too close to zero, set a reasonable default value
                adjustedY = canvasHeight - size - y * (size / 2);
            }
            else
            {
                adjustedY = canvasHeight - size - y * (size / (turnBias * 2));
            }
            double adjustedX = centerX + x * (canvasWidth / (redux * 2));
         

            Canvas.SetLeft(point, adjustedX);
            Canvas.SetTop(point, adjustedY);

            canvas.Children.Add(point);
        }
    }
}
