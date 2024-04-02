using System;

namespace MortiseFrame.Swing {

    public static class WaveHelper {

        delegate float WaveHandler(float frequency, float amplitude, float current, float phase = 0);

        public static float Wave(float frequency, float amplitude, float current, float phase, WaveType waveType) {
            WaveHandler waveFunction = GetWaveFunction(waveType);
            return waveFunction(frequency, amplitude, current, phase);
        }

        private static WaveHandler GetWaveFunction(WaveType waveType) {
            switch (waveType) {
                case WaveType.Sine:
                    return WaveFunction.SineWave;
                case WaveType.Square:
                    return WaveFunction.SquareWave;
                case WaveType.Sawtooth:
                    return WaveFunction.SawtoothWave;
                case WaveType.Triangle:
                    return WaveFunction.TriangleWave;
                default:
                    throw new ArgumentOutOfRangeException(nameof(waveType), $"Unsupported wave type: {waveType}");
            }
        }


    }
}