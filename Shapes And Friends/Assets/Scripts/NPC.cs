using System.Collections;
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
    /*[Header("Reaction materials")]
    [SerializeField] Material[] materials = new Material[2];
    [Header("Audio")]
    [SerializeField] AudioClip[] reactionSounds = new AudioClip[2];
    [SerializeField] [Range(0, 1)] float ReactionSoundVolume = 0.25f;*/
    int colorID;
    //used for shape
    int shapeSpawnID;
    //int shapeID;

    SpriteRenderer npcSprite;
    // Start is called before the first frame update
    void Start()
    {
		scrollSpeed = GameObject.FindGameObjectWithTag("Background").GetComponent<Scroller>().getScrollSpeed();
		colorID = Random.Range(0, colors.Count - 1);
        shapeSpawnID = Random.Range(0, shapes.Count - 1);
        SetRandomShape();
		SetRandomColor();
        //sets timer between min and max range where friend leaves
    }

    // Update is called once per frame
    void Update()
    {
		transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);
	}
	private void SetRandomColor()
	{
		npcSprite = GetComponent<SpriteRenderer>();
		npcSprite.color = colors[colorID];
	}

	private void SetRandomShape()
	{
		npcSprite = GetComponent<SpriteRenderer>();
		npcSprite.sprite = shapes[shapeSpawnID];
		string shapeName = npcSprite.sprite.name.ToLower();
		switch (shapeName)
		{
			case string when shapeName.Contains("square"):
				//shapeID = 1;
				break;
			case string when shapeName.Contains("triangle"):
				//shapeID = 2;
				break;
			case string when shapeName.Contains("square"):
				//shapeID = 3;
				break;
			case string when shapeName.Contains("rectangle"):
				//shapeID = 3;
				break;
			case string when shapeName.Contains("agon"):
				//shapeID = 4;
				break;
			case string when shapeName.Contains("trapezoid"):
				//shapeID = 5;
				break;
		}
	}

}
