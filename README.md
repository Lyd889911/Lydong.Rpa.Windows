<a name="BkMyH"></a>
# 介绍
LydRPA可以方便的自动化操作。限制在Windows系统上使用。<br />github：[https://github.com/Lyd889911/LydRPA](https://github.com/Lyd889911/LydRPA)
<a name="leJd3"></a>
# 使用
```csharp
/// <summary>
/// 鼠标操作
/// </summary>
public static readonly MouseController Mouse = new MouseController();
/// <summary>
/// 键盘操作
/// </summary>
public static readonly KeyboardController Keyboard = new KeyboardController();
/// <summary>
/// 键鼠钩子操作
/// </summary>
public static readonly HookController Hook = new HookController();
/// <summary>
/// 弹窗
/// </summary>
public static readonly MessageBoxController MessageBox = new MessageBoxController();
/// <summary>
/// 应用程序
/// </summary>
public static readonly ApplicationController Application = new ApplicationController();
/// <summary>
/// 图片
/// </summary>
public static readonly ImageController Image = new ImageController();
```
通过调用RPA类的静态方法进行一系列的操作。
<a name="BtAP8"></a>
# 钩子的使用
使用钩子之前，先要设置钩子，软件关闭的时候要移除钩子。
```csharp
RPA.Hook.SetupHook(HookCallback);
```
```csharp
RPA.Hook.RemoveHook();
```
也可以单独设置键盘，或者，鼠标的钩子，SetupHook是两个都设置。
```csharp
private void HookCallback(HookType hookType, HookData hookData);
```
钩子回调方法，有两个参数HookType是枚举，用来确定当前回调是什么事件。HookData是携带的数据，鼠标事件就在Mouse里面，键盘事件就在Keyboard里面。
