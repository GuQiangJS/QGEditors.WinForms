/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System;

namespace QGEditors.WinForms
{
    public class ButtonPressedEventArgs : EventArgs
    {
        #region Fields

        private EditorButton button;

        #endregion

        #region Constructors

        public ButtonPressedEventArgs(EditorButton button)
        {
            this.button = button;
        }

        #endregion

        #region Properties

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