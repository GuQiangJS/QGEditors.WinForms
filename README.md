# QGEditors.WinForms WinForm控件扩展

[ButtonEditControl](#ButtonEditControl)

## 支持版本
.NET 3.5

## 编译
使用 Visual Studio 2012 及以上版本 打开 src/QGEditors.WinForms.sln 解决方案。

编译 QGEditors.WinForms.DocBuilders 相关帮助文档项目时需要使用 [Sandcastle Help File Builder](https://github.com/EWSoftware/SHFB/releases)。


<span id="ButtonEditControl"></span>
### ButtonEditControl

ButtonEditControl编辑器是文本编辑器，允许您在编辑框中显示无限数量的按钮。

ButtonEditControl类提供Buttons属性来访问编辑器中显示的按钮集合。每个按钮都由EditorButton对象表示，该对象提供了一些指定按钮的外观，快捷方式，可见性，提示文本等属性。

通过处理ButtonEditControl.ButtonClick事件来响应点击编辑器按钮事件。

![ButtonEditControl](https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/ButtonEditControl.png?raw=true)

#### Example:

下面的代码创建一个 **ButtonEditControl** 实例，并将其放在一个名为 panel1 的 Panel 中。同时向 ButtonEditControl 实例中添加两个靠右顺序排列的按钮，第一个按钮使用默认的按钮类型（省略号），另一个按钮则改为 (ButtonPredefines.Delete) 。
代码执行的结果显示如下︰

![DEMO](https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/1496652533.png?raw=true)

```C#
ButtonEditControl btnEdit1 = new ButtonEditControl();

btnEdit1.Buttons.Add(new EditorButton());
btnEdit1.Buttons.Add(new EditorButton(ButtonPredefines.Delete));
panel1.Controls.Add(btnEdit1);
```

ButtonPredefines 预置的按钮类型。


<table style="height: 589px; width: 304px" border="0" align="left">
<tbody>
<tr>
<td>AT</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/AT.png?raw=true"></td>
</tr>
<tr>
<td>Attachment</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Attachment.png?raw=true"></td>
</tr>
<tr>
<td>Backward</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Backward.png?raw=true"></td>
</tr>
<tr>
<td>Delete</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Delete.png?raw=true"></td>
</tr>
<tr>
<td>Down</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Down.png?raw=true"></td>
</tr>
<tr>
<td>Edit</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Edit.png?raw=true"></td>
</tr>
<tr>
<td>Elipsis</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Elipsis.png?raw=true"></td>
</tr>
<tr>
<td>Favorite</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Favorite.png?raw=true"></td>
</tr>
<tr>
<td>File</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/File.png?raw=true"></td>
</tr>
<tr>
<td>Forward</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Forward.png?raw=true"></td>
</tr>
<tr>
<td>Help</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Help.png?raw=true"></td>
</tr>
<tr>
<td>Left</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Left.png?raw=true"></td>
</tr>
<tr>
<td>Lock</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Lock.png?raw=true"></td>
</tr>
<tr>
<td>Loop</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Loop.png?raw=true"></td>
</tr>
<tr>
<td>Mail</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Mail.png?raw=true"></td>
</tr>
<tr>
<td>Minus</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Minus.png?raw=true"></td>
</tr>
<tr>
<td>OK</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/OK.png?raw=true"></td>
</tr>
<tr>
<td>Option</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Option.png?raw=true"></td>
</tr>
<tr>
<td>Pause</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Pause.png?raw=true"></td>
</tr>
<tr>
<td>Play</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Play.png?raw=true"></td>
</tr>
<tr>
<td>Plus</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Plus.png?raw=true"></td>
</tr>
<tr>
<td>Redo</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Redo.png?raw=true"></td>
</tr>
<tr>
<td>Right</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Right.png?raw=true"></td>
</tr>
<tr>
<td>Save</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Save.png?raw=true"></td>
</tr>
<tr>
<td>Search</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Search.png?raw=true"></td>
</tr>
<tr>
<td>Trash</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Trash.png?raw=true"></td>
</tr>
<tr>
<td>Undo</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Undo.png?raw=true"></td>
</tr>
<tr>
<td>Unlock</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Unlock.png?raw=true"></td>
</tr>
<tr>
<td>Up</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/src/Images/Previews/Up.png?raw=true"></td>
</tr>
</tbody>
</table>
