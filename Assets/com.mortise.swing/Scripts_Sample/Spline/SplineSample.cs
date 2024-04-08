using UnityEngine;
using MortiseFrame.Swing;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MortiseFrame.Swing.Sample {

    public class SplineSample : MonoBehaviour {

        // Config
        SplineType type = SplineType.Bezier;
        public float duration = 1f;
        public int resolution = 50;

        // Render
        public LineRenderer lineRenderer;
        public MeshRenderer boxRender;
        public MeshFilter boxFilter;
        public Dropdown SplineTypeDropdown;
        public Transform car;
        public DragableElement[] ps;
        public Button resetButton;
        public Text lengthText;

        Vector3[] originPos = new Vector3[4];

        // Lift Cycle
        float currentTime = 0f;

        private void Awake() {

            // Init Dragable
            for (int i = 0; i < ps.Length; i++) {
                var p = ps[i];
                p.GetComponent<DragableElement>().index = i;
                originPos[i] = p.Pos;
            }

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
            vertices[0] = new Vector3(-2f - thickness, -1f - thickness, 0); // 左下角
            vertices[1] = new Vector3(2f + thickness, -1f - thickness, 0); // 右下角
            vertices[2] = new Vector3(-2f - thickness, 1f + thickness, 0); // 左上角
            vertices[3] = new Vector3(2f + thickness, 1f + thickness, 0); // 右上角

            // - 定义内矩形的四个顶点
            vertices[4] = new Vector3(-2f + thickness, -1f + thickness, 0);
            vertices[5] = new Vector3(2f - thickness, -1f + thickness, 0);
            vertices[6] = new Vector3(-2f + thickness, 1f - thickness, 0);
            vertices[7] = new Vector3(2f - thickness, 1f - thickness, 0);

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
            var typeNames = System.Enum.GetNames(typeof(SplineType));

            SplineTypeDropdown.options.Clear();

            for (int i = 0; i < typeNames.Length; i++) {
                SplineTypeDropdown.options.Add(new Dropdown.OptionData(typeNames[i]));
            }

            resetButton.onClick.AddListener(() => {
                Reset();
                UpdateLine();
            });

            SplineTypeDropdown.value = 0;

            SplineTypeDropdown.onValueChanged.AddListener((int index) => {
                type = (SplineType)index;
                UpdateLine();
            });

        }

        void Reset() {

            for (int i = 0; i < ps.Length; i++) {
                ps[i].transform.position = originPos[i];
            }
            currentTime = 0f;

        }

        void UpdateLine() {

            for (int i = 0; i < resolution; i++) {
                var pos = SplineHelper.Easing(ps[0].Pos, ps[1].Pos, ps[2].Pos, ps[3].Pos,
                i, resolution, type);
                Vector3 position = new Vector3(pos.x, pos.y, 0f) + transform.position;
                lineRenderer.SetPosition(i, position);
            }

            var length = SplineHelper.CalculateSplineLength(ps[0].Pos, ps[1].Pos, ps[2].Pos, ps[3].Pos, type, resolution);
            lengthText.text = $"Length: {length.ToString("F2")}";

        }

        bool isDragging = false;
        int draggingIndex;

        private void Update() {

            // Process Input
            if (Input.GetMouseButtonDown(0)) {
                Vector3 screenPos = Input.mousePosition;
                screenPos.z = Camera.main.WorldToScreenPoint(transform.position).z; // 转换摄像机到物体平面的z值
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
                var layerMask = 1 << 5;
                RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, layerMask);
                if (hit.collider != null) {
                    var draggable = hit.collider.GetComponent<DragableElement>();
                    if (draggable != null) {
                        isDragging = true;
                        draggingIndex = draggable.index;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0)) {
                isDragging = false;
            }

            // Do Logic
            if (isDragging) {
                var elePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

                ps[draggingIndex].transform.position = new Vector3(worldPosition.x, worldPosition.y, 5f);
                UpdateLine();
            }

            // Render
            currentTime += Time.deltaTime;
            if (currentTime > duration) {
                currentTime = 0;
            }

            var pos = SplineHelper.Easing(ps[0].Pos, ps[1].Pos, ps[2].Pos, ps[3].Pos,
            currentTime, duration, type);

            car.position = new Vector3(pos.x, pos.y, 5f);

        }

    }
}