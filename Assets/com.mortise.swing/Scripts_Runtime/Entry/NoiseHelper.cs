using System;
using System.Runtime.InteropServices;
using MortiseFrame.Abacus;

namespace MortiseFrame.Swing {

    public static class NoiseHelper {

        public static float WhiteNoise(Random random, float amplitude) {
            return (float)(random.NextDouble() * 2 - 1) * amplitude;
        }

    }

}