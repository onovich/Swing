using MortiseFrame.Swing.Generic;
using UnityEngine;

namespace MortiseFrame.Swing.Easing
{

    public static class EasingHelper
    {

        delegate float EasingHandler(float t, float start, float end, float duration, EasingMode mode);

        public static Vector2 Easing2D(float timePassed, Vector2 start, Vector2 end, float duration, EasingType type, EasingMode mode = EasingMode.None)
        {
            var x = Easing(timePassed, start.x, end.x, duration, type, mode);
            var y = Easing(timePassed, start.y, end.y, duration, type, mode);
            return new Vector2(x, y);
        }

        public static Vector3 Easing3D(float timePassed, Vector3 start, Vector3 end, float duration, EasingType type, EasingMode mode)
        {
            var x = Easing(timePassed, start.x, end.x, duration, type, mode);
            var y = Easing(timePassed, start.y, end.y, duration, type, mode);
            var z = Easing(timePassed, start.z, end.z, duration, type, mode);
            return new Vector3(x, y, z);
        }

        public static float Easing(float timePassed, float start, float end, float duration, EasingType type, EasingMode mode)
        {
            EasingHandler easingFunction = GetEasingFunction(type, mode);
            var t = timePassed;
            var b = start;
            var c = end - start;
            var d = duration;
            return easingFunction(t, b, c, d, mode);
        }

        private static EasingHandler GetEasingFunction(EasingType type, EasingMode mode)
        {

            if (type == EasingType.Sine)
            {
                return EasingFunction.Sine;
            }
            if (type == EasingType.Quad)
            {
                return EasingFunction.Quad;
            }
            if (type == EasingType.Cubic)
            {
                return EasingFunction.Cubic;
            }
            if (type == EasingType.Quart)
            {
                return EasingFunction.Quart;
            }
            if (type == EasingType.Quint)
            {
                return EasingFunction.Quint;
            }
            if (type == EasingType.Expo)
            {
                return EasingFunction.Expo;
            }
            if (type == EasingType.Circ)
            {
                return EasingFunction.Circ;
            }
            if (type == EasingType.Back)
            {
                return EasingFunction.Back;
            }
            if (type == EasingType.Elastic)
            {
                return EasingFunction.Elastic;
            }
            if (type == EasingType.Bounce)
            {
                return EasingFunction.Bounce;
            }
            return EasingFunction.Linear;

        }

    }

}