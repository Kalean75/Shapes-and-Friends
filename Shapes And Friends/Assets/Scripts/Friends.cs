using UnityEngine;

public class Friends : MonoBehaviour
{
	[Header("Friend")]
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField] float friendSpeed = 5f;
	int attractionID;
	SpriteRenderer friendSprite;
	int playerAttractionId;
	//Vector2 playerPosition;
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
		moveFriend();
	}

	private void moveFriend()
	{
		Vector2 force = GameObject.FindGameObjectWithTag("Player").transform.position;
		if (following)
		{
			//playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
			//transform.position = playerPosition;
			var newXPosition = GameObject.FindGameObjectWithTag("Player").transform.position.x;
			var newYPosition = GameObject.FindGameObjectWithTag("Player").transform.position.y - 1;
			transform.position = new Vector2(newXPosition, newYPosition);
		}
	}

	//triggers when player enters trigger area
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.transform.gameObject.tag == "Player")
		{

		//set color on approach
		SetRandomColor();
		//access player script to get public variables
		playerAttractionId = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().attractionID;

		if (this.attractionID == playerAttractionId && !following)
		{
			following = true;
		}
		else
		{
				var force = transform.position - collision.transform.position;

				force.Normalize();
				GetComponent<Rigidbody2D>().AddForce(force * friendSpeed, ForceMode2D.Impulse);
			}
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
				attractionID = 2;
				break;
			//if randomNum = 3 color = Blue.
			case 3:
				friendSprite.color = Color.blue;
				attractionID = 3;
				break;
			//if randomNum = 4 color = Cyan.
			case 4:
				friendSprite.color = Color.cyan;
				attractionID = 4;
				break;
			//if randomNum = 5 color = Yellow.
			case 5:
				friendSprite.color = Color.yellow;
				attractionID = 5;
				break;
			//if randomNum = 6 color = Magenta.
			case 6:
				friendSprite.color = Color.magenta;
				attractionID = 6;
				break;
			//default color = black(will presently never be black)
			default:
				friendSprite.color = Color.black;
				attractionID = 0;
				break;
		}
	}
}
