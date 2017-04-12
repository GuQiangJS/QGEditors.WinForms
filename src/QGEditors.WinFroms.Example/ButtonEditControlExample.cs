using System.Windows.Forms;
using QGEditors.WinForms;

namespace QGEditors.WinFroms.Example {
    public partial class ButtonEditControlExample : Form {
        public ButtonEditControlExample() {
            var btnEdit1 = new ButtonEditControl();

            btnEdit1.Buttons.Add(new EditorButton());
            btnEdit1.Buttons.Add(new EditorButton(ButtonPredefines.Delete));

            Controls.Add(btnEdit1);
        }
    }
}