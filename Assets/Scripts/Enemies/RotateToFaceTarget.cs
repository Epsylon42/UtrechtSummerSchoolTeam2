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

        var body = GetComponent<Rigidbody2D>();
        var tf = GetComponent<Transform>();

        var angleDiff = Vector2.SignedAngle(tf.right, targetPos - tf.position);

        body.angularVelocity = Mathf.Sign(angleDiff) * Mathf.Lerp(0, MaxAngularVelocity, Mathf.Abs(angleDiff) / 180);
    }
}
