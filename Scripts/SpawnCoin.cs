using System.Collections;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public Transform Trans;
    public GameObject ObjtoSpawn;
    public Transform transObj;
    public float waitTime;
    public float spawnRadius;
    private IEnumerator coroutine;

    private void Start()
    {   
        coroutine = WaitSpawn(waitTime);
        StartCoroutine(coroutine);       
    }
    private IEnumerator WaitSpawn(float waitTime)
    {
        while (true)
        {
           
            yield return new WaitForSeconds(waitTime);
            var h = Instantiate(ObjtoSpawn, transObj.position = new Vector2(Trans.position.x, Trans.position.y) + Random.insideUnitCircle * spawnRadius, Quaternion.identity);
            ObjtoSpawn.SetActive(true);
            Destroy(h);
        }
    }
}
