using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
public class NPC : MonoBehaviour
{
    [SerializeField] protected string Name;
    //[SerializeField] protected List<string> Dialogue = new List<string>();
    [SerializeField] protected List<string> Dialogue;
    //Have inventory later

    [SerializeField] protected bool canMove = false;
    [SerializeField] private float walkCooldown = 3f;
    private float walkTimer = 0f;

    [SerializeField] protected float moveSpeed = 2f;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite downSprite;
    [SerializeField] private Sprite leftSprite;

    private bool isMoving = false;

    public string getName()
    {
        return Name;
    }

    public string getDialogue(string start)
    {
        return Dialogue.Find(x => x.StartsWith(start));
    }

    public string getDialogue1()//Placeholder
    {
       // return Dialogue.Find(x => x.StartsWith("N"));
       return Dialogue[0];
    }

    private System.Collections.IEnumerator Walk(Vector3 direction, int walkDistance)
{
    isMoving = true;

    Vector3 target = transform.position + direction * walkDistance;

    while (Vector3.Distance(transform.position, target) > 0.001f)
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            moveSpeed * Time.deltaTime
        );

        yield return null; // Continue on the next frame.
    }

    transform.position = target;
    isMoving = false;
}

    public void NPC_RandomWalk()
    {
        int walkNum = Random.Range(1,11);
        Debug.Log("NPC Trying to MOVE");

        if(walkNum >= 7)
        {
            int direction = Random.Range(1,5);
            isMoving = true;
            int walkDistance = Random.Range(1, 7);
            
            if(direction == 1)
            {
                Debug.Log("NPC going up");
                spriteRenderer.sprite = upSprite;
                StartCoroutine(Walk(Vector3.up, walkDistance));
            } 
            else if(direction == 2)
            {
                Debug.Log("NPC going right");
                
                if(rightSprite == null)
                {
                    spriteRenderer.sprite = leftSprite;
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.sprite = rightSprite;
                    spriteRenderer.flipX = false;
                }

                StartCoroutine(Walk(Vector3.right, walkDistance));
            }
            else if(direction == 3)
            {
                Debug.Log("NPC going down");
                spriteRenderer.sprite = downSprite;
                StartCoroutine(Walk(Vector3.down, walkDistance));
            }
            else if(direction == 4)
            {
                Debug.Log("NPC going left");
                
                if(leftSprite == null)
                {
                    spriteRenderer.sprite = rightSprite;
                    spriteRenderer.flipX = true;
                }
                else
                {
                    spriteRenderer.sprite = leftSprite;
                    spriteRenderer.flipX = false;
                }

                StartCoroutine(Walk(Vector3.left, walkDistance));
            }
        }
    }

    void Update()
    {
        if(!canMove || isMoving)
        {
            return;
        }

        walkTimer -= Time.deltaTime;

        if (walkTimer <= 0f)
        {
            NPC_RandomWalk();
            walkTimer = walkCooldown;
        }
    }
}
