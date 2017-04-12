// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System.ComponentModel;

#endregion

namespace QGEditors.WinForms {
    /// <summary>
    /// </summary>
    /// <seealso cref="System.ComponentModel.PropertyChangedEventArgs" />
    public class PropertyChangedEventArgsEx : PropertyChangedEventArgs {
        #region Constructors

        public PropertyChangedEventArgsEx(string propertyName, object oldValue, object newValue)
            : base(propertyName) {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        #endregion

        #region Fields

        private readonly object newValue;
        private readonly object oldValue;

        #endregion

        #region Properties

        public object NewValue {
            get { return newValue; }
        }

        public object OldValue {
            get { return oldValue; }
        }

        #endregion
    }
}