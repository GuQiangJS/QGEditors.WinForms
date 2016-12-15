using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QGEditors.WinForms
{
    public class ButtonPressedEventArgs : EventArgs
    {
        private EditorButton button;

        public ButtonPressedEventArgs(EditorButton button)
        {
            this.button = button;
        }

        public EditorButton Button
        {
            get
            {
                return this.button;
            }
        }
    }

}
