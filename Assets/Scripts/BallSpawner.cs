using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject prefab; // je bal prefab
    private float elapsedTime = 0f;

    // Start wordt één keer aangeroepen bij het begin van het spel
    void Start()
    {
        for (int i = 0; i < 100; i++)
        {
            Color color = RandomColor();
            Vector3 randPos = RandomPosition(-10f, 10f);
            CreateBall(color, randPos);
        }
    }

    // Update wordt elke frame aangeroepen
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime > 1f)
        {
            Color color = RandomColor();
            Vector3 randPos = RandomPosition(-10f, 10f);
            GameObject ball = CreateBall(color, randPos);
            DestroyBall(ball);
            elapsedTime = 0f;
        }
    }

    // Functie om een bal te maken met kleur en positie
    private GameObject CreateBall(Color c, Vector3 position)
    {
        GameObject ball = Instantiate(prefab, position, Quaternion.identity);
        Material mat = ball.GetComponent<MeshRenderer>().material;

        // Voor standaard pipeline
        mat.SetColor("_Color", c);

        // Voor URP
        if (mat.shader.name == "Universal Render Pipeline/Lit")
        {
            mat.SetColor("_BaseColor", c);
        }

        return ball;
    }

    // Functie om een bal na 3 seconden te vernietigen
    private void DestroyBall(GameObject ball)
    {
        Destroy(ball, 3f);
    }
    // Functie om een random kleur te maken
    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b, 1f);
    }

    // Functie om een random positie te maken
    private Vector3 RandomPosition(float min, float max)
    {
        float x = Random.Range(min, max);
        float y = 5f; // hoogte waar de bal verschijnt
        float z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

}

