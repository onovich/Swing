# Swing

[English](README.md)

稳定可用的 Unity 缓动、波形和样条函数库，带丰富运行样例。

![Swing 封面](docs/cover.png)

## 项目包含什么

- 缓动与波形函数。
- 样条和通用数学工具。
- Unity 示例和测试。

## 快速开始

在 Unity 中打开 **Window → Package Manager**，选择 **Add package from git URL**，输入：

```text
https://github.com/onovich/Swing.git?path=/Assets/com.mortise.swing#main
```

包元数据声明支持 Unity `2019.4` 及以上版本。

仓库本身也可以作为 Unity 示例工程打开。

## 示例

```csharp
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

## 仓库结构

- `Assets/` — Unity 脚本、场景、包与项目资源。
- `Packages/` — Unity 包依赖。
- `ProjectSettings/` — Unity 工程配置。

## 相关项目

- [Sway](https://github.com/onovich/Sway)

## 当前状态

当前仓库将 Swing 标记为稳定可用，并包含运行时示例和测试。

## 许可证

本仓库采用 [MIT](LICENSE) 许可证。
