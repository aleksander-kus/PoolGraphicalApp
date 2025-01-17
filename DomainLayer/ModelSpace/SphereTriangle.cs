﻿using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace DomainLayer.ModelSpace
{
    public class SphereTriangle : ModelTriangle
    {
        public ModelPoint SphereCenter { get; set; } = new ModelPoint(0, 0, 0);
        public SphereTriangle(List<ModelPoint> points, Color color): base(points, color)
        {
        }
        public override Vector3 GetNormalVectorForPoint(ModelPoint point)
        {
            var color = Vector3.Normalize(point.Coordinates - SphereCenter.Coordinates);
            return color;
        }

        public override ModelTriangle NewFromPoints(List<ModelPoint> points)
        {
            return new SphereTriangle(points, Color)
            {
                SphereCenter = SphereCenter
            };
        }
    }
}
