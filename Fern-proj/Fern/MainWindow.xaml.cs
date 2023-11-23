using System;
using System.Windows;
using System.Windows.Controls;
using FernNamespace;

namespace FernNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize the canvas with default values
            BarnsleyFern barnsleyFern = new BarnsleyFern(canvas, 1, 40, 0.3);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            // Handle button click, you can recreate the BarnsleyFern object with current slider values
            double size = sizeSlider.Value;
            double redux = reduxSlider.Value;
            double bias = biasSlider.Value;
            BarnsleyFern barnsleyFern = new BarnsleyFern(canvas, size, redux, bias);
        }

        private void SizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void ReduxSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void BiasSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }
    }
}
