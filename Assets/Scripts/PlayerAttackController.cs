using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    // public Camera cam;
    public GameObject prefabCom1, prefabCom2, prefabCom3;
    public Transform LHFirePoint, RHFirePoint;
    public float projectileSpeed = 30;
    public int noOfClicks = 0;
    public float cooldownTime = 2f;
    private Animator _anim;
    private float _nextFireTime = 0f;
    private float _lastClickedTime = 0;
    private float _maxComboDelay = 1;
    // private Vector3 destination;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
        {
            _anim.SetBool("Hit1", false);
        }
        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            _anim.SetBool("Hit2", false);
        }
        if (_anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit3"))
        {
            _anim.SetBool("Hit3", false);
            noOfClicks = 0;
        }


        if (Time.time - _lastClickedTime > _maxComboDelay)
        {
            noOfClicks = 0;
        }

        //cooldown time
        if (Time.time > _nextFireTime)
        {
            // Check for mouse input
            if (_anim.GetBool("Grounded") && Input.GetMouseButtonDown(0))
            {
                OnClick();

            }
        }
    }

    void OnClick()
    {
        //so it looks at how many clicks have been made and if one animation has finished playing starts another one.
        _lastClickedTime = Time.time;
        noOfClicks++;
        if (noOfClicks == 1)
        {
            _anim.SetBool("Hit1", true);
            // ShootProjectile();
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
        {
            _anim.SetBool("Hit1", false);
            _anim.SetBool("Hit2", true);
            // ShootProjectile();
        }
        if (noOfClicks >= 3 && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            _anim.SetBool("Hit2", false);
            _anim.SetBool("Hit3", true);
            // ShootProjectile();
        }
    }
    public void ShootCom1()
    {
        // Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        // RaycastHit hit;
        // if (Physics.Raycast(ray, out hit))
        //     destination = hit.point;
        // else
        //     destination = ray.GetPoint(1000);
        // InstantiateProjectile(LHFirePoint);
        GameObject projectileObj1 = Instantiate(prefabCom1, LHFirePoint.position, transform.rotation);
    }
    public void ShootCom2()
    {
        GameObject projectileObj2 = Instantiate(prefabCom2, LHFirePoint.position, transform.rotation);
    }
    public void ShootCom3()
    {
        GameObject projectileObj3 = Instantiate(prefabCom3, LHFirePoint.position, transform.rotation);
    }
    // public void InstantiateProjectile(Transform firepoint)
    // {
    // GameObject projectileObj = Instantiate(projectile, firepoint.position, Quaternion.identity) as GameObject;
    // GameObject projectileObj = Instantiate(prefabCom1, firepoint.position, transform.rotation);
    // projectileObj.GetComponent<Rigidbody>().velocity = (destination - firepoint.position).normalized * projectileSpeed;
    // projectileObj.GetComponent<Rigidbody>().AddForce(transform.forward * 15f, ForceMode.Impulse);
    // }
}
