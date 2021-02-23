using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    public Transform warpTarget;

    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        ScreenFader SF = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

        yield return StartCoroutine (SF.FadeToBlack () );

        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.transform.position = warpTarget.position;
            Camera.main.transform.position = warpTarget.position;
        }

        yield return StartCoroutine(SF.FadeToClear() );
    }
}
