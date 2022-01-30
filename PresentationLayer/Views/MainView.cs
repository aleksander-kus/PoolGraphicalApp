﻿using PresentationLayer.Presenters;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class MainView : Form, IMainView
    {
        private MainPresenter presenter;
        private Timer timer = new();
        public MainView()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;

        }

        private void Timer_Tick(object sender, System.EventArgs e) => presenter.Rotate();

        public MainPresenter Presenter { set => presenter = value; }

        public int CanvasWidth => canvasBox.Width;

        public int CanvasHeight => canvasBox.Height;

        public Image CanvasImage { set => canvasBox.Image = value; }

        public void RedrawCanvas() => canvasBox.Invalidate();

        private void MainView_Load(object sender, System.EventArgs e)
        {
            presenter.Fov = fovBar.Value;
            fovLabel.Text = $"Fov: {fovBar.Value}";
            //timer.Start();
        }

        private void MainView_Resize(object sender, System.EventArgs e)
        {
            presenter.LoadCanvasDimensions();
        }

        private void fovBar_ValueChanged(object sender, System.EventArgs e)
        {
            presenter.Fov = fovBar.Value;
            fovLabel.Text = $"Fov: {fovBar.Value}";
        }
    }
}
