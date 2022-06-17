using UnityEngine;

public class Friends : MonoBehaviour
{
	[Header("Friend")]
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField] float friendSpeed = 10f;
	int attractionID;
	SpriteRenderer friendSprite;
	int playerAttractionId;
	Vector2 playerPosition;
	bool following = false;
	//used to determine color
	int colorID;
	// Start is called before the first frame update
	void Start()
	{
		//SetRandomColor();
		colorID = Random.Range(1, 6);

	}

	// Update is called once per frame
	void Update()
	{
		if (following == true)
		{

		}
	}

	//triggers when player enters trigger area
	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("triggered");
		//set color on approach
		SetRandomColor();
		//access player script to get public variables
	//playerAttractionId = gameObject.GetComponent<Player>().attractionID;
//Debug.Log("player attr id " + playerAttractionId);
Debug.Log("friend attr id " + attractionID);
		if (attractionID == playerAttractionId)
		{
			following = true;
			//access player script to get public variables
		}

	}

	//gets a random number between 1 and 6 and sets color based on number
	private void SetRandomColor()
	{
		friendSprite = GetComponent<SpriteRenderer>();
		//Set the GameObject's Color quickly to a set Color (blue)
		switch (colorID)
		{
			//if randomNum = 1 color = Red.
			case 1:
				friendSprite.color = Color.red;
				attractionID = 1;
				break;
			//if randomNum = 2 color = Green.
			case 2:
				friendSprite.color = Color.green;
				attractionID = 1;
				break;
			//if randomNum = 3 color = Blue.
			case 3:
				friendSprite.color = Color.blue;
				attractionID = 1;
				break;
			//if randomNum = 4 color = Cyan.
			case 4:
				friendSprite.color = Color.cyan;
				attractionID = 1;
				break;
			//if randomNum = 5 color = Yellow.
			case 5:
				friendSprite.color = Color.yellow;
				attractionID = 1;
				break;
			//if randomNum = 6 color = Magenta.
			case 6:
				friendSprite.color = Color.magenta;
				attractionID = 1;
				break;
			//default color = black(will presently never be black)
			default:
				friendSprite.color = Color.black;
				attractionID = 1;
				break;
		}
	}
}
