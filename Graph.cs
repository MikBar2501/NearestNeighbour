using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace NearestNeighbour
{

    public struct Point
    {
        public Vector2 point;
        public int id;

        public Point(int id, Vector2 point)
        {
            this.id = id;
            this.point = point;
        }
    }

    class Graph
    {
        public UInt32 dimension;
        public bool isSymetric;
        public float[,] edgeWeight;
        public Point[] points;

        public Graph(Point[] points, bool isSymetric = true)
        {
            this.points = points;
            this.isSymetric = isSymetric;
            this.dimension = (UInt32)points.Length;
            edgeWeight = SetWeight(points);

        }

        public float[,] SetWeight(Point[] points)
        {
            float[,] weightArray = new float[points.Length, points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                    {
                        weightArray[i, j] = 0;
                    }
                    else
                    {
                        weightArray[i, j] = Vector2.Distance(points[i].point, points[j].point);
                    }
                }
            }
            return weightArray;
        }
    }
}
