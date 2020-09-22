using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.FG.NPC.HealthBar
{
    public class HealthBar : MonoBehaviour {

        private Transform _bar;
        private SpriteRenderer _barSprite;
        public List<Color> healthBarColor;
        private void Awake ()
        {
            _bar = transform.GetChild(2);
            _barSprite = _bar.transform.GetChild(0).GetComponent<SpriteRenderer>();
        }

        public void SetSize(float healthNormalized)
        {
            _bar.localScale = new Vector3(healthNormalized, 1f);
        }

        public void SetColor(float health)
        {

            if (health < 30)
            {
                _barSprite.color = healthBarColor[2];
            }else if (health < 60)
            {
                _barSprite.color = healthBarColor[1];
            }
            else
            {
                _barSprite.color = healthBarColor[0];
            }
        }


        public void UpdateHealthUI()
            {
            
            }
        
        
    }
}
