using UnityEngine;

public class Scroller : MonoBehaviour
{
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField] float scrollSpeed = 5f;

	//testing purposes remove later
	[SerializeField] bool scroll = true;
	[SerializeField] bool loop = false;
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

			if (loop)
			{
				if (transform.position.x < -11.32)
				{
					transform.position = new Vector3(11.32f, transform.position.y);
				}
			}
		}
	}
}
