using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public ParticleSystem particle;

    void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }
    
    public void ResetPosition(Vector3 position)
    {
        transform.position = position;
        particle.Play();
        Invoke("SetDisable", 3f);
    }

    private void SetDisable()
    {
        gameObject.SetActive(false);
    }
}
