using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;

    private void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x+2, bounds.max.x-2);
        float y = Random.Range(bounds.min.y+2, bounds.max.y-2);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RandomizePosition();
    }

}
