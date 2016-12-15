using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QGEditors.WinForms
{
    public class PropertyChangedEventArgsEx : PropertyChangedEventArgs
    {
        private readonly object newValue;
        private readonly object oldValue;

        public PropertyChangedEventArgsEx(string propertyName, object oldValue, object newValue)
            : base(propertyName)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

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
    }

 

}
