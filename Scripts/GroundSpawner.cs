using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public static GroundSpawner instance;
    public Transform player;

    public GameObject showCaseObj;
    public GameObject groundObj;

    public Transform grounds;

    private void Awake()
    {
        instance = this;
        

        SpawnShowCases();
    }

    public void SpawnShowCases()
    {
        if(!Physics2D.OverlapCircle(player.position + Vector3.up, .3f))
        {
            GameObject newShowCase = Instantiate(showCaseObj, player.position + Vector3.up, Quaternion.identity);
            newShowCase.transform.parent = transform;
        }
        if (!Physics2D.OverlapCircle(player.position + Vector3.right, .3f))
        {
            GameObject newShowCase = Instantiate(showCaseObj, player.position + Vector3.right, Quaternion.identity);
            newShowCase.transform.parent = transform;
        }
        if (!Physics2D.OverlapCircle(player.position + Vector3.left, .3f))
        {
            GameObject newShowCase = Instantiate(showCaseObj, player.position + Vector3.left, Quaternion.identity);
            newShowCase.transform.parent = transform;
        }
        if (!Physics2D.OverlapCircle(player.position + Vector3.down, .3f))
        {
            GameObject newShowCase = Instantiate(showCaseObj, player.position + Vector3.down, Quaternion.identity);
            newShowCase.transform.parent = transform;
        }
    }

    public void DestroyAllShowCases()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void CheckGroundCount()
    {
        if(grounds.childCount > 3)
        {
            StartCoroutine(DestroyGround());
        }
    }

    IEnumerator DestroyGround()
    {
        grounds.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Destroy");
        yield return new WaitForSeconds(.3f);
        Destroy(grounds.GetChild(0).gameObject);
    }
}
