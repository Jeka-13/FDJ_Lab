using UnityEngine;

public class Food : MonoBehaviour
{
    public Collider2D gridArea;
    public float x;
    public float y;

    private void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        this.x = Random.Range(bounds.min.x+2, bounds.max.x-2);
        this.y = Random.Range(bounds.min.y+2, bounds.max.y-2);

        this.x = Mathf.Round(this.x);
        this.y = Mathf.Round(this.y);

        transform.position = new Vector2(this.x, this.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        RandomizePosition();
    }

}
