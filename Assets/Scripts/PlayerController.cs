using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera sceneCamera;

    [SerializeField] private float moveSpeed;
    private Vector2 moveDirection;

    private Vector2 mousePosition;
    [SerializeField] private WeaponController weaponController;

    void Update()
    {
        ProcessInputs();
    }

    //Fisicas Aqui
    void FixedUpdate()
    {
        Move();
    }

    //Movimiento
    void ProcessInputs()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weaponController.Fire();
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        //Rotar al jugador para seguir el raton
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }

    //Disparo
}
