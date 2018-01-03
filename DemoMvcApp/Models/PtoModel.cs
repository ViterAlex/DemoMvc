using System.Collections.Generic;
using System.Windows;

namespace DemoMvcApp.Models
{
    public class PtoModel
    {
        private List<Point> _points = new List<Point>();
        private static PtoModel _instance;
        public List<Point> Points => _points;
        public double Radius;
        public bool DrawCircles;
        public static PtoModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PtoModel();
                }
                return _instance;
            }
        }

        private PtoModel()
        {
            _points.Add(new Point(double.NaN, double.NaN));
        }

        public Point Add(Point pt, bool isFirstPoint = false)
        {
            if (_points.Count >= 4)
            {
                _points.Clear();
                _points.Add(new Point(double.NaN, double.NaN));
            }
            if (isFirstPoint)
            {
                _points[0] = pt;
            }
            else if (!_points[0].IsEmpty())
            {
                _points.Add(pt);
            }
            return pt;
        }

        public static Point MidPoint(Point pt1, Point pt2)
        {
            return DivideLine(pt1, pt2, 1);
        }

        public static Point DivideLine(Point pt1, Point pt2, double proportion)
        {
            var x = (pt1.X + pt2.X * proportion) / (1 + proportion);
            var y = (pt1.Y + pt2.Y * proportion) / (1 + proportion);
            return new Point(x, y);
        }
    }

    internal static class Helper
    {
        internal static bool IsEmpty(this Point pt)
        {
            return double.IsNaN(pt.X) && double.IsNaN(pt.Y);
        }
    }
}