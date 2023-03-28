using MortiseFrame.Swing.Generic;
using UnityEngine;

namespace MortiseFrame.Swing.Easing {

    public static class EasingFacade {

        delegate float EasingHandler(float t, float start, float end, float duration, EasingMode mode);

        public static Vector2 Easing2D(float timePassed, Vector2 start, Vector2 end, float duration, EasingType type, EasingMode mode) {
            var x = Easing(timePassed, start.x, end.x, duration, type, mode);
            var y = Easing(timePassed, start.y, end.y, duration, type, mode);
            return new Vector2(x, y);
        }

        public static Vector3 Easing3D(float timePassed, Vector3 start, Vector3 end, float duration, EasingType type, EasingMode mode) {
            var x = Easing(timePassed, start.x, end.x, duration, type, mode);
            var y = Easing(timePassed, start.y, end.y, duration, type, mode);
            var z = Easing(timePassed, start.z, end.z, duration, type, mode);
            return new Vector3(x, y, z);
        }

        public static float Easing(float timePassed, float start, float end, float duration, EasingType type, EasingMode mode) {
            EasingHandler easingFunction = GetEasingFunction(type, mode);
            var t = timePassed;
            var b = start;
            var c = end - start;
            var d = duration;
            return easingFunction(t, b, c, d, mode);
        }

        private static EasingHandler GetEasingFunction(EasingType type, EasingMode mode) {

            if (type == EasingType.Sine) {
                return EasingHelper.Sine;
            }
            if (type == EasingType.Quad) {
                return EasingHelper.Quad;
            }
            if (type == EasingType.Cubic) {
                return EasingHelper.Cubic;
            }
            if (type == EasingType.Quart) {
                return EasingHelper.Quart;
            }
            if (type == EasingType.Quint) {
                return EasingHelper.Quint;
            }
            if (type == EasingType.Expo) {
                return EasingHelper.Expo;
            }
            if (type == EasingType.Circ) {
                return EasingHelper.Circ;
            }
            if (type == EasingType.Back) {
                return EasingHelper.Back;
            }
            if (type == EasingType.Elastic) {
                return EasingHelper.Elastic;
            }
            if (type == EasingType.Bounce) {
                return EasingHelper.Bounce;
            }
            return EasingHelper.Linear;

        }

    }

}