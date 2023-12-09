using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -15f;
    public float strength = 5.5f;
    AudioManager audioManager;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            audioManager.PlaySFX(audioManager.wing);
            direction = Vector3.up * strength;
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime; 

    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }
    private void AnimateSprite()
    {
        spriteIndex++;
        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "obstcal")
        {
            audioManager.PlaySFX(audioManager.pipeTouch);
            FindObjectOfType<GameManager>().GameOver();
        }else if (other.gameObject.tag == "scoring")
        {
            audioManager.PlaySFX(audioManager.checkpoint);
            FindObjectOfType<GameManager>().increaeseScore();
        }
    }
}
