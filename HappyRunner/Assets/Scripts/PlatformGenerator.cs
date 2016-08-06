using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public GameObject platform;
    public Transform generationPoint;
    public float distinceBetween;

    private float platformWidth;

	// Use this for initialization
	void Awake () {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {

        GeneratePlatform();
	}

    public void GeneratePlatform()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distinceBetween, transform.position.y, 0);

            Instantiate(platform, generationPoint.transform.position, generationPoint.transform.rotation);
        }
    }
}
