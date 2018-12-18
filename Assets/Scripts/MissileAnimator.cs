﻿using UnityEngine;

public class MissileAnimator : MonoBehaviour {
    public Animator missileAnimator;
    public ThrustController thrustController;
    public CollisionBroadcaster collisionBroadcaster;
    public ParticleSystem exhaustParticles;
    public GameObject explode;
    // Start is called before the first frame update
    void Start() {
        collisionBroadcaster.OnCollision += Explode;
    }

    private void OnDisable() {
        collisionBroadcaster.OnCollision -= Explode;
    }

    // Update is called once per frame
    void Update() {
        missileAnimator.SetBool("isRightThrust",thrustController.IsRightThrust);
        missileAnimator.SetBool("isLeftThrust",thrustController.IsLeftThrust);
        missileAnimator.SetBool("isBoosting",thrustController.IsBoosting);
    }

    private void Explode(GameObject enemy) {
        Instantiate(explode, transform.position, Quaternion.identity);
        Destroy(gameObject);
        /*
        missileAnimator.SetTrigger("trigExplode");
        exhaustParticles.Stop();
        */
    }
}
