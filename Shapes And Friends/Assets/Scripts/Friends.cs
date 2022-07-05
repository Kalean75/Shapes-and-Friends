using System.Collections.Generic;
using UnityEngine;

public class Friends : MonoBehaviour
{
	[Header("Friend attributes")]
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField] float friendSpeed = 5f;
	[SerializeField] float followDistance = 1f;
	[SerializeField] bool gradualColorChange = true;
	[Header("Leave timer elements")]
	[SerializeField] float fickleFriendTimerMax = 10f;
	[SerializeField] float fickleFriendTimerMin = 1f;
	[Header("Possible Colors")]
	[SerializeField] List<Color> colors = new List<Color>();
	[Header("Possible Shapes")]
	[SerializeField] List<Sprite> shapes = new List<Sprite>();
	float fickleFriendTimer;
	int attractionID;
	SpriteRenderer friendSprite;
	//Vector2 playerPosition;
	bool following = false;
	bool repel = false;
	bool colliderTriggered = false;

	//used to determine color
	int colorID;
	//used for shape
	int shapeID;

	// Start is called before the first frame update
	void Start()
	{
		//SetRandomColor();
		colorID = Random.Range(0, colors.Count - 1);
		shapeID = Random.Range(0, shapes.Count - 1);
		SetRandomShape();
		//sets timer between min and max range where friend leaves
		fickleFriendTimer = Random.Range(fickleFriendTimerMin, fickleFriendTimerMax);

	}

	// Update is called once per frame
	void Update()
	{
		moveFriend();
	}

	private void moveFriend()
	{
		if (following)
		{
			if (gradualColorChange)
			{
				friendSprite.color = Color.Lerp(friendSprite.color, colors[colorID], Time.deltaTime * 1);
			}
			//if timer is 0 leave
			if (fickleFriendTimer <= 0)
			{
				//temp change later
				transform.position += new Vector3(friendSpeed * Time.deltaTime, friendSpeed * Time.deltaTime, 0);
				//transform.position += this.transform.forward * Time.deltaTime * friendSpeed;
			}
			//if not 0 continue following
			else
			{
				Vector2 target = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x - followDistance, GameObject.FindGameObjectWithTag("Player").transform.position.y);
				Vector2 newPos = Vector2.MoveTowards(transform.position, target , friendSpeed * Time.deltaTime);
				transform.position = newPos;
				fickleFriendTimer -= Time.deltaTime;
			}
		}
		//if repeled move opposite
		else if(repel)
		{
			Vector2 newPos = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, -friendSpeed * Time.deltaTime);
			transform.position = newPos;
		}
		//if not collided move to left
		if (!repel && !following)
		{
			transform.position += new Vector3(-friendSpeed * Time.deltaTime, 0);
		}
	}

	//triggers when player enters trigger area
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.transform.gameObject.CompareTag("Player") && !colliderTriggered)
		{

			//set color on approach
			SetRandomColor();
			colliderTriggered = true;
			//access player script to get public variables
			int playerAttractionId = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getAttractionID();
			int playerShapeAttractionId = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getShapeID();

			if (this.attractionID == playerAttractionId || this.shapeID == playerShapeAttractionId)
			{
				following = true;
			}
			else if (this.attractionID != playerAttractionId || this.shapeID != playerShapeAttractionId)
			{
				repel = true;
			}
		}
	}

	//gets a random number between 1 and 6 and sets color based on number
	private void SetRandomColor()
	{
		friendSprite = GetComponent<SpriteRenderer>();
		if(!gradualColorChange)
		{
			friendSprite.color = colors[colorID];
		}
		else
		{
			friendSprite.color = Color.Lerp(friendSprite.color, colors[colorID], Time.deltaTime * 1);
		}
		attractionID = colorID;
		//Set the GameObject's Color quickly to a set Color (blue)
		/*switch (colorID)
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
		}*/
	}


	private void SetRandomShape()
	{
		friendSprite = GetComponent<SpriteRenderer>();
		friendSprite.sprite = shapes[shapeID];
	}

}
