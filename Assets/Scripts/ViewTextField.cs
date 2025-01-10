using UnityEngine;
using UnityEngine.UI;

public class ViewTextField
{
    protected Text _textField;

    public void SetTextField(Text text)
    {
        _textField = text;
    }

    public void SetValue(string str)
    {
        _textField.text = str;
        ActionView();
    }

    public virtual void ActionView()
    {

    }
}
