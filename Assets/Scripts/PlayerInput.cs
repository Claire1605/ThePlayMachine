using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public GameObject wheelMesh;
    public GameObject handleMesh;
    public GameObject handleSprite;
    public GameObject leftHandSprite;
    public float leftHandSpeed = 1.0f;
    public float rotationScale = 1.0f;

    private float initialYOffset = 0;
    private float initialYHandle = 0;
    private float initialYHand = 0;
    private float yOffset = 0;
    private float zOffset = 0;
    private float initialZOffset = 0;
    private float initialHandleScale = 1.0f;
    private float initialLeftHandScale = 1.0f;

    private float inputY = 0;

	void Start () {
        initialYOffset = handleMesh.transform.position.y;
        initialZOffset = handleMesh.transform.position.z;
        initialYHandle = handleSprite.transform.position.y;
        initialYHand = leftHandSprite.transform.position.y;
        initialHandleScale = handleSprite.transform.localScale.x;
        initialLeftHandScale = leftHandSprite.transform.localScale.x;
    }
	

	void Update () {
        inputY = Input.GetAxis("Vertical");
        wheelMesh.transform.Rotate(0.0f, inputY * leftHandSpeed, 0.0f);

        yOffset = handleMesh.transform.position.y - initialYOffset;
        Vector3 handleSpriteNewPos = new Vector3(handleSprite.transform.position.x, initialYHandle + yOffset, handleSprite.transform.position.z);
        handleSprite.transform.position = handleSpriteNewPos;

        Vector3 leftHandSpriteNewPos = new Vector3(leftHandSprite.transform.position.x, initialYHand + yOffset, leftHandSprite.transform.position.z);
        leftHandSprite.transform.position = leftHandSpriteNewPos;

        zOffset = (handleMesh.transform.position.z - initialZOffset) / rotationScale;
        handleSprite.transform.localScale = Vector3.one * (initialHandleScale + zOffset);
        leftHandSprite.transform.localScale = Vector3.one * (initialLeftHandScale + zOffset);
    }
}
