using UnityEngine;

public class Scroller : MonoBehaviour
{
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField] float scrollSpeed = 5f;

	//testing purposes remove later
	[SerializeField] bool scroll = true;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (scroll)
		{
			//Add renderer to background
			transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);

			if (transform.position.x < -25)
			{
				transform.position = new Vector3(25f, transform.position.y);
			}
		}
	}
}
