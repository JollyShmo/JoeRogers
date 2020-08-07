using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform Trans;
    public GameObject ObjtoSpawn;

    private void Start()
    {
           Instantiate(ObjtoSpawn, Trans.position, Quaternion.identity);
    }
}
