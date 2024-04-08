using System;
using System.Collections.Generic;
using UnityEngine;

namespace MortiseFrame.Swing {

    public static class SplineMatrix {

        static readonly Matrix4x4 BezierMatrix = new Matrix4x4(
           new Vector4(-1, 3, -3, 1),
           new Vector4(3, -6, 3, 0),
           new Vector4(-3, 3, 0, 0),
           new Vector4(1, 0, 0, 0)
       );

        static readonly Matrix4x4 CatmullRomMatrix = new Matrix4x4(
           new Vector4(-0.5f, 1.5f, -1.5f, 0.5f),
           new Vector4(1.0f, -2.5f, 2.0f, -0.5f),
           new Vector4(-0.5f, 0.0f, 0.5f, 0.0f),
           new Vector4(0.0f, 1.0f, 0.0f, 0.0f)
       );

        static readonly Matrix4x4 HermiteMatrix = new Matrix4x4(
           new Vector4(2.0f, -2.0f, 1.0f, 1.0f),
           new Vector4(-3.0f, 3.0f, -2.0f, -1.0f),
           new Vector4(0.0f, 0.0f, 1.0f, 0.0f),
           new Vector4(1.0f, 0.0f, 0.0f, 0.0f)
       );

        static readonly Matrix4x4 BSplineMatrix = new Matrix4x4(
           new Vector4(1, 4, 1, 0) * (1f / 6f),
           new Vector4(-3, 0, 3, 0) * (1f / 6f),
           new Vector4(3, -6, 3, 0) * (1f / 6f),
           new Vector4(-1, 3, -3, 1) * (1f / 6f)
       );

        internal static Matrix4x4 GetSplineMatrix(SplineType splineType) {
            switch (splineType) {
                case SplineType.Bezier:
                    return BezierMatrix;
                case SplineType.CatmullRom:
                    return CatmullRomMatrix;
                case SplineType.Hermite:
                    return HermiteMatrix;
                case SplineType.BSpline:
                    return BSplineMatrix;
                default:
                    throw new ArgumentException("Invalid spline type.", nameof(splineType));
            }
        }

    }

}