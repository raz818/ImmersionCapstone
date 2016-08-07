using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] platforms;
    public float delay = 2f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);

    // private float platformWidth;
    private int platformSelector;
   // private float[] platformWidths;

    // Use this for initialization
	
	// Update is called once per frame
	void Start () {

        ResetDelay();
        StartCoroutine(EnemyGenerator());
	}


    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);

        if (active)
        {
            platformSelector = Random.Range(0, platforms.Length);

            Instantiate(platforms[platformSelector], transform.position, transform.rotation);
           
            ResetDelay();
        }
        StartCoroutine(EnemyGenerator());

    }
    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }
}
