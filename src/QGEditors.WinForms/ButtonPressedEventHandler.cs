// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System.Diagnostics.CodeAnalysis;

#endregion

namespace QGEditors.WinForms {
    /// <summary>
    ///     表示将处理 <see cref="QGEditors.WinForms.ButtonEditControl.ButtonClick" /> 路由事件的方法。
    /// </summary>
    /// <param name="sender">事件处理程序附加到的对象。</param>
    /// <param name="e">事件数据。</param>
    [SuppressMessage("Microsoft.Design", "CA1003:UseGenericEventHandlerInstances")]
    public delegate void ButtonPressedEventHandler(object sender, ButtonPressedEventArgs e);
}