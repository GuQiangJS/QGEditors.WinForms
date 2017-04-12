// QGEditor
// Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
// ALL RIGHTS RESERVED

#region

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using QGEditors.WinForms.Properties;

#endregion

namespace QGEditors.WinForms {
    /// <summary>
    ///     预置的按钮类型。
    /// </summary>
    /// <remarks>
    ///     <see cref="QGEditors.WinForms.ButtonPredefines" /> 类型枚举
    ///     提供了多种按钮控件图像。
    /// </remarks>
    public enum ButtonPredefines {
        /// <summary>
        ///     @符号
        /// </summary>
        AT = 0,

        /// <summary>
        ///     附件
        /// </summary>
        Attachment = 1,

        /// <summary>
        ///     自定义图像。
        /// </summary>
        Glyph = 2,

        /// <summary>
        ///     后退
        /// </summary>
        Backward = 3,

        /// <summary>
        ///     删除
        /// </summary>
        Delete = 4,

        /// <summary>
        ///     向下箭头
        /// </summary>
        Down = 5,

        /// <summary>
        ///     编辑
        /// </summary>
        Edit = 6,

        /// <summary>
        ///     省略号
        /// </summary>
        Elipsis = 7,

        /// <summary>
        ///     收藏
        /// </summary>
        Favorite = 8,

        /// <summary>
        ///     文件
        /// </summary>
        File = 9,

        /// <summary>
        ///     前进
        /// </summary>
        Forward = 10,

        /// <summary>
        ///     帮助
        /// </summary>
        Help = 11,

        /// <summary>
        ///     向左箭头
        /// </summary>
        Left = 12,

        /// <summary>
        ///     锁定
        /// </summary>
        Lock = 13,

        /// <summary>
        ///     循环
        /// </summary>
        Loop = 14,

        /// <summary>
        ///     Mail
        /// </summary>
        Mail = 15,

        /// <summary>
        ///     减号/负号
        /// </summary>
        Minus = 16,

        /// <summary>
        ///     Ok
        /// </summary>
        Ok = 17,

        /// <summary>
        ///     选项/设置
        /// </summary>
        Option = 18,

        /// <summary>
        ///     暂停
        /// </summary>
        Pause = 19,

        /// <summary>
        ///     播放
        /// </summary>
        Play = 20,

        /// <summary>
        ///     加号
        /// </summary>
        Plus = 21,

        /// <summary>
        ///     恢复/重复/恢复上一次操作
        /// </summary>
        Redo = 22,

        /// <summary>
        ///     向右箭头
        /// </summary>
        Right = 23,

        /// <summary>
        ///     保存
        /// </summary>
        Save = 24,

        /// <summary>
        ///     搜索
        /// </summary>
        Search = 25,

        /// <summary>
        ///     垃圾箱/回收站
        /// </summary>
        Trash = 26,

        /// <summary>
        ///     未锁定
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "Un")] UnLock = 27,

        /// <summary>
        ///     撤消/复原/撤消本次操作
        /// </summary>
        Undo = 28,

        /// <summary>
        ///     向上箭头
        /// </summary>
        Up = 29
    }

    internal static class ButtonPredefinesHelper {
        #region Methods

        internal static Image GetImage(this ButtonPredefines p) {
            var obj = Resources.ResourceManager.GetObject(Enum.GetName(typeof(ButtonPredefines), p), Resources.Culture);
            if (obj != null)
                return (Bitmap) obj;
            return null;
        }

        #endregion
    }
}