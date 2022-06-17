using UnityEngine;

public class Scroller : MonoBehaviour
{
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField] float scrollSpeed = 5f;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//Add renderer to background
		transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);

		if (transform.position.x < -10)
		{
			transform.position = new Vector3(10f, transform.position.y);
		}
	}
}
