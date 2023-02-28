using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    public Vector2 direction = Vector2.right;
    private Vector2 input;
    public int initialSize = 4;
    private int bestScore = 2;
    private int current_score = 0;
    public Text currScore;
    public Text best_score;

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) {
                input = Vector2.up;
            } else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) {
                input = Vector2.down;
            }
        }
        else if (direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) {
                input = Vector2.right;
            } else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) {
                input = Vector2.left;
            }
        }
    }

    private void FixedUpdate()
    {
        if (input != Vector2.zero) {
            direction = input;
        }

        for (int i = segments.Count - 1; i > 0; i--) {
            segments[i].position = segments[i - 1].position;
        }

        float x = Mathf.Round(transform.position.x) + direction.x;
        float y = Mathf.Round(transform.position.y) + direction.y;

        transform.position = new Vector2(x, y);
    }

    public void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
        this.current_score = PlayerPrefs.GetInt("apple");
        PlayerPrefs.SetInt("apple", this.current_score + 1);
        this.currScore.text = $"Current score: {this.current_score + 1}".ToString();
    }

    public void ResetState()
    {
        this.current_score =  PlayerPrefs.GetInt("apple");
        if (this.current_score > this.bestScore) {
            this.bestScore = this.current_score;
            this.best_score.text = $"Best score: {this.bestScore}".ToString();
        }
        PlayerPrefs.SetInt("apple", 0);
        this.current_score = 0;
        this.currScore.text = $"Current score: {this.current_score}".ToString();
        direction = Vector2.right;
        transform.position = Vector3.zero;

        for (int i = 1; i < segments.Count; i++) {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform);

        for (int i = 0; i < initialSize - 1; i++) {
            Grow();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Food")) {
            Grow();
        } else if (other.gameObject.CompareTag("Obstacle")) {
            ResetState();
        }
    }

}
