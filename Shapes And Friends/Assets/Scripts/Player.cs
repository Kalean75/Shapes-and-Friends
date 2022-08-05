using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("Player")]
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] float padding = 0.5f;
	[Header("Possible colors")]
	[SerializeField] List<Color> colors = new List<Color>();
	[Header("Possible Sprites")]
	[SerializeField] List<Sprite> shapes = new List<Sprite>();

	private float xMin;
	private float xMax;
	private float yMin;
	private float yMax;

	//public int numberOfFriends = 0;

	//if attractionid of player = attractionid of friend, shapes are attracted to each other
	private int attractionID = 0;
	//if shapeid of player = shapeid of friend, shapes are attracted to each other
	private int shapeSpawnID;
	private int shapeID;
	private int stageOfLife;
	private int currentNumberofFriends;
	private int totalFriends;
	SpriteRenderer playerSprite;
	//The Color to be assigned to the Renderer’s Material
	//Color m_NewColor;

	//These are the values that the Color Sliders return
	//float m_Red, m_Blue, m_Green;
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	// Start is called before the first frame update
	void Start()
	{
		playerSprite = GetComponent<SpriteRenderer>();
		SetRandomShape();
		SetRandomColor();
		SetBounds();
	}
	/// <summary>
	/// sets the shape of the player to a random one based on a random number.
	/// </summary>
	private void SetRandomShape()
	{
		shapeSpawnID = Random.Range(0, shapes.Count);
		playerSprite = GetComponent<SpriteRenderer>();
		playerSprite.sprite = shapes[shapeSpawnID];
		string shapeName = playerSprite.sprite.name.ToLower();
		switch (shapeName)
		{
			case string when shapeName.Contains("square"):
				shapeID = 1;
				break;
			case string when shapeName.Contains("triangle"):
				shapeID = 2;
				break;
			case string when shapeName.Contains("agon"):
				shapeID = 3;
				break;
			case string when shapeName.Contains("circle"):
				shapeID = 4;
				break;
		}
	}

	// Update is called once per frame
	void Update()
	{
		MovePlayer();
	}
	/// <summary>
	/// Moves the player based on keyboard input.
	/// </summary>
	private void MovePlayer()
	{
		//Time.deltaTime makes movement framerate independent
		//Horizontal = A D right and left
		var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		//Vertical = W S up and down arrows
		var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
		var newXPosition = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
		var newYPosition = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
		transform.position = new Vector2(newXPosition, newYPosition);
	}


	/// <summary>
	///  sets the bounds of the player movement. Locks the players movement to the viewport.
	/// </summary>
	private void SetBounds()
	{
		Camera gameCamera = Camera.main;
		xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
		xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
		yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
		yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
	}
	/// <summary>
	/// sets the shape to a random color based on a random number.
	/// </summary>
	private void SetRandomColor()
	{
		int randomNum = Random.Range(0, colors.Count);
		playerSprite.color = colors[randomNum];
		attractionID = randomNum;
	}
	/// <summary>
	/// gets the attraction id for use in repulsion or attraction.
	/// </summary>
	/// <returns>returns the attraction id for attraction or repulsion</returns>
	public int getAttractionID()
	{
		return attractionID;
	}
	/// <summary>
	/// gets the id for the shape for use in the list
	/// </summary>
	/// <returns>returns </returns>
	public int getShapeID()
	{
		return shapeID;
	}

	/// <summary>
	/// gets player's stage of life
	/// </summary>
	/// <returns>returns the current stage of life of the player
	public int getStageOfLife()
    {
		return stageOfLife;
    }

	/// <summary>
	/// Add 1 to the player stage of life to move to the next stage
	/// </summary>
	/// <returns>returns </returns>
	public void changeStageOfLife()
    {
		stageOfLife++;
    }

	public int getCurrentNumberofFriends()
    {
		return currentNumberofFriends;
    }

	public void addFriend()
    {
		currentNumberofFriends++;
		totalFriends++;
    }

	public void removeFriend()
    {
		currentNumberofFriends--;
    }

	public int getTotalFriends()
    {
		return totalFriends;
    }
}
