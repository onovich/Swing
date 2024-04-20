using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MortiseFrame.Swing {

    public static class OrbitHelper {

        // Min Orbital
        public static Vector3 Round3DHorizontalMin(Vector3 start, Vector3 end, Vector3 center, float current, float duration, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None) {
            Vector3 relativeStart = start - center;
            Vector3 relativeEnd = end - center;

            Vector3 rotationAxis = Vector3.up;
            float angle = OrbitAngleFunction.GetRoundMinAngle3D(start, end, center);
            float currentAngle = EasingHelper.Easing(0, angle, current, duration, easingType, easingMode);

            Quaternion rotation = Quaternion.AngleAxis(currentAngle, rotationAxis);
            Vector3 rotatedVector = rotation * relativeStart + center;

            return rotatedVector;
        }

        public static Vector3 RoundMin3D(Vector3 start, Vector3 end, Vector3 center, float current, float duration, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None) {
            Vector3 relativeStart = start - center;
            Vector3 relativeEnd = end - center;

            Vector3 rotationAxis = Vector3.Cross(relativeStart, relativeEnd);
            float angle = OrbitAngleFunction.GetRoundMinAngle3D(start, end, center);
            float currentAngle = EasingHelper.Easing(0, angle, current, duration, easingType, easingMode);

            Quaternion rotation = Quaternion.AngleAxis(currentAngle, rotationAxis);
            Vector3 rotatedVector = rotation * relativeStart + center;

            return rotatedVector;
        }

        public static Vector2 RoundMin2D(Vector2 start, Vector2 end, Vector2 center, float current, float duration, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None) {
            Vector2 relativeStart = start - center;

            float angle = OrbitAngleFunction.GetRoundMinAngle2D(start, end, center);
            float currentAngle = EasingHelper.Easing(0, angle, current, duration, easingType, easingMode);
            float radian = currentAngle * Mathf.Deg2Rad;

            Vector2 rotatedVector = new Vector2(
                relativeStart.x * Mathf.Cos(radian) - relativeStart.y * Mathf.Sin(radian),
                relativeStart.x * Mathf.Sin(radian) + relativeStart.y * Mathf.Cos(radian)
            ) + center;

            return rotatedVector;
        }


        // Full Orbital
        public static Vector3 Round3DHorizontalFull(Vector3 start, Vector3 end, Vector3 center, float current, float duration, bool isClockwise = true, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None) {
            Vector3 relativeStart = start - center;
            Vector3 relativeEnd = end - center;

            Vector3 rotationAxis = Vector3.up;
            float angle = OrbitAngleFunction.GetRoundFullAngle3D(start, end, center, isClockwise);
            float currentAngle = EasingHelper.Easing(0, angle, current, duration, easingType, easingMode);

            Quaternion rotation = Quaternion.AngleAxis(currentAngle, rotationAxis);
            Vector3 rotatedVector = rotation * relativeStart + center;

            return rotatedVector;
        }

        public static Vector3 RoundFull3D(Vector3 start, Vector3 end, Vector3 center, float current, float duration, bool isClockwise = true, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None) {
            Vector3 relativeStart = start - center;
            Vector3 relativeEnd = end - center;

            Vector3 rotationAxis = Vector3.Cross(relativeStart, relativeEnd);
            float angle = OrbitAngleFunction.GetRoundFullAngle3D(start, end, center, isClockwise);
            float currentAngle = EasingHelper.Easing(0, angle, current, duration, easingType, easingMode);

            Quaternion rotation = Quaternion.AngleAxis(currentAngle, rotationAxis);
            Vector3 rotatedVector = rotation * relativeStart + center;

            return rotatedVector;
        }

        public static Vector2 RoundFull2D(Vector2 start, Vector2 end, Vector2 center, float current, float duration, bool isClockwise = true, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None) {
            Vector2 relativeStart = start - center;

            float angle = OrbitAngleFunction.GetRoundFullAngle2D(start, end, center, isClockwise);
            float currentAngle = EasingHelper.Easing(0, angle, current, duration, easingType, easingMode);
            float radian = currentAngle * Mathf.Deg2Rad;

            Vector2 rotatedVector = new Vector2(
                relativeStart.x * Mathf.Cos(radian) - relativeStart.y * Mathf.Sin(radian),
                relativeStart.x * Mathf.Sin(radian) + relativeStart.y * Mathf.Cos(radian)
            ) + center;

            return rotatedVector;
        }

    }

}