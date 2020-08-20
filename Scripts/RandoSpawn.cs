using UnityEngine;

public class RandoSpawn : MonoBehaviour
{
    public GameObject[] objects;

    private void Start()
    {
        int rando = Random.Range(0, objects.Length);
        Instantiate(objects[rando], transform.position, Quaternion.identity);
    }
}
