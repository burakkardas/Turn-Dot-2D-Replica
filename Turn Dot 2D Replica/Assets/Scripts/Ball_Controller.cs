using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controller : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Game_Manager game_Manager;
    [SerializeField] private Shake_Controller shake_Controller;

    [Header("Gameplay")]
    [SerializeField] private float _moveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        game_Manager = GameObject.FindObjectOfType<Game_Manager>();
        shake_Controller = GameObject.FindObjectOfType<Shake_Controller>();
    }

    void Update()
    {
        transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);

        if(Input.GetMouseButtonDown(0)) {
            shake_Controller._isShake = true;
            transform.Rotate(0f, 0f, -90);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Score")) {
            game_Manager._score += 1;
            if(game_Manager._score != 0 && game_Manager._score % 2 == 0) {
                _moveSpeed += 0.2f;
            }   
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Wall")) {
            game_Manager.GameOver();
        }
    }
}
