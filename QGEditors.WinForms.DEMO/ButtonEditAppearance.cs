using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QGEditors.WinForms.DEMO
{
    public partial class ButtonEditAppearance : UserControl
    {
        public ButtonEditAppearance()
        {
            InitializeComponent();

            this.cmbKind.DataSource = Enum.GetNames(typeof(ButtonPredefines));
            this.cmbImageAlign.DataSource = Enum.GetNames(typeof(ContentAlignment));
        }

        EditorButton _dataSource;

        public EditorButton DataSource
        {
            get { return _dataSource; }
            set
            {
                if (value != null && _dataSource != value)
                {
                    _dataSource = value;
                    this.chkEnabled.DataBindings.Clear();
                    this.chkEnabled.DataBindings.Add(new Binding("Checked", value, "Enabled", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.chkVisible.DataBindings.Clear();
                    this.chkVisible.DataBindings.Add(new Binding("Checked", value, "Visible", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.cmbKind.DataBindings.Clear();
                    this.cmbKind.DataBindings.Add(new Binding("Text", value, "Kind", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.txtCaption.DataBindings.Clear();
                    this.txtCaption.DataBindings.Add(new Binding("Text", value, "Caption", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.txtToolTip.DataBindings.Clear();
                    this.txtToolTip.DataBindings.Add(new Binding("Text", value, "ToolTip", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.numWidth.DataBindings.Clear();
                    this.numWidth.DataBindings.Add(new Binding("Value", value, "Width", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.cmbImageAlign.DataBindings.Clear();
                    this.cmbImageAlign.DataBindings.Add(new Binding("Text", value, "ImageAlign", false, DataSourceUpdateMode.OnPropertyChanged));
                }
            }
        }

        private void cmbKind_SelectedValueChanged(object sender, EventArgs e)
        {
            this._dataSource.Kind = (ButtonPredefines)Enum.Parse(typeof(ButtonPredefines), this.cmbKind.SelectedItem.ToString());
        }

        private void cmbImageAlign_SelectedValueChanged(object sender, EventArgs e)
        {
            this._dataSource.ImageAlign = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), this.cmbImageAlign.SelectedItem.ToString());
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter=@"All Image Files|*.bmp;*.ico;*.jpeg;*.jpg;*.png;|"+
                        "Windows Bitmap(*.bmp)|*.bmp|"  +
                        "Windows Icon(*.ico)|*.ico|"  +
                        "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|"  +
                        "Portable Network Graphics (*.png)|*.png";  
  
            if (DialogResult.OK == dialog.ShowDialog(this))  
            {
                this._dataSource.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }
    }
}
