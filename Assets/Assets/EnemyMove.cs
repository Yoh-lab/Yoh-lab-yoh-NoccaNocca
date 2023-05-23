using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyMove : MonoBehaviour
{

	public float maxHP=100;
	public float HP;
	public Canvas canvas;
	public Text text;
	public Slider _slider;
	public float freq = 1f;
	public float charge =1f;
	public float firePower;
	GameObject bullet;
	public Rigidbody rb;
	public float rotateSpeed;
	public float speed;

    void Start()
    {
	HP = maxHP;        
    }


    void Update()
    {
        rb = GetComponent<Rigidbody>();
	_slider.value = HP;
	if(HP <= 0)
		{
		 Destroy(this.gameObject, 0.1f);
		}

	transform.Rotate(Vector3.down * Time.deltaTime*20*rotateSpeed, Space.World);	transform.Rotate(Vector3.down * Time.deltaTime*20*rotateSpeed, Space.World);
	transform.position += transform.forward * speed * Time.deltaTime*5;	
	charge -=0.1f * freq;
if(charge <= 0f){
		charge += 1f;
		bullet = GameObject.Find("Bullet");
		bullet = Instantiate (bullet, this.transform.position + new Vector3(0, 3, 0), bullet.transform.rotation);
		bullet.transform.parent = this.transform;
		bullet.transform.localScale = new Vector3 (0.3f, 0.3f, 0.3f);
	rb = bullet.GetComponent<Rigidbody>();
	 rb.AddForce(transform.forward * firePower);
	 bullet.transform.parent = null;
	 Destroy(bullet, 1.5f);	

	      }
    }

	void OnTriggerEnter(Collider collider)
	{
	 if(collider.gameObject.tag == "Bullet")
						{
	 					 HP -= 30f;
						}			 
			 		    					
	}
}
