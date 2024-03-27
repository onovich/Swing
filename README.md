# Swing
Swing, a lightweight easing function library. <br/>
**Swing，轻量级的缓动函数库，取名自“曳”。**

![](https://github.com/onovich/Swing/blob/main/Assets/com.mortise.swing/Resource_Sample/spr_scr_shoot.png)

# Unity Support
The [Main](https://github.com/onovich/Swing/tree/main) branch does not depend on the Unity Engine (but relies on [Abacus](https://github.com/onovich/Abacus)) and can be used for server-side or other projects that prohibit dependency on the Unity Engine.<br/>
**[Main](https://github.com/onovich/Swing/tree/main) 分支不依赖 Unity Engine（而依赖 [Abacus](https://github.com/onovich/Abacus)）, 可用于服务端或者别的禁止依赖 Unity Engine 的项目。**

The current branch is a parallel branch that depends on and supports the Unity Engine.<br/>
**当前分支则是其依赖并支持 Unity Engine 的平行分支。**

You can also choose to use the Abacus extension library [AbacusExtension](https://github.com/onovich/AbacusExtension) as glue to stitch together the main branch version and the Unity Engine, as needed.<br/>
**你也可以视需要选择用 Abacus 的扩展库 [AbacusExtension](https://github.com/onovich/AbacusExtension) 作为胶水，自己缝合主分支版本和 Unity Engine.**

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

**Unity-Edition<br/>**
ssh://git@github.com/onovich/Swing.git?path=/Assets/com.mortise.swing#unity-edition
