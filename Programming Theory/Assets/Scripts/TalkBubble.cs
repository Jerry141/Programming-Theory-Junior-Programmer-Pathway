using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkBubble : MonoBehaviour
{
    public static TalkBubble Instance;

    public Text text;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    Text nameText;

    Shape shape;
    InputField field;
    Text placeHolderText;


    void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);

        Instance = this;

        field = GetComponentInChildren<InputField>(true);
        field.onEndEdit.AddListener(SetName);
        placeHolderText = field.placeholder.GetComponent<Text>();
    }

    public void Open(Shape shape)
    {
        panel.SetActive(true);

        this.shape = shape;

        nameText.color = shape.Color;
        SetNameText();
        SetPlaceHolderText();
    }

    // ABSTRACTION
    void SetNameText() => nameText.text = shape.ShapeName + " :";
    void SetPlaceHolderText() => placeHolderText.text = $"Rename {shape.ShapeName}...";

    public void Close()
    {
        if (shape != null)
            shape.EndTalk();

        panel.SetActive(false);
    }

    void SetName(string name)
    {
        if (shape == null)
            return;

        shape.ShapeName = name;

        field.text = string.Empty;

        SetNameText();
        SetPlaceHolderText();
    }
}
