using Scripts.Service.Input;
using UnityEngine;

namespace Assets.Scripts
{
    public class Game :MonoBehaviour
    {
        public static IInputService InputService;

        public Game()
        {
            if (Application.isEditor)
                InputService = new StandaloneInputService();
            else
                InputService = new MobileInputService();
        }
    }
}
