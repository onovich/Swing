using UnityEngine;
using MortiseFrame.Swing.Easing;
using MortiseFrame.Swing.Generic;

namespace MortiseFrame.Swing.Sample {

    public class EasingSample : MonoBehaviour {

        public EasingType type = EasingType.Linear;
        public EasingMode mode = EasingMode.EaseIn;
        public float duration = 1f;
        public Vector3 startPosition = Vector3.left * 5f;
        public Vector3 endPosition = Vector3.right * 5f;
        Vector3 currentPosition;
        Vector3 pos => transform.position;
        private LineRenderer lineRenderer;
        public int resolution = 50;

        private float currentTime = 0f;

        private void Awake() {
            // 获取LineRenderer组件
            lineRenderer = GetComponent<LineRenderer>();
            // 设置曲线的分辨率
            lineRenderer.positionCount = resolution;
            lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.1f, 1, 0.1f);

        }
        private void Update() {
            currentTime += Time.deltaTime;
            if (currentTime > duration) {
                currentTime = 0;
            }
            currentPosition = EasingFacade.Easing3D(currentTime, startPosition, endPosition, duration, type, mode);

            for (int i = 0; i < duration; i++) {
                for (int j = 0; j < resolution; j++) {
                    float time = j / (float)(resolution - 1) * duration;
                    float value = EasingFacade.Easing(time, 0f, 1f, duration, type, mode);
                    Vector3 position = new Vector3(time, value, 0f) + transform.position;
                    lineRenderer.SetPosition(j, position);
                }
            }

        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pos + startPosition, pos + endPosition);
            Gizmos.color = Color.red;
            var cube = new Vector3(0.5f, 0.5f, 0.1f);
            Gizmos.DrawCube(pos + currentPosition, cube);
        }

    }
}