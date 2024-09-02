using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TankController: MonoBehaviour
{
    public GameObject tank;
    public PlayerInput playerInput;
    private InputAction Movement;
    private InputAction Shoot;
    public GameObject tankbulletPrefab;
    public AudioClip tankShoot;
    public GameObject explosion;

    public Rigidbody2D tankrb;

    private bool isMovement;
    private float MoveDirection;
    public float Power;
    private bool isShooting;
    private bool hasShot;

    void Start()
    {
        playerInput.currentActionMap.Enable();

        Movement = playerInput.currentActionMap.FindAction("Movement");
        Movement.started += Movement_started;
        Movement.canceled += Movement_canceled;

        Shoot = playerInput.currentActionMap.FindAction("Shoot");
        Shoot.started += Shoot_started;
        Shoot.canceled += Shoot_canceled;
    }

    private void OnDestroy()
    {
        Movement.started -= Movement_started;
        Movement.canceled -= Movement_canceled;
        Shoot.started -= Shoot_started;
        Shoot.canceled -= Shoot_canceled;
    }

    private void Movement_started(InputAction.CallbackContext obj)
    {
        isMovement = true;
    }

    private void Movement_canceled(InputAction.CallbackContext obj)
    {
        isMovement = false;
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
        isShooting = true;
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        isShooting = false;
    }

    void Update()
    {
        if (isShooting)
        {
            if (hasShot == false)
            {
                Fire();
            }
        }

        if (!isMovement)
        {
            tankrb.velocity = Vector3.zero;
        }

        if (isMovement)
        {
            tank.GetComponent<Rigidbody2D>().velocity = new Vector2(tankrb.velocity.x, Power * MoveDirection);
        }

        if (isMovement)
        {
            MoveDirection = Movement.ReadValue<float>();
        }
    }

    void Fire()
    {
        GameObject new_bullet = Instantiate(tankbulletPrefab, transform.position + new Vector3 (0.7f,0), Quaternion.identity);
        explosion.gameObject.SetActive(true);
        new_bullet.transform.right = transform.right.normalized;
        AudioSource.PlayClipAtPoint(tankShoot, transform.position);
        hasShot = true;
        StartCoroutine(Wait(0.5f));
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSeconds(0.5f);
        explosion.gameObject.SetActive(false);
        yield return new WaitForSeconds(duration);
        hasShot = false;
    }
}
