using UnityEngine;

public class Random_obstacle : MonoBehaviour
{
     public Collider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x+5, bounds.max.x-5);
        float y = Random.Range(bounds.min.y+5, bounds.max.y-5);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RandomizePosition();
    }
}
