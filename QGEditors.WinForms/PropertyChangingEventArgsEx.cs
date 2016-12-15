using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QGEditors.WinForms
{
    public class PropertyChangingEventArgsEx : PropertyChangingEventArgs
    {
        private bool cancel;

        public PropertyChangingEventArgsEx(string propertyName)
            : base(propertyName)
        {
        }

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
    }


}
