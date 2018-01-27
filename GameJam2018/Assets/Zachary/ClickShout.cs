using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickShout : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine("GrowShrink");
        Destroy(gameObject, 2f);
	}
	
    IEnumerator GrowShrink()
    {
        Vector3 startingScale = transform.localScale;
        Vector3 expandedScale = new Vector3(1, 1, 1);
        float time = 1;
        float timeSoFar = 0;

        while (timeSoFar < time)
        {
            transform.localScale = Vector3.Lerp(startingScale, expandedScale, (timeSoFar / time));
            timeSoFar += Time.deltaTime;
            yield return null;
        }
        timeSoFar = 0;
        while (timeSoFar < time)
        {
            transform.localScale = Vector3.Lerp(expandedScale, startingScale, (timeSoFar / time));
            timeSoFar += Time.deltaTime;
            yield return null;
        }

    }

}
