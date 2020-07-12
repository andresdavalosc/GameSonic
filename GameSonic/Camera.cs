using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    class Camera
    {
        public Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }
        Viewport view;
        public static Vector2 centre;


        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void Update(Vector2 position, int i, int j)
        {
            //public void Update(Vector2 position, int i, int j)
            if (position.X < view.Width/2)
                centre.X = view.Width / 2;
            if (position.X > view.Width+i)
                centre.X = view.Width+i;
            else if (position.X > (view.Width / 2))
                centre = new Vector2(position.X, 0);
            transform = Matrix.CreateTranslation(new Vector3(-centre.X + (view.Width / 2), 0, 0));
        }
    }
}
