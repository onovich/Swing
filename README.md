# Swing
Swing, a lightweight easing function library. <br/>
**Swing，轻量级的缓动函数库，取名自“曳”。**

![](https://github.com/onovich/Swing/blob/main/Assets/com.mortise.swing/Resource_Sample/spr_scr_shoot.png)

Swing provides easing functions, waveform functions, spline functions, which can be used for applications such as animations, trajectories, cameras, etc.<br/>
**Swing 提供缓动函数、波形函数、样条函数，可用于动画 / 轨迹 / 相机等应用。**

The project also provides a wealth of runtime examples.<br/>
**项目内也提供了丰富的运行时示例。**

# Other Version
[Sway](https://github.com/onovich/Sway) is a parallel version of the current library, independent of the Unity Engine, suitable for server-side use.<br/>
**[Sway](https://github.com/onovich/Sway) 是当前库的平行版本，不依赖 Unity Engine，适用于服务端。**

# Readiness
Stable and available.<br/>
**稳定可用。**

# Enum
| Enum        | Members                                           |
|-------------|---------------------------------------------------|
| EasingMode  | None, EaseIn, EaseOut, EaseInOut                  |
| EasingType  | Linear, Sine, Quad, Cubic, Quart, Quint, Expo, Circ, Back, Elastic, Bounce |
| SplineType  | Bezier, CatmullRom, Hermite, BSpline              |

# Functions
| Static Class      | Static Function      | Args                                                                                   |
|-------------|----------------------|---------------------------------------------------------------------------------------------------|
| EasingHelper | EasingColor         | Color start, Color end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None |
| EasingHelper | EasingColor32       | Color32 start, Color32 end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None |
| EasingHelper | Easing2D             | Vector2 start, Vector2 end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None |
| EasingHelper | Easing3D             | Vector3 start, Vector3 end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None |
| EasingHelper | Easing               | float start, float end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None |
| EasingHelper | EasingByte           | byte start, byte end, float current, float duration, EasingType type, EasingMode mode = EasingMode.None |
| SplineHelper | Easing               | Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float current, float duration, SplineType splineType |
| SplineHelper | CalculateSplineLength | Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, SplineType splineType, int segments = 100         |
| WaveHelper   | EasingInWave         | float frequency, float amplitude, float current, float duration, float phase, WaveType waveType, EasingType type, EasingMode mode = EasingMode.None |
| WaveHelper   | EasingOutWave        | float frequency, float amplitude, float current, float duration, float phase, WaveType waveType, EasingType type, EasingMode mode = EasingMode.None |
| WaveHelper   | Wave                 | float frequency, float amplitude, float current, float phase, WaveType waveType                        |

# Sample
```
// In Unity Project
var timer = 10f;
Color color;
Vector2 pos;
float x;

void Update() {
    timer -= Time.deltaTime;
    color = EasingHelper.EasingColor(Color.black, Color.red, timer, 10f, EasingType.Sine, EasingMode.EaseInOut); 
    pos = EasingHelper.Easing2D(Vector2.zero, Vector2.one, timer, 10f, EasingType.Linear, EasingMode.None);
    x = EasingHelper.Easing(-1f, 1f, timer, 10f, EasingType.Back, EasingMode.EaseIn);
}
```

# UPM URL
**Main<br/>**
ssh://git@github.com/onovich/Swing.git?path=/Assets/com.mortise.swing#main
