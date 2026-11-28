using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;//To let it interact with UI

public class InfoTextScript : MonoBehaviour
{
    public string message;//Put in what we want to say

    private void OnMouseEnter(PointerEventData pointerEventData)
    {
       // MoreInfoScript._instance.SetTrueAndChange(message);
        Debug.Log("Mouse entered");
    }

    private void OnMouseExit(PointerEventData pointerEventData)
    {
       // MoreInfoScript._instance.SetFalseAndReset();
        Debug.Log("Mouse exited");
    }
}
