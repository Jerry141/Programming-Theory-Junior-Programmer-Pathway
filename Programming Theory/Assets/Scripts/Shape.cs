using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Shape : MonoBehaviour
{
    public Color Color => color;

    public string ShapeName
    {
        get
        {
            return shapeName;
        }
        set
        {
            if (string.IsNullOrEmpty(value))
                Debug.Log("Shape needs to have a name!");
            else if (shapesNames.Contains(value))
                Debug.Log($"Name {value} is taken!");
            else
            {
                if (shapesNames.Contains(shapeName))
                    shapesNames.Remove(shapeName);

                shapeName = value;
                shapesNames.Add(value);
            }
        }
    }

    [SerializeField]
    Color color;

    [SerializeField]
    string baseName;

    [SerializeField]
    protected string talkText;

    string shapeName;

    static List<string> shapesNames = new List<string>();


    void Awake()
    {
        color.a = 1;
        transform.GetChild(2).GetComponent<MeshRenderer>().material.color = color;

        ShapeName = baseName;
    }

    //POLYMORPHISM
    public virtual void DisplayText()
    {
        var bubble = TalkBubble.Instance;
        bubble.Open(this);
        bubble.text.text = talkText;
    }

    //POLUMORPHISM
    public virtual void EndTalk() { }
}
