using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectableObject : MonoBehaviour
{
    public bool selected = false;

    public abstract void OnSelect();

    public abstract void OnDeselect();

    void OnMouseDown()
    {
        if (selected == false)
        {
            OnSelect();
            selected = true;
        }
        else if (selected == true && Input.GetKey(InputController.GetInputEventKey("Deselect")) == true)
        {
            OnDeselect();
        }
        else//Selected an already selected object - LookAt
        {
            PlayerController.playerCam.LookAtPos(this.transform.position);
        }

    }



}
