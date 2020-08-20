using UnityEngine;

public class PlayerSpawnRando : MonoBehaviour
{
    public Transform[] startingPos;

    void Start()
    {
        int randoStartingPos = Random.Range(0, startingPos.Length);
        transform.position = startingPos[randoStartingPos].position;
    }
}
