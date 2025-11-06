using UnityEngine;
using System.Collections;

public class Elf : EnemyParent
{
    private Renderer rend;
    private bool isVisible = true;

    void Start()
    {
        moveSpeed = 6f; 
        health = 2; 
        rend = GetComponentInChildren<Renderer>();
        StartCoroutine(ToggleVisibility());
    }

    private IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); 
            isVisible = !isVisible;
            if (rend != null)
                rend.enabled = isVisible;
            if (!isVisible)
                yield return new WaitForSeconds(0.5f); 
        }
    }
}
