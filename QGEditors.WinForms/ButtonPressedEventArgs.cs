/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System;

namespace QGEditors.WinForms
{
    /// <summary>
    /// 为 <see cref="QGEditors.WinForms.ButtonTextBoxControl.ButtonClick"/> 事件提供数据。
    /// </summary>
    public class ButtonPressedEventArgs : EventArgs
    {
        #region Fields

        private EditorButton button;

        #endregion

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="QGEditors.WinForms.ButtonPressedEventArgs"/>  类的新实例。
        /// </summary>
        /// <param name="button"><see cref="QGEditors.WinForms.EditorButton"/>实例。</param>
        public ButtonPressedEventArgs(EditorButton button)
        {
            this.button = button;
        }

        #endregion

        #region Properties

        /// <summary>
        /// 获取对引发事件的对象的引用。
        /// </summary>
        public EditorButton Button
        {
            get
            {
                return this.button;
            }
        }

        #endregion
    }
}