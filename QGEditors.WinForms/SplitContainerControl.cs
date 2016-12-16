/*
 *  QGEditor
 *  Copyright (c) 2014-2016 GuQiang - <guqiangjs@gmail.com>
 *  ALL RIGHTS RESERVED
*/

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QGEditors.WinForms
{
    public sealed class SplitContainerControl : SplitContainer
    {
        #region Fields

        //绘图高度
        private const int _HEIGHT = 1;

        //最大高度或最大宽度（根据Orientation属性确定）
        private const int _MAX = 15;

        //间隔宽度
        private const int _SPACING = 3;

        //绘图宽度
        private const int _WIDTH = 1;

        #endregion

        #region Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            if (e == null || e.ClipRectangle == null || e.Graphics == null)
            {
                return;
            }

            Point mousePoint = this.PointToClient(Control.MousePosition);

            Pen pen = SystemPens.ControlDark;
            Brush brush = SystemBrushes.ControlDark;

            if (mousePoint.X <= e.ClipRectangle.Width && mousePoint.Y <= e.ClipRectangle.Height)
            {
                pen = SystemPens.ControlDarkDark;
                brush = SystemBrushes.ControlDarkDark;
            }

            Rectangle rect = new Rectangle();

            if (this.Orientation == Orientation.Horizontal)
            {
                int startX = (e.ClipRectangle.Width / 2 - _MAX / 2);
                int endX = (e.ClipRectangle.Width / 2 + _MAX / 2);
                rect.X = startX;
                rect.Width = _MAX;
                rect.Y = e.ClipRectangle.Y + (e.ClipRectangle.Height - _HEIGHT) / 2;
                rect.Height = e.ClipRectangle.Height - 1;
            }
            else
            {
                int startX = (e.ClipRectangle.Height / 2 - _MAX / 2);
                int endX = (e.ClipRectangle.Height / 2 + _MAX / 2);
                rect.X = e.ClipRectangle.X + (e.ClipRectangle.Width - _WIDTH) / 2;
                rect.Width = e.ClipRectangle.Width - 1;
                rect.Y = startX;
                rect.Height = _MAX;
            }

            Queue<Rectangle> rects = new Queue<Rectangle>();

            if (this.Orientation == Orientation.Horizontal)
            {
                int left = rect.X;
                while (left < (rect.X + _MAX) && left + _WIDTH < (rect.X + _MAX))
                {
                    Rectangle rec = new Rectangle();
                    rec.X = left;
                    rec.Width = _WIDTH;
                    rec.Height = _HEIGHT;
                    rec.Y = rect.Y;
                    left = left + _SPACING;
                    rects.Enqueue(rec);
                }
            }
            else
            {
                int top = rect.Y;
                while (top < (rect.Y + _MAX) && top + _HEIGHT < (rect.Y + _MAX))
                {
                    Rectangle rec = new Rectangle();
                    rec.X = rect.X;
                    rec.Width = _WIDTH;
                    rec.Height = _HEIGHT;
                    rec.Y = top;
                    top = top + _SPACING;
                    rects.Enqueue(rec);
                }
            }
            if (rects.Count > 0)
            {
                e.Graphics.DrawRectangles(pen, rects.ToArray());
                e.Graphics.FillRectangles(brush, rects.ToArray());
            }
        }

        #endregion
    }
}