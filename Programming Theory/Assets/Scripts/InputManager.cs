using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    Camera cam;

    // Start is called before the first frame update
    void Start() => cam = Camera.main;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)
            && !EventSystem.current.IsPointerOverGameObject())
        {
            TalkBubble.Instance.Close();

            CheckToSelect();
        }
    }

    //ABSTRACTION
    void CheckToSelect()
    {
        if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out RaycastHit hit)
            && hit.collider.TryGetComponent(out Shape character))
            character.DisplayText();
    }
}
