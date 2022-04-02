using UnityEngine;

namespace ItemProperty
{
    public class ItemIcons : MonoBehaviour
    {
        public Sprite[] icons;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}