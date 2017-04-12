// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System;

#endregion

namespace QGEditors.WinForms {
    /// <summary>
    ///     为 <see cref="QGEditors.WinForms.ButtonEditControl.ButtonClick" /> 事件提供数据。
    /// </summary>
    public class ButtonPressedEventArgs : EventArgs {
        #region Constructors

        /// <summary>
        ///     初始化 <see cref="QGEditors.WinForms.ButtonPressedEventArgs" />  类的新实例。
        /// </summary>
        /// <param name="button"><see cref="QGEditors.WinForms.EditorButton" />实例。</param>
        public ButtonPressedEventArgs(EditorButton button) {
            Button = button;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     获取对引发事件的对象的引用。
        /// </summary>
        public EditorButton Button { get; private set; }

        #endregion

        #region Fields

        #endregion
    }
}