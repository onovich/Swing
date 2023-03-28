using NUnit.Framework;
using UnityEngine;
using MortiseFrame.Swing.Generic;
using MortiseFrame.Swing.Easing;

namespace MortiseFrame.Swing.Test {
    public class EasingTest {

        [Test]
        [TestCase(0, 0, 1, 1, EasingType.Linear, EasingMode.EaseIn, ExpectedResult = 0)]
        [TestCase(0.5f, 0, 1, 1, EasingType.Linear, EasingMode.EaseIn, ExpectedResult = 0.5f)]
        [TestCase(1, 0, 1, 1, EasingType.Linear, EasingMode.EaseIn, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 1, EasingType.Quad, EasingMode.EaseIn, ExpectedResult = 0)]
        [TestCase(0.5f, 0, 1, 1, EasingType.Quad, EasingMode.EaseIn, ExpectedResult = 0.25f)]
        [TestCase(1, 0, 1, 1, EasingType.Quad, EasingMode.EaseIn, ExpectedResult = 1)]
        [TestCase(0, 0, 1, 1, EasingType.Sine, EasingMode.EaseIn, ExpectedResult = 0)]
        [TestCase(0.5f, 0, 1, 1, EasingType.Sine, EasingMode.EaseIn, ExpectedResult = 0.29289323f)]
        [TestCase(1, 0, 1, 1, EasingType.Sine, EasingMode.EaseIn, ExpectedResult = 1)]
        public float Test(float timePassed, float start, float end, float duration, EasingType type, EasingMode mode) {
            return EasingFacade.Easing(timePassed, start, end, duration, type, mode);
        }

    }
}


