// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System.ComponentModel;

#endregion

namespace QGEditors.WinForms {
    /// <summary>
    /// </summary>
    /// <seealso cref="System.ComponentModel.PropertyChangingEventArgs" />
    public class PropertyChangingEventArgsEx : PropertyChangingEventArgs {
        #region Constructors

        public PropertyChangingEventArgsEx(string propertyName)
            : base(propertyName) {
        }

        #endregion

        #region Properties

        public bool Cancel { get; set; }

        #endregion

        #region Fields

        #endregion
    }
}