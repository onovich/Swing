# Swing
Swing, a lightweight easing function library. <br/>
**Swing，轻量级的缓动函数库，取名自“曳”。**

![](https://github.com/onovich/Swing/blob/main/Assets/com.mortise.swing/Sample/Art/spr_scr_shoot.png)

# Sample
```
// In .Net Core Project
var timer = 10f;
Color color;
Vector2 pos;
float x;
float dt = 20f

while (timer > 0) {
    timer -= dt;
    color = EasingHelper.EasingColor(Color.black, Color.red, timer, 10f, EasingType.Sine, EasingMode.EaseInOut); 
    pos = EasingHelper.Easing2D(Vector2.zero, Vector2.one, timer, 10f, EasingType.Linear, EasingMode.None);
    x = EasingHelper.Easing(-1f, 1f, timer, 10f, EasingType.Back, EasingMode.EaseIn);
    Thread.Sleep(sleepTime);
}
```

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
ssh://git@github.com/onovich/Swing.git?path=/Assets/com.mortise.swing#main
