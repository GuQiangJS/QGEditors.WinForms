/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System.Drawing;
using QGEditors.WinForms.Properties;
using System.ComponentModel;

namespace QGEditors.WinForms
{
    /// <summary>
    /// 预置的按钮类型。
    /// </summary>
    /// <remarks><see cref="QGEditors.WinForms.ButtonPredefines"/> 类型枚举
    /// 提供了多种按钮控件图像。</remarks>
    public enum ButtonPredefines
    {
        /// <summary>
        /// 自定义图像。
        /// </summary>
        Glyph = 0,
        /// <summary>
        /// 后退
        /// </summary>
        Backward = 2,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 3,
        /// <summary>
        /// 向下箭头
        /// </summary>
        Down = 4,
        /// <summary>
        /// 编辑
        /// </summary>
        Edit = 5,
        /// <summary>
        /// 省略号
        /// </summary>
        Elipsis = 1,
        /// <summary>
        /// 收藏
        /// </summary>
        Favorite = 6,
        /// <summary>
        /// 前进
        /// </summary>
        Forward = 7,
        /// <summary>
        /// 帮助
        /// </summary>
        Help = 8,
        /// <summary>
        /// 向左箭头
        /// </summary>
        Left = 9,
        /// <summary>
        /// 循环
        /// </summary>
        Loop = 10,
        /// <summary>
        /// 减号/负号
        /// </summary>
        Minus = 11,
        /// <summary>
        /// Ok
        /// </summary>
        Ok = 12,
        /// <summary>
        /// 选项/设置
        /// </summary>
        Option = 13,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause = 14,
        /// <summary>
        /// 播放
        /// </summary>
        Play = 15,
        /// <summary>
        /// 加号
        /// </summary>
        Plus = 16,
        /// <summary>
        /// 恢复/重复/恢复上一次操作
        /// </summary>
        Redo = 17,
        /// <summary>
        /// 向右箭头
        /// </summary>
        Right = 18,
        /// <summary>
        /// 搜索
        /// </summary>
        Search = 19,
        /// <summary>
        /// 垃圾箱/回收站
        /// </summary>
        Trash = 20,
        /// <summary>
        /// 撤消/复原/撤消本次操作
        /// </summary>
        Undo = 21,
        /// <summary>
        /// 向上箭头
        /// </summary>
        Up = 22
    }

    internal static class ButtonPredefinesHelper
    {
        #region Methods

        internal static Image GetImage(this ButtonPredefines p)
        {
            switch (p)
            {
                case ButtonPredefines.Backward:
                    return Resources.Backward;

                case ButtonPredefines.Delete:
                    return Resources.Delete;

                case ButtonPredefines.Down:
                    return Resources.Down;

                case ButtonPredefines.Edit:
                    return Resources.Edit;

                case ButtonPredefines.Elipsis:
                    return Resources.Elipsis;

                case ButtonPredefines.Favorite:
                    return Resources.Favorite;

                case ButtonPredefines.Forward:
                    return Resources.Forward;

                case ButtonPredefines.Help:
                    return Resources.Help;

                case ButtonPredefines.Left:
                    return Resources.Left;

                case ButtonPredefines.Loop:
                    return Resources.Loop;

                case ButtonPredefines.Minus:
                    return Resources.Minus;

                case ButtonPredefines.Ok:
                    return Resources.OK;

                case ButtonPredefines.Option:
                    return Resources.Option;

                case ButtonPredefines.Pause:
                    return Resources.Pause;

                case ButtonPredefines.Play:
                    return Resources.Play;

                case ButtonPredefines.Plus:
                    return Resources.Plus;

                case ButtonPredefines.Redo:
                    return Resources.Redo;

                case ButtonPredefines.Right:
                    return Resources.Right;

                case ButtonPredefines.Search:
                    return Resources.Search;

                case ButtonPredefines.Trash:
                    return Resources.Trash;

                case ButtonPredefines.Undo:
                    return Resources.Undo;

                case ButtonPredefines.Up:
                    return Resources.Up;

                default:
                    return null;
            }
        }

        #endregion
    }
}