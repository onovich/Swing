using MortiseFrame.Abacus;

namespace MortiseFrame.Swing {

    public static class SplineHelper {

        // Bézier 贝塞尔曲线: 牵一发动全身(全局可控性强)，不一定通过控制点(形状更自由)
        public static FVector2 BezierSpline(FVector2[] pArr, float current, float duration) {
            var t = current / duration;
            t = FMath.Clamp01(t); // 确保t在0和1之间
            return BezierRecursive(pArr, t);
        }

        // - 递归
        static FVector2 BezierRecursive(FVector2[] points, float t) {
            if (points.Length == 1) {
                return points[0];
            }

            FVector2[] nextPoints = new FVector2[points.Length - 1];
            for (int i = 0; i < nextPoints.Length; i++) {
                nextPoints[i] = FVector2.Lerp(points[i], points[i + 1], t);
            }

            return BezierRecursive(nextPoints, t);
        }

        // Catmull-Rom 卡特莫尔-罗姆: 牵一发不动全身(局部可控性强)，必定通过控制点(不错过关键帧)
        public static FVector2 CatmullRom(FVector2 p0, FVector2 p1, FVector2 p2, FVector2 p3, float current, float duration) {
            var t = current / duration;
            t = FMath.Clamp01(t);
            var t2 = t * t;
            var t3 = t2 * t;

            // Catmull-Rom 曲线矩阵
            float b0 = 0.5f * (-t3 + 2f * t2 - t);
            float b1 = 0.5f * (3f * t3 - 5f * t2 + 2f);
            float b2 = 0.5f * (-3f * t3 + 4f * t2 + t);
            float b3 = 0.5f * (t3 - t2);

            return p0 * b0 + p1 * b1 + p2 * b2 + p3 * b3;
        }

        // B-Spline: 牵一发不动全身(局部可控性强)，不一定通过控制点(形状更自由)

        // Hermite: 牵一发不动全身(局部可控性强)，必定通过控制点(不错过关键帧), 可以精确控制切线方向(依赖切线方向和长度)
        public static FVector2 Interpolate(FVector2 p0, FVector2 p1, FVector2 t0, FVector2 t1, float t) {
            // 计算Hermite基函数值
            float h00 = 2 * t * t * t - 3 * t * t + 1;
            float h10 = t * t * t - 2 * t * t + t;
            float h01 = -2 * t * t * t + 3 * t * t;
            float h11 = t * t * t - t * t;

            // 计算并返回曲线上的点
            return p0 * h00 + t0 * h10 + p1 * h01 + t1 * h11;
        }

    }

}