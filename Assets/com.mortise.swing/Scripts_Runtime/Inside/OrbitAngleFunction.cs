using System;
using System.Collections.Generic;
using UnityEngine;

namespace MortiseFrame.Swing {

    public static class OrbitAngleFunction {

        internal static float GetRoundMinAngle3D(Vector3 start, Vector3 end, Vector3 center) {
            Vector3 relativeStart = start - center;
            Vector3 relativeEnd = end - center;

            Vector3 rotationAxis = Vector3.Cross(relativeStart, relativeEnd);
            float angle = Vector3.SignedAngle(relativeStart, relativeEnd, rotationAxis);
            return angle;
        }

        internal static float GetRoundMinAngle2D(Vector2 start, Vector2 end, Vector2 center) {
            Vector2 relativeStart = start - center;
            Vector2 relativeEnd = end - center;

            float angle = Vector2.SignedAngle(relativeStart, relativeEnd);
            return angle;
        }

        internal static float GetRoundFullAngle3D(Vector3 start, Vector3 end, Vector3 center, bool isClockwise = true) {
            Vector3 relativeStart = start - center;
            Vector3 relativeEnd = end - center;

            Vector3 rotationAxis = Vector3.Cross(relativeStart, relativeEnd);
            float angle = Vector3.SignedAngle(relativeStart, relativeEnd, rotationAxis);
            if (isClockwise) {
                if (angle > 0) {
                    angle -= 360;
                }
            } else {
                if (angle < 0) {
                    angle += 360;
                }
            }
            return angle;
        }

        internal static float GetRoundFullAngle2D(Vector2 start, Vector2 end, Vector2 center, bool isClockwise = true) {
            Vector2 relativeStart = start - center;
            Vector2 relativeEnd = end - center;

            float angle = Vector2.SignedAngle(relativeStart, relativeEnd);
            if (isClockwise) {
                if (angle > 0) {
                    angle -= 360;
                }
            } else {
                if (angle < 0) {
                    angle += 360;
                }
            }
            return angle;
        }

    }

}