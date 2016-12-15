using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using QGEditors.WinForms.Properties;

namespace QGEditors.WinForms
{
    public enum ButtonPredefines
    {
        Glyph = 0,
        Backward = 2,
        Delete = 3,
        Down = 4,
        Edit = 5,
        Elipsis = 1,
        Favorite = 6,
        Forward = 7,
        Help = 8,
        Left = 9,
        Loop = 10,
        Minus = 11,
        Ok = 12,
        Option = 13,
        Pause = 14,
        Play = 15,
        Plus = 16,
        Redo = 17,
        Right = 18,
        Search = 19,
        Trash = 20,
        Undo = 21,
        Up = 22
    }

    internal static class ButtonPredefinesHelper
    {
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
            return null;
        }
    }
}
