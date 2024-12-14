using UnityEngine;
using MortiseFrame.Swing;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace MortiseFrame.Swing.Sample {

    public class EasingOrbit3DSample : MonoBehaviour {

        public Button resetButton;

        public float duration = 10f;
        public int resolution = 50;
        float currentTime = 0f;

        public DragableElement[] ps; // p0 = start, p1 = end, p2 = center, p3 = current
        bool isDragging = false;
        int draggingIndex;

        public LineRenderer lineRenderer_orbit;
        public LineRenderer lineRenderer_start;
        public LineRenderer lineRenderer_end;

        public Dropdown EasingTypeDropDown;
        public Dropdown EasingModeDropDown;
        public Dropdown ClockwiseDropDown;
        public Dropdown FullOrMinDropDown;

        EasingType type = EasingType.Linear;
        EasingMode mode = EasingMode.None;
        bool isClockwise = true;
        bool isFullOrbit = true;

        void Awake() {

            // Init Dragable
            for (int i = 0; i < ps.Length; i++) {
                var p = ps[i];
                p.GetComponent<DragableElement>().index = i;
            }

            // Init Line 
            lineRenderer_orbit.positionCount = resolution;
            lineRenderer_orbit.widthCurve = AnimationCurve.Linear(0, 0.1f, 1, 0.1f);

            lineRenderer_start.positionCount = 2;
            lineRenderer_start.widthCurve = AnimationCurve.Linear(0, 0.1f, 1, 0.1f);

            lineRenderer_end.positionCount = 2;
            lineRenderer_end.widthCurve = AnimationCurve.Linear(0, 0.1f, 1, 0.1f);

            UpdateLine();

            resetButton.onClick.AddListener(() => {
                Reset();
                UpdateLine();
            });

            // Draw Choice
            var typeNames = System.Enum.GetNames(typeof(EasingType));
            EasingTypeDropDown.options.Clear();
            for (int i = 0; i < typeNames.Length; i++) {
                EasingTypeDropDown.options.Add(new Dropdown.OptionData(typeNames[i]));
            }
            EasingTypeDropDown.value = 0;
            EasingTypeDropDown.onValueChanged.AddListener((int index) => {
                type = (EasingType)index;
                UpdateLine();
            });

            var modeNames = System.Enum.GetNames(typeof(EasingMode));
            EasingModeDropDown.options.Clear();
            for (int i = 0; i < modeNames.Length; i++) {
                EasingModeDropDown.options.Add(new Dropdown.OptionData(modeNames[i]));
            }
            EasingModeDropDown.value = 0;
            EasingModeDropDown.onValueChanged.AddListener((int index) => {
                mode = (EasingMode)index;
                UpdateLine();
            });

            var fullOrMinNames = new string[] { "Full", "Min" };
            FullOrMinDropDown.options.Clear();
            for (int i = 0; i < fullOrMinNames.Length; i++) {
                FullOrMinDropDown.options.Add(new Dropdown.OptionData(fullOrMinNames[i]));
            }
            FullOrMinDropDown.value = 0;
            FullOrMinDropDown.onValueChanged.AddListener((int index) => {
                isFullOrbit = index == 0;
                UpdateLine();
            });

            ClockwiseDropDown.options.Clear();
            ClockwiseDropDown.options.Add(new Dropdown.OptionData("Clockwise"));
            ClockwiseDropDown.options.Add(new Dropdown.OptionData("CounterClockwise"));
            EasingModeDropDown.value = 0;
            ClockwiseDropDown.onValueChanged.AddListener((int index) => {
                isClockwise = index == 0;
                UpdateLine();
            });
        }

        void UpdateLine() {

            for (int i = 0; i < resolution; i++) {
                var pos = isFullOrbit ? OrbitHelper.RoundFull3D(ps[0].Pos, ps[1].Pos, ps[2].Pos,
                i, resolution, isClockwise, type, mode) :
                OrbitHelper.RoundMin3D(ps[0].Pos, ps[1].Pos, ps[2].Pos,
                i, resolution, type, mode);
                Vector3 position = new Vector3(pos.x, pos.y, pos.z);
                lineRenderer_orbit.SetPosition(i, position);
            }

            lineRenderer_start.SetPosition(0, ps[0].Pos);
            lineRenderer_start.SetPosition(1, ps[2].Pos);

            lineRenderer_end.SetPosition(0, ps[1].Pos);
            lineRenderer_end.SetPosition(1, ps[2].Pos);

        }

        void Reset() {
            currentTime = 0f;
        }

        void Update() {

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

                ps[draggingIndex].transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
                UpdateLine();
            }

            if (currentTime > duration) {
                currentTime = 0f;
            }

            var start = ps[0].Pos;
            var end = ps[1].Pos;
            var center = ps[2].Pos;
            var current = isFullOrbit ? OrbitHelper.RoundFull3D(start, end, center, currentTime, duration, isClockwise, type, mode) :
            OrbitHelper.RoundMin3D(start, end, center, currentTime, duration, type, mode);
            ps[3].transform.position = new Vector3(current.x, current.y, current.z);

            currentTime += Time.deltaTime;

        }

    }

}