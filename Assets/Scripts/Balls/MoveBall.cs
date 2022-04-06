using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Vector3 velocity;
    float sides = 30.0f;
    float speedMax = 0.3f;
    private static readonly int Color1 = Shader.PropertyToID("_Color");
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        velocity = new Vector3(Random.Range(0.0f, speedMax),
                        Random.Range(0.0f, speedMax),
                        Random.Range(0.0f, speedMax));

    }

    Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);
        var position = transform.position;

        var posX = position.x;
        var posY = position.y;
        var posZ = position.z;

        if (posX > sides || posX < -sides)
        {
            velocity.x = -velocity.x;
        }
        
        if (posY > sides || posY < -sides)
        {
            velocity.y = -velocity.y;
        }
        
        if (posZ > sides || posZ < -sides)
        {
            velocity.z = -velocity.z;
        }
        
        rend.material.SetColor(Color1, new Color(position.x/sides, position.y/sides, position.z/sides));

    }
}
