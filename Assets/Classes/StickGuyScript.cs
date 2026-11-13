using UnityEngine;
using UnityEngine.UI;

public class StickGuyScript : MonoBehaviour
{
    public Text yapping;
    public StickGuy SG=new StickGuy();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        yapping.text = SG.getDialogue1();
        // Debug.Log(SG.getDialogue1());
        //yapping.text = "Yap";
        Debug.Log("YAP");
    }
}
