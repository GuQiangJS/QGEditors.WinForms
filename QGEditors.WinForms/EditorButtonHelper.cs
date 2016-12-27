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
}