using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Pools")]

    [SerializeField]
    MagmaPool magmaPool;

    [SerializeField]
    SmokePool smokePool;

    [SerializeField]
    MeteorPool meteorPool;

    [SerializeField]
    MeteorPool giantMeteorPool;

    [SerializeField]
    ParticlePool meteorDeathPool;

    [SerializeField]
    ParticlePool meteorDeathPoolLarge;

    [SerializeField]
    GroundPool groundPool;

    [SerializeField]
    AudioPool shakeSoundPool;

    [SerializeField]
    AudioPool hitSoundPool;

    [SerializeField]
    AudioPool meteorDeathSoundPool;

    [SerializeField]
    AudioPool groundHitSoundPool;

    [SerializeField]
    AudioPool magmaPickupPool;

    [Header("Spawn Parameters")]

    [SerializeField]
    Vector4 magmaSpawnBounds;

    [SerializeField]
    Vector2 magmaSpawnSecondsRange;

    [SerializeField]
    Vector2Int magmaSpawnCount;

    [SerializeField]
    Vector2Int meteorSpawnsRandom;

    [SerializeField]
    Vector2Int magmaSpawnsRandom;

    static GameManager _instance;

    public static GameManager Manager { get => _instance; }

    public UnityEvent<Magma> OnMagmaSpawn = new UnityEvent<Magma>();

    public UnityEvent<Vector3> OnMeteorDestroy = new UnityEvent<Vector3>();
    public UnityEvent<Vector3> OnMeteorDestroyLarge = new UnityEvent<Vector3>();

    public UnityEvent OnSpawnMeteor = new UnityEvent();

    public UnityEvent OnFillAnamoly = new UnityEvent();

    public UnityEvent OnMagmaAnamoly = new UnityEvent();

    public UnityEvent OnMeteorAnamoly = new UnityEvent();

    public UnityEvent OnAllAnamoly = new UnityEvent();

    public UnityEvent OnDeathAnamoly = new UnityEvent();

    public UnityEvent OnShakeSound = new UnityEvent();

    public UnityEvent OnHitSound = new UnityEvent();

    public UnityEvent OnMagmaPickup = new UnityEvent();

    public UnityEvent OnGroundHitSound = new UnityEvent();

    public UnityEvent OnMeteorDeathSound = new UnityEvent();

    public UnityEvent OnGroundHit = new UnityEvent();

    public UnityEvent OnGameOver = new UnityEvent();

    public UnityEvent OnDeductLife = new UnityEvent();

    public UnityEvent OnInstantDie = new UnityEvent();

    public UnityEvent<float> OnLifeRemaining = new UnityEvent<float>();

    public UnityEvent<AnamolySO> OnAnamolyChosen = new UnityEvent<AnamolySO>();

    float magmaSpawnTimeElapsed;

    float magmaSpawnTime;

    private void Awake()
    {
        _instance = this;

        OnMagmaSpawn.AddListener(smokePool.SpawnSmoke);
        OnSpawnMeteor.AddListener(SpawnMeteor);
        OnMeteorDestroy.AddListener(SpawnMeteorDeath);
        OnMeteorDestroyLarge.AddListener((vector) => meteorDeathPoolLarge.SpawnObject(vector));
        OnFillAnamoly.AddListener(DoFill);
        OnMagmaAnamoly.AddListener(SpawnMagmaRandom);
        OnAllAnamoly.AddListener(SpawnAll);
        OnDeathAnamoly.AddListener(SpawnDeath);
        OnMagmaPickup.AddListener(magmaPickupPool.SpawnObject);
        OnMeteorAnamoly.AddListener(SpawnMeteorRandom);
        OnHitSound.AddListener(hitSoundPool.SpawnObject);
        OnMeteorDeathSound.AddListener(meteorDeathSoundPool.SpawnObject);
        OnGroundHitSound.AddListener(groundHitSoundPool.SpawnObject);
        OnShakeSound.AddListener(shakeSoundPool.SpawnObject);
        OnGroundHit.AddListener(DoDamage);
    }

    private void Start()
    {
        SpawnMagma();
    }

    // Update is called once per frame
    void Update()
    {
        MagmaCheck();
    }

    void MagmaCheck()
    {
        magmaSpawnTimeElapsed += Time.deltaTime;
        if (magmaSpawnTimeElapsed >= magmaSpawnTime)
        {
            magmaSpawnTimeElapsed = 0;
            magmaSpawnTime = magmaSpawnSecondsRange.Random();
            SpawnMagma();
        }
    }

    private void SpawnMagma()
    {
        int count = magmaSpawnCount.Random();
        for (int i = 0; i < count; i++)
        {
            magmaPool.Spawn(magmaSpawnBounds.Random());
        }
    }

    private void SpawnMeteor()
    {
        meteorPool.SpawnObject();
    }

    private void SpawnMagmaRandom()
    {
        int count = magmaSpawnsRandom.Random();
        for (int i = 0; i < count; i++)
        {
            magmaPool.Spawn(magmaSpawnBounds.Random());
        }
    }

    private void SpawnMeteorRandom()
    {
        int count = meteorSpawnsRandom.Random();
        for(int i = 0; i < count; i++)
        {
            SpawnMeteor();
        }
    }

    private void DoFill()
    {
        groundPool.ResetAll();
    }

    private void SpawnMeteorDeath(Vector3 pos)
    {
        meteorDeathPool.SpawnObject(pos);
    }

    private void SpawnAll()
    {
        SpawnMagmaRandom();
        SpawnMeteorRandom();
        DoFill();
    }

    private void SpawnDeath()
    {
        giantMeteorPool.SpawnObject();
        SpawnMagmaRandom();
    }

    private void DoDamage()
    {
        OnGroundHitSound.Invoke();
    }
}
