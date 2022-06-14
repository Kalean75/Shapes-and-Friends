using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friends : MonoBehaviour
{
	[Header("Friend")]
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField] float friendSpeed = 10f;
	SpriteRenderer friendSprite;
	int attractionId;
	// Start is called before the first frame update
	void Start()
    {
		SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
		//I put this here for shits and giggles. If you see this, Remove it.
		SetRandomColor();
    }

	//gets a random number between 1 and 6 and sets color based on number
	private void SetRandomColor()
	{
		int randomNum = Random.Range(1, 6);
		friendSprite = GetComponent<SpriteRenderer>();
		//Set the GameObject's Color quickly to a set Color (blue)
		switch (randomNum)
		{
			//if randomNum = 1 color = Red.
			case 1:
				friendSprite.color = Color.red;
				break;
			//if randomNum = 1 color = Green.
			case 2:
				friendSprite.color = Color.green;
				break;
			//if randomNum = 1 color = Blue.
			case 3:
				friendSprite.color = Color.blue;
				break;
			//if randomNum = 1 color = Cyan.
			case 4:
				friendSprite.color = Color.cyan;
				break;
			//if randomNum = 1 color = Yellow.
			case 5:
				friendSprite.color = Color.yellow;
				break;
			//if randomNum = 1 color = Magenta.
			case 6:
				friendSprite.color = Color.magenta;
				break;
			//default color = black(will presently never be black)
			default:
				friendSprite.color = Color.black;
				break;
		}
	}
}
