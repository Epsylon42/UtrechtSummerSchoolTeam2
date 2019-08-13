using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToFaceTarget : MonoBehaviour
{
    public float MaxAngularVelocity;

    // Update is called once per frame
    void Update()
    {
        var targetPos =
            GetComponent<Targeting>()
            .Target
            .GetComponent<Transform>()
            .position;

        var body = GetComponent<Rigidbody>();
        var tf = GetComponent<Transform>();

        var angleDiff = Vector3.SignedAngle(
            tf.forward,
            targetPos - tf.position,
            Vector3.up
            );

        var angularVelocity = body.angularVelocity;
        angularVelocity.y = Mathf.Sign(angleDiff) * Mathf.Lerp(0, MaxAngularVelocity, Mathf.Abs(angleDiff));
        body.angularVelocity = angularVelocity;
    }
}
