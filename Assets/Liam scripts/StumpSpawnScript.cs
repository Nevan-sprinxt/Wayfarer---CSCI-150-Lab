using UnityEngine;

public class StumpSpawnScript : MonoBehaviour
{
    [SerializeField] GameObject Stump;
       
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float topLimit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for (float i = leftLimit; i <= rightLimit; i++)
        {
            //spawn top row
            Vector3 spawnPosition = transform.position + new Vector3(i, topLimit, 0);
            Instantiate(Stump, spawnPosition, Quaternion.identity);
            //spawn bottom row
            Vector3 spawnPosition2 = transform.position + new Vector3(i, bottomLimit, 0);
            Instantiate(Stump, spawnPosition2, Quaternion.identity);
        }
        for (float i = bottomLimit; i <= topLimit; i++)
        {
            //spawn left row
            Vector3 spawnPosition3 = transform.position+new Vector3(leftLimit, i, 0);
            Instantiate(Stump, spawnPosition3, Quaternion.identity);
            //spawn right row
            Vector3 spawnPosition4 = transform.position + new Vector3(rightLimit, i, 0);
            Instantiate(Stump, spawnPosition4, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
