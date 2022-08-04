using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] GameObject npc;
    //SpriteRenderer spawnerSprite;
    // Start is called before the first frame update
    void Start()
    {
        //spawnerSprite = GetComponent<SpriteRenderer>();
       /* Color temp = spawnerSprite.color;
        temp.a = 0f;
        spawnerSprite.color = temp;*/
        if (Random.Range(0, 2) == 1)
		{
            Instantiate(npc, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
    }
}
