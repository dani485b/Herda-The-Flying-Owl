﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFlying : MonoBehaviour {
    Rigidbody rb;
    private static MovementFlying _instance;
    public static MovementFlying Instance { get { return _instance; } }


    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
            foreach (var item in FindSceneObjectsOfType(typeof(compasTarget))) {
                ((compasTarget)item).SetRdyFlag(true);
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        rb.velocity = Physics.gravity;
        if (Input.GetKey(KeyCode.Space)) {
            rb.velocity += transform.forward * 50f + transform.up * 25f;
        }
    }
}