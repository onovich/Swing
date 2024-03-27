using UnityEngine;
using MortiseFrame.Swing;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MortiseFrame.Swing.Sample {

    public class EasingSample : MonoBehaviour {

        // Config
        EasingType type;
        EasingMode mode;
        public float duration = 1f;
        public int resolution = 50;

        // Render
        public LineRenderer lineRenderer;
        public MeshRenderer boxRender;
        public MeshFilter boxFilter;
        public Dropdown EasingTypeDropdown;
        public Dropdown EasingModeDropdown;
        public Transform nod1;
        public Transform nod2;

        // Lift Cycle
        float currentTime = 0f;

        private void Awake() {

            // Init Line 
            lineRenderer.positionCount = resolution;
            lineRenderer.widthCurve = AnimationCurve.Linear(0, 0.1f, 1, 0.1f);

            UpdateLine();

            Mesh mesh = new Mesh();

            // Draw Box
            // - 定义边框的厚度
            float thickness = 0.05f;

            Vector3[] vertices = new Vector3[24];

            // - 定义外矩形的四个顶点
            vertices[0] = new Vector3(-1f - thickness, -1f - thickness, 0); // 左下角
            vertices[1] = new Vector3(1f + thickness, -1f - thickness, 0); // 右下角
            vertices[2] = new Vector3(-1f - thickness, 1f + thickness, 0); // 左上角
            vertices[3] = new Vector3(1f + thickness, 1f + thickness, 0); // 右上角

            // - 定义内矩形的四个顶点
            vertices[4] = new Vector3(-1f + thickness, -1f + thickness, 0);
            vertices[5] = new Vector3(1f - thickness, -1f + thickness, 0);
            vertices[6] = new Vector3(-1f + thickness, 1f - thickness, 0);
            vertices[7] = new Vector3(1f - thickness, 1f - thickness, 0);

            // - 为四条边定义顶点
            vertices[8] = vertices[0];
            vertices[9] = vertices[1];
            vertices[10] = vertices[4];
            vertices[11] = vertices[5];

            vertices[12] = vertices[1];
            vertices[13] = vertices[3];
            vertices[14] = vertices[5];
            vertices[15] = vertices[7];

            vertices[16] = vertices[3];
            vertices[17] = vertices[2];
            vertices[18] = vertices[7];
            vertices[19] = vertices[6];

            vertices[20] = vertices[2];
            vertices[21] = vertices[0];
            vertices[22] = vertices[6];
            vertices[23] = vertices[4];

            mesh.vertices = vertices;

            // - 定义八个三角形来组成四条边
            int[] tris = new int[24] {
                8, 10, 9, 10, 11, 9, // 下边
                12, 14, 13, 14, 15, 13, // 右边
                16, 18, 17, 18, 19, 17, // 上边
                20, 22, 21, 22, 23, 21 // 左边
            };

            mesh.triangles = tris;
            boxFilter.mesh = mesh;

            // Draw Choice
            var typeNames = System.Enum.GetNames(typeof(EasingType));
            var modeNames = System.Enum.GetNames(typeof(EasingMode));

            EasingTypeDropdown.options.Clear();
            EasingModeDropdown.options.Clear();

            for (int i = 0; i < typeNames.Length; i++) {
                EasingTypeDropdown.options.Add(new Dropdown.OptionData(typeNames[i]));
            }

            for (int i = 0; i < modeNames.Length; i++) {
                EasingModeDropdown.options.Add(new Dropdown.OptionData(modeNames[i]));
            }

            EasingTypeDropdown.value = 0;
            EasingModeDropdown.value = 0;

            EasingTypeDropdown.onValueChanged.AddListener((int index) => {
                type = (EasingType)index;
                UpdateLine();
            });

            EasingModeDropdown.onValueChanged.AddListener((int index) => {
                mode = (EasingMode)index;
                UpdateLine();
            });

        }

        private void UpdateLine() {

            for (int i = 0; i < resolution; i++) {
                var x = EasingHelper.Easing(-1f, 1f, i, resolution, EasingType.Linear, EasingMode.None);
                var y = EasingHelper.Easing(-1f, 1f, i, resolution, type, mode);
                Vector3 position = new Vector3(x, y, 0f) + transform.position;
                lineRenderer.SetPosition(i, position);
            }

        }

        private void Update() {

            // Draw Line
            currentTime += Time.deltaTime;
            if (currentTime > duration) {
                currentTime = 0;
            }

            var x1 = EasingHelper.Easing(-1f, 1f, currentTime, duration, EasingType.Linear, EasingMode.None);
            var y1 = EasingHelper.Easing(-1f, 1f, currentTime, duration, type, mode);

            nod1.position = new Vector3(x1, y1, 5f);

            var x2 = 1;
            var y2 = EasingHelper.Easing(-1f, 1f, currentTime, duration, type, mode);

            nod2.position = new Vector3(x2, y2, 5f);

        }

    }
}