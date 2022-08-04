using UnityEngine;

public class Scroller : MonoBehaviour
{
	//serializeField makes the value editable within unity if clicking on object
	[SerializeField][Range(1,3)] float scrollSpeed = 1f;

	//testing purposes remove later
	[SerializeField] bool scroll = true;
	[SerializeField] bool loop = false;
	float originalScrollSpeed;
	// Start is called before the first frame update
	// Update is called once per frame
	private void Start()
	{
		originalScrollSpeed = scrollSpeed;
	}
	void Update()
	{
		int i = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().getStageOfLife();
		scrollSpeed = changescrollSpeed(i);
		if (scroll)
		{
			if( i != 5)
			{
				transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);
			}

			if (loop)
			{
				if (transform.position.x < -11.32)
				{
					transform.position = new Vector3(11.32f, transform.position.y);
				}
			}
		}
	}

	public float getScrollSpeed()
	{
		return scrollSpeed;
	}

	private float changescrollSpeed(int stageOfLife)
	{
		switch(stageOfLife)
		{
			case 0:
				return originalScrollSpeed;
			case 1:
				return originalScrollSpeed + 0.25f;
			case 2:
				return originalScrollSpeed + 0.75f;
			case 3:
				return originalScrollSpeed + 1.5f;
			case 4:
				return originalScrollSpeed + 3.0f;
			case 5:
				return originalScrollSpeed;
			default:
				return originalScrollSpeed;

		}
	}
}
