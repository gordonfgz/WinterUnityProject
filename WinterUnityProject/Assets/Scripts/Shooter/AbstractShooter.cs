using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractShooter : MonoBehaviour
{
    [Header("Settings")]
    public GameObject projectile;
    public float rate;
    public Transform firePoint;

    [Header("Tracking Settings")]
    public bool track = true;
    public float trackDistance = 5.0f;
    public float delayBetweenTracks = 2.0f;
    public GameObject rotationBase;

    [Header("Flip Settings")]
    public FlipOptions[] flipOptions;
    private FlipController flipControls;

    [Header("Lock Angle Settings")]
    public LockAngles lockA;
    private LockAngleController lockController;

    protected bool shooting = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", rate, rate + delayBetweenTracks);
        player = GameObject.FindWithTag("Player");
        flipControls = FindObjectOfType<FlipController>();
        lockController = FindObjectOfType<LockAngleController>(); ;
    }

    void FixedUpdate()
    {
        if (track)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if(distanceToPlayer < trackDistance)
            {
                if (!shooting && rotationBase)
                {
                    float rotationZ = CalculateZRotation();

                    if (lockA.maxAngle != 999 || lockA.minAngle != 999)
                        rotationZ = lockController.LockAngle(rotationZ, lockA);

                    rotationBase.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

                    if (flipOptions.Length != 0)
                    {
                        foreach (FlipOptions flip in flipOptions)
                        {
                            flipControls.ConditionalFlip(rotationZ, flip);
                        }
                    }
                }
            }            
        }
    }
    protected void Fire()
    {
        StartCoroutine(Shoot());
    }

    protected abstract IEnumerator Shoot();
    
    protected void Shooting()
    {
        shooting = true;
    }

    protected void NotShooting()
    {
        shooting = false;
    }

    private float CalculateZRotation()
    {
        Vector3 difference = transform.position - player.transform.position;
        difference.Normalize();
       return Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    }
}
