using System;
using MortiseFrame.Abacus;

namespace MortiseFrame.Swing {

    internal static class WaveFunction {

        // 正弦波
        internal static float SineWave(float frequency, float amplitude, float current, float phase) {
            return amplitude * (float)MathF.Sin(2 * MathF.PI * (frequency * current) + phase);
        }

        // 方波
        internal static float SquareWave(float frequency, float amplitude, float current, float phase) {
            return amplitude * MathF.Sign(MathF.Sin(2 * MathF.PI * (frequency * current) + phase));
        }

        // 锯齿波
        internal static float SawtoothWave(float frequency, float amplitude, float current, float phase) {
            float t = (frequency * current + phase / (2 * MathF.PI)) % 1;
            return amplitude * (2 * t - 1);
        }

        // 三角波
        internal static float TriangleWave(float frequency, float amplitude, float current, float phase) {
            float t = (frequency * current + phase / (2 * MathF.PI)) % 1;
            return amplitude * (4 * MathF.Abs(t - 0.5f) - 1);
        }


    }

}

