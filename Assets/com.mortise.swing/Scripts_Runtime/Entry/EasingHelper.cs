using UnityEngine;

namespace MortiseFrame.Swing {

    public static class EasingHelper {

        delegate float EasingHandler(float start, float end, float current, float duration, EasingMode mode);

        public static Color EasingColor(Color start, Color end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None) {
            var r = Easing(start.r, end.r, current, duration, type, mode);
            var g = Easing(start.g, end.g, current, duration, type, mode);
            var b = Easing(start.b, end.b, current, duration, type, mode);
            var a = Easing(start.a, end.a, current, duration, type, mode);
            return new Color(r, g, b, a);
        }

        public static Color32 EasingColor32(Color32 start, Color32 end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None) {
            var r = EasingByte(start.r, end.r, current, duration, type, mode);
            var g = EasingByte(start.g, end.g, current, duration, type, mode);
            var b = EasingByte(start.b, end.b, current, duration, type, mode);
            var a = EasingByte(start.a, end.a, current, duration, type, mode);
            return new Color32(r, g, b, a);
        }

        public static Vector2 Easing2D(Vector2 start, Vector2 end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None) {
            var x = Easing(start.x, end.x, current, duration, type, mode);
            var y = Easing(start.y, end.y, current, duration, type, mode);
            return new Vector2(x, y);
        }

        public static Vector3 Easing3D(Vector3 start, Vector3 end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None) {
            var x = Easing(start.x, end.x, current, duration, type, mode);
            var y = Easing(start.y, end.y, current, duration, type, mode);
            var z = Easing(start.z, end.z, current, duration, type, mode);
            return new Vector3(x, y, z);
        }

        public static float Easing(float start, float end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None) {
            EasingHandler easingFunction = GetEasingFunction(type, mode);
            var t = current;
            var b = start;
            var c = end - start;
            var d = duration;
            return easingFunction(t, b, c, d, mode);
        }

        public static byte EasingByte(byte start, byte end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None) {
            EasingHandler easingFunction = GetEasingFunction(type, mode);
            var t = current;
            var b = start;
            var c = end - start;
            var d = duration;
            return (byte)easingFunction(t, b, c, d, mode);
        }

        private static EasingHandler GetEasingFunction(EasingType type, EasingMode mode = EasingMode.None) {

            if (type == EasingType.Sine) {
                return EasingFunction.Sine;
            }
            if (type == EasingType.Quad) {
                return EasingFunction.Quad;
            }
            if (type == EasingType.Cubic) {
                return EasingFunction.Cubic;
            }
            if (type == EasingType.Quart) {
                return EasingFunction.Quart;
            }
            if (type == EasingType.Quint) {
                return EasingFunction.Quint;
            }
            if (type == EasingType.Expo) {
                return EasingFunction.Expo;
            }
            if (type == EasingType.Circ) {
                return EasingFunction.Circ;
            }
            if (type == EasingType.Back) {
                return EasingFunction.Back;
            }
            if (type == EasingType.Elastic) {
                return EasingFunction.Elastic;
            }
            if (type == EasingType.Bounce) {
                return EasingFunction.Bounce;
            }
            return EasingFunction.Linear;

        }

    }

}