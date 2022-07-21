using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    [SerializeField] GameObject npc;
    float scrollSpeed = 1f;
    SpriteRenderer spawnerSprite;
    // Start is called before the first frame update
    void Start()
    {
        scrollSpeed = GameObject.FindGameObjectWithTag("Background").GetComponent<Scroller>().getScrollSpeed();
        spawnerSprite = GetComponent<SpriteRenderer>();
        Color temp = spawnerSprite.color;
        temp.a = 0f;
        spawnerSprite.color = temp;
        scrollSpeed = GameObject.FindGameObjectWithTag("Background").GetComponent<Scroller>().getScrollSpeed();
        if (Random.Range(0, 2) == 1)
		{
            Instantiate(npc, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        }
    }

	private void Update()
	{
        transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);
    }

}
