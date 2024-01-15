using Compunet.YoloV8;
using Emgu.CV;
using SixLabors.ImageSharp;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Management;


namespace Telle.YoloV8DotNet.Winform
{
    public partial class Form1 : Form
    {
        VideoCapture? _videoCapture;
        readonly Detection _detection = new();
        bool _isRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            GetAllConnectedCameras();
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            GetAllConnectedCameras();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (_isRunning)
            {
                StopWebCam();
                return;
            }
            _isRunning = true;
            btnStart.Text = "Stop";
            _videoCapture = new VideoCapture(cbCamera.SelectedIndex);
            Application.Idle += Application_Idle;

        }

        private void BtnImage_Click(object sender, EventArgs e)
        {
            if (_isRunning)            
                StopWebCam();
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                using var fileStream = new FileStream(openFileDialog1.FileName, FileMode.Open);
                Detect(GetConfidence(), new Bitmap(fileStream));
            }
        }

        private void BtnDirectory_Click(object sender, EventArgs e)
        {
            if (_isRunning)
                StopWebCam();
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                foreach (var file in files)
                {
                    using var fileStream = new FileStream(file, FileMode.Open);
                    var bitmap = Detect(GetConfidence(), new Bitmap(fileStream));
                    bitmap.Save(Path.Combine(folderBrowserDialog1.SelectedPath, Path.GetFileNameWithoutExtension(file)  + "_result." + Path.GetExtension(file)));
                }
            }
        }

        private void Application_Idle(object? sender, EventArgs e)
        {
            if (_videoCapture == null)
                throw new InvalidOperationException("VideoCapture is null");

            float confidence = GetConfidence();
            using var nextFrame = _videoCapture.QueryFrame();
            if (nextFrame != null)
            {
                var bitmap = nextFrame.ToBitmap();
                Detect(confidence, bitmap);
            }
        }
        #endregion

        #region Methods


        private void GetAllConnectedCameras()
        {
            cbCamera.Items.Clear();
            using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Camera')");
            foreach (var device in searcher.Get())
            {
                if (device["Caption"] is string name)
                    cbCamera.Items.Add(name);
                cbCamera.SelectedIndex = 0;
            }
        }

        private float GetConfidence()
        {
            var confidence = 0.4f;
            if (float.TryParse(txtConfidence.Text, out var confidenceValue))
                confidence = confidenceValue;
            return confidence;
        }

        private Bitmap Detect(float confidence, Bitmap bitmap)
        {

            using MemoryStream ms = new();
            var stopWatch = Stopwatch.StartNew();
            bitmap.Save(ms, ImageFormat.Jpeg);
            ms.Position = 0;
            var imageselector = new ImageSelector(ms);
            var result = _detection.Detect(imageselector);
            Detection.PaintResultsInImage(bitmap, result, confidence);
            pictureBox.Image = bitmap;
            stopWatch.Stop();
            label1.Text = $"Time: {stopWatch.ElapsedMilliseconds:0.00} ms";
            var textResults = result.Boxes.Select(a => $"   {a.Class.Name} {a.Confidence:0.00}");
            label2.Text = $"Result : {Environment.NewLine}{string.Join(Environment.NewLine, textResults)}";
            return bitmap;
        }


        private void StopWebCam()
        {
            _isRunning = false;
            btnStart.Text = "Start";
            Application.Idle -= Application_Idle;
            _videoCapture?.Dispose();
            _videoCapture = null;
            pictureBox.Image = null;
            label1.Text = "Time: ";
            label2.Text = "Result: ";
        }
        #endregion

    }
}
