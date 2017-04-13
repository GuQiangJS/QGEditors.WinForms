# QGEditors.WinForms WinForm 控件扩展

## 支持版本
.NET 3.5

## 编译
使用 Visual Studio 2012 及以上版本 打开 src/QGEditors.WinForms.sln 解决方案。

编译 QGEditors.WinForms.DocBuilders 相关帮助文档项目时需要使用 [Sandcastle Help File Builder](https://github.com/EWSoftware/SHFB/releases)。

编译 QGEditors.WinForms.DocBuilder.CHM 项目时需要配合使用 [HTML Help Workshop](http://www.microsoft.com/en-us/download/details.aspx?id=21138)。

## 控件集合

### ButtonEditControl

ButtonEditControl编辑器是文本编辑器，允许您在编辑框中显示无限数量的按钮。

ButtonEditControl类提供Buttons属性来访问编辑器中显示的按钮集合。每个按钮都由EditorButton对象表示，该对象提供了一些指定按钮的外观，快捷方式，可见性，提示文本等属性。

通过处理ButtonEditControl.ButtonClick事件来响应点击编辑器按钮事件。

![ButtonEditControl](https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/ButtonEditControl.png?raw=true)

[详细说明](https://guqiangjs.github.io/QGEditors.WinForms/html/a6572857-9fe9-24f0-f172-fef867725270.htm)

### SplitContainerControl

扩展 [SplitContainer](http://msdn2.microsoft.com/zh-cn/library/hb802c99) 。分割区域的可移动条中间显示分隔符。

[详细说明](https://guqiangjs.github.io/QGEditors.WinForms/html/95ed422c-755a-e345-36e5-e77ca730514f.htm)