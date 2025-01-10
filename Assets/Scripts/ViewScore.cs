using UnityEngine;
using UnityEngine.UI;

public class ViewScore : ViewTextField
{
    [SerializeField] private Animator _animView;

    public ViewScore(Text text, Animator animator)
    {
        SetTextField(text);
        _animView = animator;
    }

    public override void ActionView()
    {
        base.ActionView();

        _animView.Play("Scale");
    }
}
