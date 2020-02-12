using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{
    public GameObject[] balls;
    public float speed;
    public float speedY;

    public float distanceXZ;
    public float distanceY;
    private float[] waveAngle  = {0f, 0f, 0f};
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach(GameObject b in balls) {
            float angle = Random.Range(0, 360);
            b.transform.localPosition = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            waveAngle[i] = Mathf.Sin(Random.Range(0, 180));
            i++;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        transform.Rotate(0f, time * 3 * speed, 0f);


        int i = 0;
        foreach(GameObject b in balls) {
            waveAngle[i] += time * speedY;
            Vector3 temp = b.transform.localPosition;
            temp.y = Mathf.Sin(waveAngle[i]) * distanceY;
            b.transform.localPosition = temp;
            i++;
        } 
    }
}
