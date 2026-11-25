using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoreInfoScript : MonoBehaviour
{
    //https://www.youtube.com/watch?v=y2N_J391ptg
    //Used this ^^^ for reference
    public static MoreInfoScript _instance;//The info box script

    public TextMeshProUGUI textComponent;

    private void Awake()
    {
        if (_instance != null && _instance!=this)
        {
            Destroy(this.gameObject);//Make sure we only have one
        }
        else
        {
            _instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = true;//Mouse is made visable
        gameObject.SetActive(false);//Turn off the text box until needed
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;//Box follows mouse
    }

    public void SetTrueAndChange(string message)
    {
        gameObject.SetActive(true);//Make text visable
        textComponent.text = message;//Set text to inputted string
        Debug.Log("Info revealed");
    }

    public void SetFalseAndReset()
    {
        gameObject.SetActive(false);//Make text invisable
        textComponent.text = string.Empty;//Set text to nothing
        Debug.Log("Info hidden");
    }
}
