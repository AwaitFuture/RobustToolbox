﻿using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;

namespace Robust.Client.ViewVariables.Editors
{
    internal sealed class ViewVariablesPropertyEditorString : ViewVariablesPropertyEditor
    {
        protected override Control MakeUI(object value)
        {
            var lineEdit = new LineEdit
            {
                Text = (string) value,
                Editable = !ReadOnly,
                SizeFlagsHorizontal = Control.SizeFlags.FillExpand,
            };

            if (!ReadOnly)
            {
                lineEdit.OnTextEntered += e => ValueChanged(e.Text);
            }

            return lineEdit;
        }
    }
}
