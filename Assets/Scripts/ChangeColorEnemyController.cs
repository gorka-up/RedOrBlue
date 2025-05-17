using UnityEngine;

public class ChangeColorEnemyController : MonoBehaviour
{
    EnemigoController enemigoController;

    public Sprite redSprite;
    public Sprite blueSprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        enemigoController = GetComponent<EnemigoController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (enemigoController.damageTaken)
        {
            if (transform.tag == "Blue_Enemy")
            {
                transform.tag = "Red_Enemy";
                spriteRenderer.sprite = redSprite;
            }
            else
            {
                transform.tag = "Blue_Enemy";
                spriteRenderer.sprite = blueSprite;
            }
            enemigoController.damageTaken = false;
        }
    }
}
