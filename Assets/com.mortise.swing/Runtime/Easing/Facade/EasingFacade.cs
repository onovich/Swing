using MortiseFrame.Swing.Generic;

namespace MortiseFrame.Swing.Easing {

    public static class EasingFacade {

        delegate float EasingHandler(float t, float start, float end, float duration, EasingMode mode);

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