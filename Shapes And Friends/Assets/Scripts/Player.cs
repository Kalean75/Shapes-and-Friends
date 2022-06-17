using UnityEngine;

public class Player : MonoBehaviour
{
	[Header("Player")]
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] float padding = 0.5f;

	float xMin;
	float xMax;
	float yMin;
	float yMax;

	int numberOfFriends;

	public int attractionID = 0;

	SpriteRenderer playerSprite;
	//The Color to be assigned to the Renderer’s Material
	//Color m_NewColor;

	//These are the values that the Color Sliders return
	//float m_Red, m_Blue, m_Green;

	// Start is called before the first frame update
	void Start()
	{
		SetRandomColor();
		SetBounds();
	}
	// Update is called once per frame
	void Update()
	{
		MovePlayer();
	}
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

	//Makes so player can't move off screen. Possibly change
	private void SetBounds()
	{
		Camera gameCamera = Camera.main;
		xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
		xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
		yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
		yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
	}

	private void SetRandomColor()
	{
		int randomNum = Random.Range(1, 6);
		playerSprite = GetComponent<SpriteRenderer>();
		//Set the GameObject's Color quickly to a set Color (blue)
		switch (randomNum)
		{
			case 1:
				playerSprite.color = Color.red;
				attractionID = 1;
				break;
			case 2:
				playerSprite.color = Color.green;
				attractionID = 2;
				break;
			case 3:
				playerSprite.color = Color.blue;
				attractionID = 3;
				break;
			case 4:
				playerSprite.color = Color.cyan;
				attractionID = 4;
				break;
			case 5:
				playerSprite.color = Color.yellow;
				attractionID = 5;
				break;
			case 6:
				playerSprite.color = Color.magenta;
				attractionID = 6;
				break;
			default:
				playerSprite.color = Color.black;
				attractionID = 7;
				break;
		}
	}

}
