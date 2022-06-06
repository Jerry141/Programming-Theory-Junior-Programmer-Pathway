using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//INHERITANCE
public class Cube : Shape
{
    [SerializeField]
    string talkText2;

    [SerializeField]
    float text2Delay = .5f, repeatRate = 2;

    //POLYMORPHISM
    public override void DisplayText()
    {
        base.DisplayText();

        Invoke(nameof(AddText2), text2Delay);
    }

    void AddText2()
    {
        var bubble = TalkBubble.Instance;
        bubble.text.text += $"\n{talkText2}";

        Invoke(nameof(DisplayText), repeatRate);
    }

    public override void EndTalk()
    {
        CancelInvoke();
        base.EndTalk();
    }
}
