﻿using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Interfaces.Serialization;
using System;

namespace Robust.Client.ViewVariables.Editors
{
    internal sealed class ViewVariablesPropertyEditorISelfSerialzable<T> : ViewVariablesPropertyEditor where T : ISelfSerialize
    {
        protected override Control MakeUI(object value)
        {
            var lineEdit = new LineEdit
            {
                Text = ((ISelfSerialize)value).Serialize(),
                Editable = !ReadOnly,
                SizeFlagsHorizontal = Control.SizeFlags.FillExpand,
            };

            if (!ReadOnly)
            {
                lineEdit.OnTextEntered += e =>
                {
                    var instance = (ISelfSerialize)Activator.CreateInstance(typeof(T));
                    instance.Deserialize(e.Text);
                    ValueChanged(instance);
                };
            }

            return lineEdit;
        }
    }
}
