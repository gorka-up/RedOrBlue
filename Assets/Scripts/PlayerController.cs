using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera sceneCamera;

    private Vector3 movementVector;

    private Vector2 mousePosition;
    [SerializeField] private WeaponController weaponController;
    private bool canShoot;
    private double nextShoot;

    private float nextDamage;
    private float invulnerability = 1f;
    
    //estadisticas del jugador
    [SerializeField] public int Health;
    [SerializeField] public int MaxHealth;
    [SerializeField] public double Greed;
    [SerializeField] public float moveSpeed;

    [SerializeField] public double Red_Damage;
    [SerializeField] public double Red_Cadence;

    [SerializeField] public double Blue_Damage;
    [SerializeField] public double Blue_Cadence;

    [SerializeField] public int XP;
    [SerializeField] public int TotalXP;

    public int HealthLvl = 1;
    public int GreedLvl = 1;
    
    public int Red_DamageLvl = 1;
    public int Red_CadenceLvl = 1;

    public int Blue_DamageLvl = 1;
    public int Blue_CadenceLvl = 1;

    public Sprite redSprite;
    public Sprite blueSprite;

    private SpriteRenderer spriteRenderer;

    [SerializeField] public GameObject damageSound;
    [SerializeField] public GameObject deathSound;

    [SerializeField] public GameObject DamageParticlePrefab;
    [SerializeField] public GameObject DeathParticlePrefab;

    [SerializeField]private DeathController deathController;

    public bool IsDeath = false;

    float healing = 20f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
        spriteRenderer = GetComponent<SpriteRenderer>();
        IsDeath = false;
    }

    void Update()
    {
        if (!IsDeath)
        {
            ProcessInputs();

            if (!canShoot && Time.time >= nextShoot)
            {
                canShoot = true;
            }

            if (weaponController.mode)
            {
                spriteRenderer.sprite = blueSprite;
            }
            else
            {
                spriteRenderer.sprite = redSprite;
            }
        }
    }

    //Fisicas Aqui
    void FixedUpdate()
    {
        Move();
        
        healing -= Time.deltaTime;
        if ( healing <= 0)
        {
            healing = 20f;
            if (Health + 1 < MaxHealth)
            {
                Health += 1;
            }
        }
    }

    //Movimiento
    void ProcessInputs()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        movementVector.Normalize();

        if(Input.GetMouseButton(0) && canShoot)
        {
            weaponController.Fire();
            canShoot = false;
            if(!weaponController.mode)
            {
                nextShoot = Time.time + 1 / Red_Cadence;
            }
            else
            {
                nextShoot = Time.time + 1 / Blue_Cadence;
            }
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
        if  (Time.time > nextDamage)
        {
            nextDamage = Time.time + invulnerability;
            Health--;
            Instantiate(damageSound);
            Instantiate(DamageParticlePrefab, transform.position, Quaternion.identity);
            if (Health <= 0)
            {
                Muerto();
            }
            healing = 20f;
        }
        
    }
    //morirse
    void Muerto()
    {
        Instantiate(deathSound);
        Instantiate(DeathParticlePrefab, transform.position, Quaternion.identity);
        IsDeath = true;
        deathController.Death();
        deathController.SetDeathStats();
        spriteRenderer.gameObject.SetActive(false);
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
                break;
            //Red_Damage
            case 2:
                Red_Damage = Red_Damage + Red_Damage * 0.2;
                Red_DamageLvl++;
                break;
            //Greed
            case 3:
                Greed = Greed + 0.3;
                GreedLvl++;
                break;
            //Red_Cadence
            case 4:
                Red_Cadence = Red_Cadence + Red_Cadence * 0.15;
                Red_CadenceLvl++;
                break;
            case 5:
                //cura
                Health = Mathf.Clamp(Health + Mathf.RoundToInt(MaxHealth * 0.2f), 0, MaxHealth);
                break;
            //Blue_Damage
            case 6:
                Blue_Damage = Blue_Damage + Blue_Damage * 0.2;
                Blue_DamageLvl++;
                break;
            //Blue_Cadence
            case 7:
                Blue_Cadence = Blue_Cadence + Blue_Cadence * 0.15;
                Blue_CadenceLvl++;
                break;
        }
    }
}
