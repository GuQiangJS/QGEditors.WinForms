# QGEditors.WinForms WinForm控件扩展

## ButtonEditControl
![ButtonEditControl](https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/ButtonEditControl.png?raw=true)

### Example:

下面的代码创建一个 **ButtonEditControl** 实例，并将其放在一个名为 panel1 的 Panel 中。同时向 ButtonEditControl 实例中添加两个靠右顺序排列的按钮，第一个按钮使用默认的按钮类型（省略号），另一个按钮则改为 (ButtonPredefines.Delete) 。
代码执行的结果显示如下︰

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
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/AT.png?raw=true"></td>
</tr>
<tr>
<td>Attachment</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Attachment.png?raw=true"></td>
</tr>
<tr>
<td>Backward</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Backward.png?raw=true"></td>
</tr>
<tr>
<td>Delete</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Delete.png?raw=true"></td>
</tr>
<tr>
<td>Down</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Down.png?raw=true"></td>
</tr>
<tr>
<td>Edit</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Edit.png?raw=true"></td>
</tr>
<tr>
<td>Elipsis</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Elipsis.png?raw=true"></td>
</tr>
<tr>
<td>Favorite</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Favorite.png?raw=true"></td>
</tr>
<tr>
<td>File</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/File.png?raw=true"></td>
</tr>
<tr>
<td>Forward</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Forward.png?raw=true"></td>
</tr>
<tr>
<td>Help</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Help.png?raw=true"></td>
</tr>
<tr>
<td>Left</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Left.png?raw=true"></td>
</tr>
<tr>
<td>Lock</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Lock.png?raw=true"></td>
</tr>
<tr>
<td>Loop</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Loop.png?raw=true"></td>
</tr>
<tr>
<td>Mail</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Mail.png?raw=true"></td>
</tr>
<tr>
<td>Minus</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Minus.png?raw=true"></td>
</tr>
<tr>
<td>OK</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/OK.png?raw=true"></td>
</tr>
<tr>
<td>Option</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Option.png?raw=true"></td>
</tr>
<tr>
<td>Pause</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Pause.png?raw=true"></td>
</tr>
<tr>
<td>Play</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Play.png?raw=true"></td>
</tr>
<tr>
<td>Plus</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Plus.png?raw=true"></td>
</tr>
<tr>
<td>Redo</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Redo.png?raw=true"></td>
</tr>
<tr>
<td>Right</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Right.png?raw=true"></td>
</tr>
<tr>
<td>Save</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Save.png?raw=true"></td>
</tr>
<tr>
<td>Search</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Search.png?raw=true"></td>
</tr>
<tr>
<td>Trash</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Trash.png?raw=true"></td>
</tr>
<tr>
<td>Undo</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Undo.png?raw=true"></td>
</tr>
<tr>
<td>Unlock</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Unlock.png?raw=true"></td>
</tr>
<tr>
<td>Up</td>
<td><img src="https://github.com/GuQiangJS/QGEditors.WinForms/blob/master/Images/Previews/Up.png?raw=true"></td>
</tr>
</tbody>
</table>
