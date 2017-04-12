// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace QGEditors.WinForms.DEMO {
    public partial class ButtonEditAppearance : UserControl {
        #region Fields

        private EditorButton _dataSource;

        #endregion

        #region Constructors

        public ButtonEditAppearance() {
            InitializeComponent();

            cmbKind.DataSource = Enum.GetNames(typeof(ButtonPredefines));
            cmbImageAlign.DataSource = Enum.GetNames(typeof(ContentAlignment));
        }

        #endregion

        #region Properties

        public EditorButton DataSource {
            get { return _dataSource; }
            set {
                cmbKind.SelectedValueChanged -= cmbKind_SelectedValueChanged;
                cmbImageAlign.SelectedValueChanged -= cmbImageAlign_SelectedValueChanged;
                if (value != null && _dataSource != value) {
                    _dataSource = value;
                    chkEnabled.DataBindings.Clear();
                    chkEnabled.DataBindings.Add(new Binding("Checked", value, "Enabled", false,
                        DataSourceUpdateMode.OnPropertyChanged));
                    chkVisible.DataBindings.Clear();
                    chkVisible.DataBindings.Add(new Binding("Checked", value, "Visible", false,
                        DataSourceUpdateMode.OnPropertyChanged));
                    cmbKind.DataBindings.Clear();
                    txtCaption.DataBindings.Add(new Binding("Text", value, "Caption", false,
                        DataSourceUpdateMode.OnPropertyChanged));
                    txtToolTip.DataBindings.Clear();
                    txtToolTip.DataBindings.Add(new Binding("Text", value, "ToolTip", false,
                        DataSourceUpdateMode.OnPropertyChanged));
                    numWidth.DataBindings.Clear();
                    numWidth.DataBindings.Add(new Binding("Value", value, "Width", false,
                        DataSourceUpdateMode.OnPropertyChanged));

                    cmbKind.Text = Enum.GetName(typeof(ButtonPredefines), value.Kind);
                    cmbImageAlign.Text = Enum.GetName(typeof(ContentAlignment), value.ImageAlign);

                    cmbKind.SelectedValueChanged += cmbKind_SelectedValueChanged;
                    cmbImageAlign.SelectedValueChanged += cmbImageAlign_SelectedValueChanged;
                }
            }
        }

        #endregion

        #region Methods

        private void btnClear_Click(object sender, EventArgs e) {
        }

        private void btnImage_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = @"All Image Files|*.bmp;*.ico;*.jpeg;*.jpg;*.png;|" +
                            "Windows Bitmap(*.bmp)|*.bmp|" +
                            "Windows Icon(*.ico)|*.ico|" +
                            "JPEG File Interchange Format (*.jpg)|*.jpg;*.jpeg|" +
                            "Portable Network Graphics (*.png)|*.png";

            if (DialogResult.OK == dialog.ShowDialog(this))
                _dataSource.Image = Image.FromFile(dialog.FileName);
        }

        private void cmbImageAlign_SelectedValueChanged(object sender, EventArgs e) {
            _dataSource.ImageAlign =
                (ContentAlignment) Enum.Parse(typeof(ContentAlignment), cmbImageAlign.SelectedItem.ToString());
        }

        private void cmbKind_SelectedValueChanged(object sender, EventArgs e) {
            _dataSource.Kind = (ButtonPredefines) Enum.Parse(typeof(ButtonPredefines), cmbKind.SelectedItem.ToString());
        }

        #endregion
    }
}