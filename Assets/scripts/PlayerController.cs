using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject circlePrefab;
    public float projectileSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horMove = Input.GetKey("d") ? 1 : Input.GetKey("a") ? -1 : 0;
        float verMove = Input.GetKey("w") ? 1 : Input.GetKey("s") ? -1 : 0;

        Vector3 moveDir = new Vector3(horMove, verMove, 0).normalized;
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            shootProjectile();
        }
    }

    void shootProjectile()
    {
        GameObject circleObject = Instantiate(circlePrefab, transform.position, Quaternion.identity);

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;

        //Vector3 projectileDir = (mouseWorldPos - transform.position).normalized;
        Vector2 shootDirection = new Vector2(mouseWorldPos.x - transform.position.x, mouseWorldPos.y - transform.position.y).normalized;

        circleObject.GetComponent<Rigidbody2D>().velocity = shootDirection * projectileSpeed;
    }
}
