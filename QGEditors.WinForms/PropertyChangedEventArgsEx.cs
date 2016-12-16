/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System.ComponentModel;

namespace QGEditors.WinForms
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.ComponentModel.PropertyChangedEventArgs" />
    public class PropertyChangedEventArgsEx : PropertyChangedEventArgs
    {
        #region Fields

        private readonly object newValue;
        private readonly object oldValue;

        #endregion

        #region Constructors

        public PropertyChangedEventArgsEx(string propertyName, object oldValue, object newValue)
            : base(propertyName)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        #endregion

        #region Properties

        public object NewValue
        {
            get
            {
                return this.newValue;
            }
        }

        public object OldValue
        {
            get
            {
                return this.oldValue;
            }
        }

        #endregion
    }
}