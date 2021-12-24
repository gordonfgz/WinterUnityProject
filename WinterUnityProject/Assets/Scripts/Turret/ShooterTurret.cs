using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterTurret : AbstractTurret
{
    public AbstractShoot shootBehaviour;

    [Header("Tracking Settings")]
    public bool track = true;
    public float trackingSpeed = 15.0f;
    public float delayBetweenTracks = 2.0f;
    public GameObject rotationBase;

    [Header("Flip Settings")]
    public FlipOptions[] flipOptions;
    private FlipController flipControls;

    [Header("Lock Angle Settings")]
    public LockAngles lockA;
    private LockAngleController lockController;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        if (!shootBehaviour)
            base.attackRate += shootBehaviour.shoot.delayBetweenShots;

        flipControls = FindObjectOfType<FlipController>();
        lockController = FindObjectOfType<LockAngleController>(); ;
    }

    void Update()
    {
        if (track)
        {
            if (!shootBehaviour.shooting && rotationBase && base.aggroed)
            {
                TrackPlayer();
            }
        }

        base.Update();
    }

    protected override void Idle()
    {
        Debug.Log("Idling");
    }

    protected override void Aggro()
    {
        Debug.Log("Aggroed");

        if (!shootBehaviour)
        {
            Debug.Log("No shoot script attached");
            return;
        }

        StartCoroutine(shootBehaviour.Shoot());
    }

    private void TrackPlayer()
    {
        float rotationZ = CalculateZRotation();
        float appliedRotationZ = rotationZ;

        if (lockA.maxAngle != 999 || lockA.minAngle != 999)
            appliedRotationZ = lockController.LockAngle(rotationZ, lockA);

        FlipObjects(rotationZ);

        Quaternion targetRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, appliedRotationZ);
        rotationBase.transform.rotation = Quaternion.RotateTowards(rotationBase.transform.rotation, targetRotation, trackingSpeed * Time.deltaTime);
    }

    private void FlipObjects(float angle)
    {
        if (flipOptions.Length != 0)
            foreach (FlipOptions flip in flipOptions)
                flipControls.ConditionalFlip(angle, flip);
    }

    private float CalculateZRotation()
    {
        Vector3 difference = transform.position - base.player.transform.position;
        difference.Normalize();
        return Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    }
}
