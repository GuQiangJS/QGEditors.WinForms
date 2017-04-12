// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

#endregion

namespace QGEditors.WinForms {
    [SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors")]
    public class QGEditorControl {
        #region Fields

        private static Font defaultFont;

        #endregion

        #region Properties

        /// <summary>
        ///     获取QGEditor控件库中控件的默认字体。
        /// </summary>
        /// <value>
        ///     控件的默认 System.Drawing.Font。
        /// </value>
        /// <exception cref="ArgumentException">默认字体或地区可选字体未安装在客户计算机上。</exception>
        public static Font DefaultFont {
            get {
                if (defaultFont == null)
                    defaultFont = new Font("Tahoma", 9F, FontStyle.Regular);
                return defaultFont;
            }
        }

        #endregion
    }
}