using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [Header("Possible Colors")]
    [SerializeField] List<Color> colors = new List<Color>();
    //a list of the possible shapes the friends can be
    [Header("Possible Shapes")]
    [SerializeField] List<Sprite> shapes = new List<Sprite>();
	float scrollSpeed;
    //used for shape
    //int shapeID;

    SpriteRenderer npcSprite;
    // Start is called before the first frame update
    void Start()
    {
		npcSprite = GetComponent<SpriteRenderer>();
		scrollSpeed = GameObject.FindGameObjectWithTag("MainBG").GetComponent<Scroller>().getScrollSpeed();
        SetRandomShape(Random.Range(0, shapes.Count));
		SetRandomColor(Random.Range(0, colors.Count));
        //sets timer between min and max range where friend leaves
    }

    // Update is called once per frame
    void Update()
    {
		moveNPC(scrollSpeed);
	}

	private void moveNPC(float scrollSpeed)
	{
		transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);
	}
	private void SetRandomColor(int colorID)
	{
		npcSprite.color = colors[colorID];
	}

	private void OnTriggerEnter2D(Collider2D Other)
	{
		if (Other.gameObject.CompareTag("NPC"))
		{
			if (npcSprite != null)
			{
				SpriteRenderer otherShape = GameObject.FindGameObjectWithTag("NPC").GetComponent<SpriteRenderer>();
				otherShape.sprite = npcSprite.sprite;
				otherShape.color = npcSprite.color;
			}
		}

	}

	private void OnTriggerStay2D(Collider2D Other)
	{
		if (Other.gameObject.CompareTag("NPC"))
		{
				SpriteRenderer otherShape = GameObject.FindGameObjectWithTag("NPC").GetComponent<SpriteRenderer>();
				otherShape.sprite = npcSprite.sprite;
				otherShape.color = npcSprite.color;
		}

	}

	private void SetRandomShape(int shapeSpawnID)
	{
		npcSprite.sprite = shapes[shapeSpawnID];
		string shapeName = npcSprite.sprite.name.ToLower();
		switch (shapeName)
		{
			case string when shapeName.Contains("square"):
				break;
			case string when shapeName.Contains("triangle"):
				break;
			case string when shapeName.Contains("agon"):
				break;
		}
	}

}
