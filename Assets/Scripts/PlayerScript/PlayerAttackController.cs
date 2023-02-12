using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerAttackController : MonoBehaviour
{
    public bool attackAble = true;
    // public Camera cam;
    public float checkRadius;
    public LayerMask checkLayers;
    public GameObject fireCom1, fireCom2, fireCom3, waterCom1, waterCom2, waterCom3, windCom1, windCom2, windCom3;
    public Transform LHFirePoint, RHFirePoint;
    public float projectileSpeed = 30;
    public int noOfClicks = 0;
    public float cooldownTime = 2f;
    private Image imageElement;
    public Sprite spriteElementF;
    public Sprite spriteElementWt;
    public Sprite spriteElementW;

    private Animator _anim;
    private float _nextFireTime = 0f;
    private float _lastClickedTime = 0;
    private float _maxComboDelay = 1;
    // private Vector3 destination;

    private int element = 0;
    enum Element
    {
        Fire,
        Water,
        Wind
    }
    private void Start()
    {
        _anim = GetComponent<Animator>();
        imageElement = CanvasManager.instance.GetCanvasObject("Panel").transform.Find("Bar").Find("Image").Find("Element").GetComponent<Image>();
        spriteElementF = Resources.Load<Sprite>("f");
        spriteElementWt = Resources.Load<Sprite>("wt");
        spriteElementW = Resources.Load<Sprite>("w");
    }
    void Update()
    {
        // Debug.Log("Elemt" + (Element)element);
        if (DialogueManager.dialogueIsPlaying)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (element == 0) element = 2;
            else element -= 1;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (element == 2) element = 0;
            else element += 1;
        }
        if(_anim.GetCurrentAnimatorStateInfo(0).IsTag("Skill")){
            return;
        }
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
            if (_anim.GetBool("Grounded") && InputManager.instance.GetAttackPressed() && attackAble)
            {
                FaceToClosestEnemy();
                OnClick();

            }
        }

        if (element == 0)
        {
            imageElement.sprite = spriteElementF;
        }
        else if (element == 1)
        {
            imageElement.sprite = spriteElementWt;
        }
        else
        {
            imageElement.sprite = spriteElementW;
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
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        if (noOfClicks >= 2 && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit1"))
        {
            _anim.SetBool("Hit1", false);
            _anim.SetBool("Hit2", true);
        }
        if (noOfClicks >= 3 && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f && _anim.GetCurrentAnimatorStateInfo(0).IsName("Hit2"))
        {
            _anim.SetBool("Hit2", false);
            _anim.SetBool("Hit3", true);
        }
        _anim.SetFloat("Speed", 0f);
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
        if (element == 0)
        {
            GameObject projectileObj1 = Instantiate(fireCom1, LHFirePoint.position, transform.rotation);

        }
        else if (element == 1)
        {
            GameObject projectileObj1 = Instantiate(waterCom1, LHFirePoint.position, transform.rotation);

        }
        else
        {
            GameObject projectileObj1 = Instantiate(windCom1, LHFirePoint.position, transform.rotation);

        }
    }
    public void ShootCom2()
    {
        if (element == 0)
        {
            GameObject projectileObj1 = Instantiate(fireCom2, LHFirePoint.position, transform.rotation);

        }
        else if (element == 1)
        {
            GameObject projectileObj1 = Instantiate(waterCom2, LHFirePoint.position, transform.rotation);

        }
        else
        {
            GameObject projectileObj1 = Instantiate(windCom2, LHFirePoint.position, transform.rotation);

        }
    }
    public void ShootCom3()
    {
        if (element == 0)
        {
            GameObject projectileObj1 = Instantiate(fireCom3, LHFirePoint.position, transform.rotation);

        }
        else if (element == 1)
        {
            GameObject projectileObj1 = Instantiate(waterCom3, LHFirePoint.position, transform.rotation);

        }
        else
        {
            GameObject projectileObj1 = Instantiate(windCom3, LHFirePoint.position, transform.rotation);

        }
    }
    public void FaceToClosestEnemy()
    {

        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));

        if (colliders.Length != 0)
        {
            transform.LookAt(colliders[0].transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
