using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangerColor : MonoBehaviour
{
    [SerializeField]
    List<SpriteRenderer> sprites = new List<SpriteRenderer>();

    List<Color> colorsAlly = new List<Color>() {Color.magenta,Color.blue, Color.cyan }; 
    List<Color> colorsEnemy = new List<Color>() { Color.yellow, Color.red}; 

    Life life;
    Status status;
    bool activ = false;
    void Start()
    {
        life = GetComponent<Life>();
        if (life != null)
        {
            status = life.status;
            activ = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ColorChange();
    }

    void ColorChange()
    {
        if (activ)
        {
            Color color = CreateColor(status);
            foreach (SpriteRenderer sprite in sprites)
            {
                if (sprite != null)sprite.color = color;
            }
        }
        
    }

    Color CreateColor(Status status)
    {
        Color color = new Color();
        float max = life.maxHP;
        float hpPart = life.HP / max * 100;
        if (status == Status.Ally)
        {
            Debug.Log(hpPart);
            if (hpPart <= 50)
            {
                Color from = colorsAlly[0];
                Color to = colorsAlly[1];
                color = new Color(Mathf.Lerp(from.r, to.r, hpPart / 50), Mathf.Lerp(from.g, to.g, hpPart / 50), Mathf.Lerp(from.b, to.b, hpPart / 50));
            }
            else
            {
                hpPart -= 50;
                Color from = colorsAlly[1];
                Color to = colorsAlly[2];
                color = new Color(Mathf.Lerp(from.r, to.r, hpPart / 50), Mathf.Lerp(from.g, to.g, hpPart / 50), Mathf.Lerp(from.b, to.b, hpPart / 50));
            }

        }
        else
        {
            Color from = colorsEnemy[0];
            Color to = colorsEnemy[1];
            color = new Color(Mathf.Lerp(from.r, to.r, hpPart / 100), Mathf.Lerp(from.g, to.g, hpPart / 100), Mathf.Lerp(from.b, to.b, hpPart / 100));
        }
        return color;
    }

}
