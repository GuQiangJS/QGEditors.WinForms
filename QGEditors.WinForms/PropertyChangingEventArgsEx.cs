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
    /// <seealso cref="System.ComponentModel.PropertyChangingEventArgs" />
    public class PropertyChangingEventArgsEx : PropertyChangingEventArgs
    {
        #region Fields

        private bool cancel;

        #endregion

        #region Constructors

        public PropertyChangingEventArgsEx(string propertyName)
            : base(propertyName)
        {
        }

        #endregion

        #region Properties

        public bool Cancel
        {
            get
            {
                return this.cancel;
            }
            set
            {
                this.cancel = value;
            }
        }

        #endregion
    }
}