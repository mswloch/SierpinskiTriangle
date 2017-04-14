using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SierpinskiTriange
{
    public class Triangle
    {
        public Point a;
        public Point b;
        public Point c;

        List<Triangle> triangles;
        private double Length;

        public Triangle(Point begin, double length)
        {
            triangles = new List<Triangle>();
            Length = length;

            a = begin;
            b = new Point(a.X + Length, a.Y);
            c = new Point(a.X + Length / 2, a.Y + (Length * Math.Sqrt(3) / 2));            
        }

        /// <summary>
        /// Calculating smaller triangles
        /// </summary>
        public void AddTriangles()
        {
            Triangle t1 = new Triangle(a, Length/2);
            Triangle t2 = new Triangle(new Point(a.X+(Length/2),a.Y), Length/2);
            Triangle t3 = new Triangle(new Point((a.X+c.X)/2,(a.Y+c.Y)/2), Length / 2);

            triangles = new List<Triangle>() { t1, t2, t3 };
        }

        /// <summary>
        /// Recurse method for generating new triangles
        /// </summary>
        /// <param name="i">Recurse index, recursion counter</param>
        public void Recurse(int i)
        {
            AddTriangles();
            if (i != 0)
                triangles.ForEach(x => x.Recurse(i-1));
        }

        /// <summary>
        /// Getting all triangles from tree
        /// </summary>
        /// <returns></returns>
        public List<Triangle> GetRecurseTriangles()
        {
            List<Triangle> list = new List<Triangle>();
            
            list.AddRange(triangles);
            triangles.ForEach(x => list.AddRange(x.GetRecurseTriangles()));

            return list;
        }
    }
}
