using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] platforms;
    public float delay = 2f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);
    public delegate void SpawnDelegate(InstantVelocity objectVelocity);
    public event SpawnDelegate OnSpawn;

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

            GameObject newPlatform = (GameObject)Instantiate(platforms[platformSelector], transform.position, transform.rotation);
            if (OnSpawn != null)
            {
                OnSpawn(newPlatform.GetComponent<InstantVelocity>());
            }

            ResetDelay();
        }
        StartCoroutine(EnemyGenerator());

    }
    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }
}
