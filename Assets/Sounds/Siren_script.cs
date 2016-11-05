using UnityEngine;
using System.Collections;

public class Siren_script : MonoBehaviour {

    public float speed;
    public Vector3 Target;

	// Use this for initialization
	void Start () {

        StartCoroutine(PlaySirenSound());


    }
	
	// Update is called once per frame
	void Update () {


  
	
	}

    IEnumerator PlaySirenSound()
    {
        float seconds = GetRandom();
        yield return new WaitForSeconds(seconds);
        Debug.Log("Moving forward.");
        StartCoroutine(StartMoving());

    }

    float GetRandom()
    {
        float random_secs = Random.Range(5.0f, 20.0f);
        Debug.Log("Seconds:" + random_secs);
        return random_secs;
    }

    IEnumerator StartMoving()
    {
        Debug.Log("Starting to move and play");
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
    
        float step = speed * Time.deltaTime;

        while (gameObject.transform.position != Target)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, step);
            yield return new WaitForEndOfFrame();
        }
        Debug.Log("Moving stopped.");
        audio.Stop();
    }

}