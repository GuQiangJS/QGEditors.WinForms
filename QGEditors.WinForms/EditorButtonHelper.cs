/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System.Drawing;
using System.Windows.Forms;

namespace QGEditors.WinForms
{
    internal static class EditorButtonHelper
    {
        #region Methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:验证公共方法的参数", MessageId = "0")]
        internal static Image GetImage(this EditorButton button)
        {
            if (button.Kind == ButtonPredefines.Glyph)
            {
                return button.Image;
            }
            else
            {
                return button.Kind.GetImage();
            }
        }

        #endregion
    }

    internal static class ControlHelper
    {
        internal static Point GetImageLocation(this Control control, ContentAlignment align, Image image)
        {
            if (control != null && image != null)
            {
                switch (align)
                {
                    case ContentAlignment.BottomCenter:
                        return new Point((control.ClientSize.Width - image.Width) / 2, control.ClientSize.Height - image.Height);

                    case ContentAlignment.BottomLeft:
                        return new Point(0, control.ClientSize.Height - image.Height);

                    case ContentAlignment.BottomRight:
                        return new Point(control.ClientSize.Width - image.Width, control.ClientSize.Height - image.Height);

                    case ContentAlignment.TopCenter:
                        return new Point((control.ClientSize.Width - image.Width) / 2, 0);

                    case ContentAlignment.TopLeft:
                        return new Point(0, 0);

                    case ContentAlignment.TopRight:
                        return new Point(control.ClientSize.Width - image.Width, 0);

                    case ContentAlignment.MiddleCenter:
                        return new Point((control.ClientSize.Width - image.Width) / 2, (control.ClientSize.Height - image.Height) / 2);

                    case ContentAlignment.MiddleLeft:
                        return new Point(0, (control.ClientSize.Height - image.Height) / 2);

                    case ContentAlignment.MiddleRight:
                        return new Point(control.ClientSize.Width - image.Width, (control.ClientSize.Height - image.Height) / 2);
                }
            }
            return new Point(0, 0);
        }
    }
}