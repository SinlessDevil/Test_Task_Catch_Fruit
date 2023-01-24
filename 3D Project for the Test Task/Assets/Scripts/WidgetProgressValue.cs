using UnityEngine;

public class WidgetProgressValue : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text _textValue;

    private void Awake()
    {
        if (_textValue == null)
            throw new System.NullReferenceException($"The {_textValue} Component is not assigned in the inspector!");
    }

    public void SetValue(string newValue)
    {
        _textValue.text = newValue;
    }

    public void SetColor(Color color)
    {
        _textValue.color = color;
    }

    private void Handle_AnimationOver()
    {
        Destroy(gameObject);
    }
}