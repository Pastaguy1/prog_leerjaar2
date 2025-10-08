using UnityEngine;

public class Tower : MonoBehaviour
{
    void Start()
    {
        RandomizeScale();
    }

    private void RandomizeScale()
    {
        float randomHeight = Random.Range(1f, 3f); 
        transform.localScale = new Vector3(1f, randomHeight, 1f);
    }
}
