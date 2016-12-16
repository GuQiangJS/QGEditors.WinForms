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
        #region Fields

        EditorButton _dataSource;

        #endregion

        #region Constructors

        public ButtonEditAppearance()
        {
            InitializeComponent();

            this.cmbKind.DataSource = Enum.GetNames(typeof(ButtonPredefines));
            this.cmbImageAlign.DataSource = Enum.GetNames(typeof(ContentAlignment));
        }

        #endregion

        #region Properties

        public EditorButton DataSource
        {
            get { return _dataSource; }
            set
            {
                this.cmbKind.SelectedValueChanged -= new System.EventHandler(this.cmbKind_SelectedValueChanged);
                this.cmbImageAlign.SelectedValueChanged -= new System.EventHandler(this.cmbImageAlign_SelectedValueChanged);
                if (value != null && _dataSource != value)
                {
                    _dataSource = value;
                    this.chkEnabled.DataBindings.Clear();
                    this.chkEnabled.DataBindings.Add(new Binding("Checked", value, "Enabled", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.chkVisible.DataBindings.Clear();
                    this.chkVisible.DataBindings.Add(new Binding("Checked", value, "Visible", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.cmbKind.DataBindings.Clear();
                    this.txtCaption.DataBindings.Add(new Binding("Text", value, "Caption", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.txtToolTip.DataBindings.Clear();
                    this.txtToolTip.DataBindings.Add(new Binding("Text", value, "ToolTip", false, DataSourceUpdateMode.OnPropertyChanged));
                    this.numWidth.DataBindings.Clear();
                    this.numWidth.DataBindings.Add(new Binding("Value", value, "Width", false, DataSourceUpdateMode.OnPropertyChanged));

                    this.cmbKind.Text = Enum.GetName(typeof(ButtonPredefines), value.Kind);
                    this.cmbImageAlign.Text = Enum.GetName(typeof(ContentAlignment), value.ImageAlign);

                    this.cmbKind.SelectedValueChanged += new System.EventHandler(this.cmbKind_SelectedValueChanged);
                    this.cmbImageAlign.SelectedValueChanged += new System.EventHandler(this.cmbImageAlign_SelectedValueChanged);
                }
            }
        }

        #endregion

        #region Methods

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = @"All Image Files|*.bmp;*.ico;*.jpeg;*.jpg;*.png;|" +
                        "Windows Bitmap(*.bmp)|*.bmp|" +
                        "Windows Icon(*.ico)|*.ico|" +
                        "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|" +
                        "Portable Network Graphics (*.png)|*.png";

            if (DialogResult.OK == dialog.ShowDialog(this))
            {
                this._dataSource.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void cmbImageAlign_SelectedValueChanged(object sender, EventArgs e)
        {
            this._dataSource.ImageAlign = (ContentAlignment)Enum.Parse(typeof(ContentAlignment), this.cmbImageAlign.SelectedItem.ToString());
        }

        private void cmbKind_SelectedValueChanged(object sender, EventArgs e)
        {
            this._dataSource.Kind = (ButtonPredefines)Enum.Parse(typeof(ButtonPredefines), this.cmbKind.SelectedItem.ToString());
        }

        #endregion
    }
}
