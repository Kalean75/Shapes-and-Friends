using System.Collections.Generic;
using UnityEngine;

public class Friends : MonoBehaviour
{
	[Header("Friend attributes")]
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField] float friendSpeed = 5f;
	[SerializeField] float followDistance = 1f;
	[SerializeField] bool gradualColorChange = true;
	//determines when a friend will leave the player
	[Header("Leave timer elements")]
	[SerializeField] float fickleFriendTimerMax = 10f;
	[SerializeField] float fickleFriendTimerMin = 1f;
	//a list of the possible colors the shapes can be
	[Header("Possible Colors")]
	[SerializeField] List<Color> colors = new List<Color>();
	//a list of the possible shapes the friends can be
	[Header("Possible Shapes")]
	[SerializeField] List<Sprite> shapes = new List<Sprite>();
	[Header("Reaction materials")]
	[SerializeField] Material[] materials = new Material[2];
	[Header("Audio")]
	[SerializeField] AudioClip[] reactionSounds = new AudioClip[2];
	[SerializeField] [Range(0, 1)] float ReactionSoundVolume = 0.25f;
	//the time a friend will leave, randomized between the minimum and maximum
	float fickleFriendTimer;
	//used to determine if friend is attracted to or repeled by player
	int attractionID;
	//the spriterenderer of friend
	SpriteRenderer friendSprite;
	//Vector2 playerPosition;
	bool following = false;
	bool repel = false;
	bool colliderTriggered = false;

	//used to determine color
	int colorID;
	//used for shape
	int shapeSpawnID;
	int shapeID;

	// Start is called before the first frame update
	void Start()
	{
		//SetRandomColor();
		colorID = Random.Range(0, colors.Count - 1);
		SetRandomShape(Random.Range(0, shapes.Count - 1));
		//sets timer between min and max range where friend leaves
		fickleFriendTimer = Random.Range(fickleFriendTimerMin, fickleFriendTimerMax);

	}

	// Update is called once per frame
	void Update()
	{
		moveFriend();
	}
	/// <summary>
	/// moves the friend towards the player if attracted or repels them if they are not.
	/// </summary>
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
			friendSprite.color = Color.Lerp(friendSprite.color, colors[colorID], Time.deltaTime * 1);
		}
		//if not collided move to left
		if (!repel && !following)
		{
			transform.position += new Vector3(-friendSpeed * Time.deltaTime, 0);
		}
	}


	/// <summary>
	/// triggers when player enters trigger area
	/// </summary>
	/// <param name="collision"> the collider that is being triggered</param>
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
			/*if (GameObject.FindGameObjectWithTag("Spawner").GetComponent<FriendSpawner>().getCurrentlySpawnedFriends() > 0)
			{
				GameObject.FindGameObjectWithTag("Spawner").GetComponent<FriendSpawner>().decrementCurrentlySpawnedFriends();
			}*/

			if (this.attractionID == playerAttractionId || this.shapeID == playerShapeAttractionId)
			{
				following = true;
				playSparkle();
			}
			else if (this.attractionID != playerAttractionId || this.shapeID != playerShapeAttractionId)
			{
				repel = true;
				playAngry();
			}
		}
	}

	/// <summary>
	/// gets a random number between 1 and 6 and sets color based on number
	/// </summary>
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
	}

	/// <summary>
	/// sets the shape of the friend to a random one.
	/// </summary>
	private void SetRandomShape(int index)
	{
		friendSprite = GetComponent<SpriteRenderer>();
		friendSprite.sprite = shapes[index];
		string shapeName = friendSprite.sprite.name.ToLower();
		switch (shapeName)
		{
			case string when shapeName.Contains("square"):
				shapeID = 1;
				break;
			case string when shapeName.Contains("triangle"):
				shapeID = 2;
				break;
			case string when shapeName.Contains("square"):
				shapeID = 3;
				break;
			case string when shapeName.Contains("rectangle"):
				shapeID = 3;
				break;
			case string when shapeName.Contains("agon"):
				shapeID = 4;
				break;
			case string when shapeName.Contains("trapezoid"):
				shapeID = 5;
				break;
		}
	}

	private void playAngry()
	{
		GetComponent<ParticleSystemRenderer>().material = materials[0];
		GetComponent<ParticleSystem>().Play();
		AudioSource.PlayClipAtPoint(reactionSounds[0], Camera.main.transform.position, ReactionSoundVolume);
	}

	private void playSparkle()
	{
		GetComponent<ParticleSystemRenderer>().material = materials[1];
		GetComponent<ParticleSystem>().Play();
		AudioSource.PlayClipAtPoint(reactionSounds[1], Camera.main.transform.position, ReactionSoundVolume);
	}
}
