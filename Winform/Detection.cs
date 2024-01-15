using Compunet.YoloV8;
using Compunet.YoloV8.Data;
using Emgu.CV;

namespace Telle.YoloV8DotNet.Winform;

internal class Detection : IDisposable
{
    YoloV8? _predictor;
    private bool disposedValue;
    readonly string _fileNameModel = "yolov8n.onnx";
    enum DetectClasses
    {
        ceiling,
        damaged,
        pallet,
        wall
    }

    public Detection()
    {
        _predictor = new YoloV8(new ModelSelector(_fileNameModel));
    }

    public IDetectionResult Detect(ImageSelector imageSelector)
    {
        if (_predictor == null)
            throw new InvalidOperationException(nameof(_predictor));
        return _predictor.Detect(imageSelector);
    }


    public static void PaintResultsInImage(Image image, IDetectionResult detectionResult, float confidence)
    {
        var graphics = Graphics.FromImage(image);

        foreach (var box in detectionResult.Boxes.Where(a => a.Confidence > confidence))
        {
            var color = Color.Blue;
            switch (box.Class.Id)
            {
                case (int)DetectClasses.ceiling:
                    color = Color.Yellow;
                    break;
                case (int)DetectClasses.damaged:
                    color = Color.Red;
                    break;
                case (int)DetectClasses.pallet:
                    color = Color.Green;
                    break;
                case (int)DetectClasses.wall:
                    color = Color.Yellow;
                    break;
            }

            var pen = new Pen(color, 3);

            var rect = new Rectangle(box.Bounds.X, box.Bounds.Y, box.Bounds.Width, box.Bounds.Height);
            graphics.DrawRectangle(pen, rect);
            graphics.DrawString($"{box.Class.Name} {box.Confidence:0.00}", new Font("Arial", 15), new SolidBrush(color), box.Bounds.X, box.Bounds.Y);
        }
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                _predictor?.Dispose();
            }

            _predictor = null;
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
