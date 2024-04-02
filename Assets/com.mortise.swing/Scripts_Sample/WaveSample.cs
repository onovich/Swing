using UnityEngine;
using MortiseFrame.Swing;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MortiseFrame.Swing.Sample {

    public class WaveSample : MonoBehaviour {

        // Config
        public float duration = 1f;
        public int resolution = 50;

        // Render
        public LineRenderer lineRenderer;
        public MeshRenderer boxRender;
        public MeshFilter boxFilter;
        public Text frequencyTxt;
        public Text amplitudeTxt;
        public Text phaseTxt;
        public InputField frequencyInput;
        public InputField amplitudeInput;
        public InputField phaseInput;
        public Dropdown waveTypeDropdown;

        public Button playBtn;
        public Transform nod1;
        public Transform nod2;

        // Lift Cycle
        float currentTime = 0f;
        float frequency = 1f;
        float amplitude = 1f;
        float phase = 0f;
        WaveType waveType = WaveType.Sine;

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
            var waveTypeOptions = System.Enum.GetNames(typeof(WaveType));
            waveTypeDropdown.options.Clear();

            for (int i = 0; i < waveTypeOptions.Length; i++) {
                waveTypeDropdown.options.Add(new Dropdown.OptionData(waveTypeOptions[i]));
            }

            waveTypeDropdown.value = (int)waveType;
            waveTypeDropdown.onValueChanged.AddListener((int value) => {
                waveType = value == 0 ? WaveType.Sine : ((WaveType)value);
                UpdateLine();
            });

            playBtn.onClick.AddListener(() => {
                Refresh();
                UpdateLine();
            });

            frequencyInput.onEndEdit.AddListener((string value) => {
                frequency = value == "" ? 1f : float.Parse(value);
                UpdateLine();
            });

            amplitudeInput.onEndEdit.AddListener((string value) => {
                amplitude = value == "" ? 1f : float.Parse(value);
                UpdateLine();
            });

            phaseInput.onEndEdit.AddListener((string value) => {
                phase = value == "" ? 0f : float.Parse(value);
                UpdateLine();
            });

            Reset();

        }

        void Reset() {
            frequency = 1f;
            amplitude = 1f;
            phase = 0f;
            waveType = 0;
        }

        void Refresh() {
            currentTime = 0;
        }

        private void UpdateLine() {

            for (int i = 0; i < resolution; i++) {
                var x = EasingHelper.Easing(-1f, 1f, i, resolution, EasingType.Linear, EasingMode.None);
                var y = WaveHelper.Wave(frequency / resolution, amplitude, i, phase, (WaveType)waveType);
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
            var y1 = WaveHelper.Wave(frequency, amplitude, currentTime, phase, (WaveType)waveType);
            nod1.position = new Vector3(x1, y1, 5f);
            nod2.position = new Vector3(1, y1, 5f);

        }

    }
}