using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera sceneCamera;

    private Vector2 moveDirection;

    private Vector2 mousePosition;
    [SerializeField] private WeaponController weaponController;
    
    //estadisticas del jugador
    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    [SerializeField] private double Damage;
    [SerializeField] private double Greed;
    [SerializeField] private double Cadence;
    [SerializeField] private float moveSpeed;

    [SerializeField] public int XP;

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

        if (Input.GetMouseButtonDown(1))
        {
            weaponController.ChangeMode();
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
    //hacerse daño
    public void GetHurt()
    {
        Health--;
        Debug.Log(Health);
        if (Health <= 0)
        {
            Muerto();
        }
    }
    //morirse
    void Muerto()
    { 
    }

    public int HealthLvl = 1;
    public int DamageLvl = 1;
    public int GreedLvl = 1;
    public int CadenceLvl = 1;
    public int moveSpeedLvl = 1;
    public void LevelUp(int opcion)
    {
        switch (opcion)
        {
            //Health
            case 1:
                Health++;
                MaxHealth++;
                HealthLvl++;
                Debug.Log(MaxHealth);
                break;
            //Damage
            case 2:
                Damage = Damage + Damage * 0.2;
                DamageLvl++;
                Debug.Log(Damage);
                break;
            //Greed
            case 3:
                Greed = Greed + 0.3;
                GreedLvl++;
                Debug.Log(Greed);
                break;
            //Cadence
            case 4:
                Cadence = Cadence + Cadence * 0.15;
                CadenceLvl++;
                Debug.Log(Cadence);
                break;
            //Speed
            case 5:
                break;
        }
    }
}
