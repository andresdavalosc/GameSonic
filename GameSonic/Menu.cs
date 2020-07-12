using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace GameSonic
{
    public class Menu
    {
        public event EventHandler onMenuChange;
        public string Axis;
        public string Effects;
        [XmlElement("Item")]
        public List<MenuItem> Items;
        int itemNumber;
        string id;

        public int ItemNumber
        {
            get { return itemNumber; }
        }

        public void Transistion(float alpa)
        {
            foreach (MenuItem item in Items)
            {
                item.Image.IsActive = true;
                item.Image.Alpha = alpa;
                if (alpa == 0.0f)
                    item.Image.FadeEffect.Increase = true;
                else
                    item.Image.FadeEffect.Increase = false;
            }
        }

        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                onMenuChange(this, null);
            }
        }

        void AlignMenuItems()
        {
            Vector2 dimensions = Vector2.Zero;
            foreach (MenuItem item in Items)
                dimensions += new Vector2(item.Image.SourceRect.Width, item.Image.SourceRect.Height);

            dimensions = new Vector2((ScreenManager.Instance.Dimensions.X - dimensions.X) / 2, (ScreenManager.Instance.Dimensions.Y - dimensions.Y) / 2);
            foreach (MenuItem item in Items)
            {
                if (Axis == "X")
                {
                    item.Image.Position = new Vector2(dimensions.X, (ScreenManager.Instance.Dimensions.Y - item.Image.SourceRect.Height) / 2);
                }
                else if (Axis == "Y")
                {
                    item.Image.Position = new Vector2((ScreenManager.Instance.Dimensions.X - item.Image.SourceRect.Width) / 2, dimensions.Y);
                    dimensions += new Vector2(item.Image.SourceRect.Width, item.Image.SourceRect.Height);

                }
                dimensions += new Vector2(item.Image.SourceRect.Width, item.Image.SourceRect.Height);

            }

        }

        public Menu()
        {
            id = string.Empty;
            itemNumber = 0;
            Effects = string.Empty;
            Axis = "Y";
            Items = new List<MenuItem>();
        }
        public void LoadContent()
        {
            string[] split = Effects.Split(':');
            foreach (MenuItem item in Items)
            {
                item.Image.LoadContent();
                foreach (string s in split)
                {
                    item.Image.ActivateEffect(s);

                }
            }
            AlignMenuItems();

        }

        public void UnloadContent()
        {
            foreach (MenuItem item in Items)
            {
                item.Image.UnloadContent();
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Axis == "X")
            {
                if (InputManager.Instance.KeyPressed(Keys.Right))
                    itemNumber++;
                else if (InputManager.Instance.KeyPressed(Keys.Left))
                    itemNumber--;
            }
            else if (Axis == "Y")
            {
                if (InputManager.Instance.KeyPressed(Keys.Down))
                    itemNumber++;
                else if (InputManager.Instance.KeyPressed(Keys.Up))
                    itemNumber--;
            }
            if (itemNumber < 0)
            {
                itemNumber = 0;
            }
            else if (itemNumber > Items.Count - 1)
            {
                itemNumber = Items.Count - 1;
            }
            for (int i = 0; i < Items.Count; i++)
            {
                if (i == itemNumber)
                {
                    Items[i].Image.IsActive = true;
                }
                else
                {
                    Items[i].Image.IsActive = false;

                }
                Items[i].Image.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem item in Items)
            {
                item.Image.Draw(spriteBatch);
            }
        }
    }
}
