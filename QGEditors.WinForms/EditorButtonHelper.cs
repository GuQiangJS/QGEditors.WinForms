/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System.Drawing;
using System.Windows.Forms;

namespace QGEditors.WinForms
{
    public static class EditorButtonHelper
    {
        #region Methods

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:验证公共方法的参数", MessageId = "0")]
        public static Image GetImage(this EditorButton button)
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

    public static class ButtonHelper
    {

        public static Point GetImageLocation(this Button btn, ContentAlignment align, Image image)
        {
            if (btn != null && image != null)
            {
                switch (align)
                {
                    case ContentAlignment.BottomCenter:
                        return new Point((btn.ClientSize.Width - image.Width) / 2, btn.ClientSize.Height - image.Height);

                    case ContentAlignment.BottomLeft:
                        return new Point(0, btn.ClientSize.Height - image.Height);

                    case ContentAlignment.BottomRight:
                        return new Point(btn.ClientSize.Width - image.Width, btn.ClientSize.Height - image.Height);

                    case ContentAlignment.TopCenter:
                        return new Point((btn.ClientSize.Width - image.Width) / 2, 0);

                    case ContentAlignment.TopLeft:
                        return new Point(0, 0);

                    case ContentAlignment.TopRight:
                        return new Point(btn.ClientSize.Width - image.Width, 0);

                    case ContentAlignment.MiddleCenter:
                        return new Point((btn.ClientSize.Width - image.Width) / 2, (btn.ClientSize.Height - image.Height) / 2);

                    case ContentAlignment.MiddleLeft:
                        return new Point(0, (btn.ClientSize.Height - image.Height) / 2);

                    case ContentAlignment.MiddleRight:
                        return new Point(btn.ClientSize.Width - image.Width, (btn.ClientSize.Height - image.Height) / 2);
                }
            }
            return new Point(0, 0);
        }
    }
}