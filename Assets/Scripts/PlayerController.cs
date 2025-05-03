using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera sceneCamera;

    private Vector3 movementVector;

    private Vector2 mousePosition;
    [SerializeField] private WeaponController weaponController;
    
    //estadisticas del jugador
    [SerializeField] public int Health;
    [SerializeField] public int MaxHealth;
    [SerializeField] public double Damage;
    [SerializeField] public double Greed;
    [SerializeField] public double Cadence;
    [SerializeField] public float moveSpeed;

    [SerializeField] public int XP;

    public int HealthLvl = 1;
    public int DamageLvl = 1;
    public int GreedLvl = 1;
    public int CadenceLvl = 1;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

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
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            weaponController.Fire();
        }

        if (Input.GetMouseButtonDown(1) && Time.timeScale != 0)
        {
            weaponController.ChangeMode();
        }

        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
    }
    void Move()
    {
        rb.linearVelocity = (movementVector * moveSpeed);

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
        }
    }
}
