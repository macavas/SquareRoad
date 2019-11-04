using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShowcase : MonoBehaviour
{
    public GameObject groundObject;

    private void OnMouseDown()
    {
        if (!GameManager.instance.isAlive)
            return;
        GameObject newGround = Instantiate(GroundSpawner.instance.groundObj, transform.position, Quaternion.identity);
        newGround.transform.parent = GroundSpawner.instance.grounds;
        GroundSpawner.instance.CheckGroundCount();
        GroundSpawner.instance.DestroyAllShowCases();
        FindObjectOfType<AudioManager>().Play("Square");
    }

}
