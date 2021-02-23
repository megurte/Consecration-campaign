using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnFire : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private IEnumerator Delete()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
