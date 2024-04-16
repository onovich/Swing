using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MortiseFrame.Swing {

    public static class OrbitHelper {

        public static Vector3 Round3D(Vector3 start, Vector3 end, Vector3 center, float current, float duration, bool isClockwise = true, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None) {
            Vector3 relativeStart = start - center;
            Vector3 relativeEnd = end - center;

            Vector3 rotationAxis = Vector3.Cross(relativeStart, relativeEnd);
            float angle = GetRoundAngle3D(start, end, center, isClockwise);
            float currentAngle = EasingHelper.Easing(0, angle, current, duration, easingType, easingMode);

            Quaternion rotation = Quaternion.AngleAxis(currentAngle, rotationAxis);
            Vector3 rotatedVector = rotation * relativeStart + center;

            return rotatedVector;
        }

        public static float GetRoundAngle3D(Vector3 start, Vector3 end, Vector3 center, bool isClockwise = true) {
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

        public static Vector2 Round2D(Vector2 start, Vector2 end, Vector2 center, float current, float duration, bool isClockwise = true, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None) {
            Vector2 relativeStart = start - center;
            Vector2 relativeEnd = end - center;

            float angle = GetRoundAngle2D(start, end, center, isClockwise);
            float currentAngle = EasingHelper.Easing(0, angle, current, duration, easingType, easingMode);
            float radian = currentAngle * Mathf.Deg2Rad;

            // 应用旋转
            Vector2 rotatedVector = new Vector2(
                relativeStart.x * Mathf.Cos(radian) - relativeStart.y * Mathf.Sin(radian),
                relativeStart.x * Mathf.Sin(radian) + relativeStart.y * Mathf.Cos(radian)
            ) + center;

            return rotatedVector;
        }

        public static float GetRoundAngle2D(Vector2 start, Vector2 end, Vector2 center, bool isClockwise = true) {
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