using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public float fallInterval = 1.0f; // Blokların ne sıklıkla düşeceği (saniye cinsinden)
    public float gridSize = 1.0f; // Grid hücre boyutu

    private float fallTimer;
    private bool falling;

    void Start()
    {
        fallTimer = fallInterval;
    }

    void Update()
    {
        fallTimer -= Time.deltaTime;
        if (fallTimer <= 0f)
        {
            Fall();
            fallTimer = fallInterval;
        }
    }

    void Fall()
    {
        if (falling)
        {
            // Şu anki pozisyonu al
            Vector2 currentPosition = transform.position;

            // Yeni pozisyonu hesapla
            Vector2 newPosition = new Vector2(currentPosition.x, currentPosition.y - gridSize);

            // Zemin veya başka bir blok ile çarpışma kontrolü

            // Yeni pozisyona taşı
            transform.position = newPosition;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                falling = false;
            }
            else
            {
                falling = true;
            }
        }
    }
}