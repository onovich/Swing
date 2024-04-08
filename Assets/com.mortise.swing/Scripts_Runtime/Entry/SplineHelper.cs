using System;
using UnityEngine;

namespace MortiseFrame.Swing {

    public static class SplineHelper {

        public static Vector2 Easing(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float current, float duration, SplineType splineType) {
            if (duration <= 0f) {
                throw new ArgumentException("Duration Must Be Greater Than Zero.", nameof(duration));
            }

            var t = current / duration;
            t = Mathf.Clamp01(t);

            Matrix4x4 splineMatrix = SplineMatrix.GetSplineMatrix(splineType);

            Vector4 T = new Vector4(1, t, t * t, t * t * t);
            Vector4 Px = new Vector4(p0.x, p1.x, p2.x, p3.x);
            Vector4 Py = new Vector4(p0.y, p1.y, p2.y, p3.y);

            float x = Vector4.Dot(splineMatrix * T, Px);
            float y = Vector4.Dot(splineMatrix * T, Py);

            return new Vector2(x, y);
        }

        public static float CalculateSplineLength(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, SplineType splineType, int segments = 100) {
            float length = 0f;
            Vector2 prevPoint = SplineHelper.Easing(p0, p1, p2, p3, 0, 1, splineType);
            Vector2 nextPoint;

            for (int i = 1; i <= segments; i++) {
                nextPoint = Easing(p0, p1, p2, p3, i, segments, splineType);
                length += Vector2.Distance(prevPoint, nextPoint);
                prevPoint = nextPoint;
            }

            return length;
        }

    }

}