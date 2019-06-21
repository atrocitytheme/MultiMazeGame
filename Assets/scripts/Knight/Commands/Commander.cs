using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Commands
{
    public abstract class Commander
    {
        // Start is called before the first frame update
        protected Animator anime;
        protected CharacterController controller;
        protected Transform gameObjSpace;

        protected static float speed = 10;
        protected static float rotSpeed = 4;
        protected static float gravity = 4;
        protected static float rotation = 0;

        public Commander(Animator anime, CharacterController controller, Transform gameObj) {
            this.anime = anime;
            this.controller = controller;
            this.gameObjSpace = gameObj;

        }

        public abstract void Run();

        public void Cancel() {
            anime.SetInteger("condition", 0);
        }
    }
}
