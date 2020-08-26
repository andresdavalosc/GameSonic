using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSonic
{
    public class MenuManager
    {
        Menu menu;
        public static bool start = false;
        bool isTransistioning;

        void Transisition(GameTime gameTime)
        {
            if (isTransistioning)
            {
                
                for (int i = 0; i < menu.Items.Count; i++)
                {
                    menu.Items[i].Image.Update(gameTime);
                    float first = menu.Items[0].Image.Alpha;
                    float last = menu.Items[menu.Items.Count - 1].Image.Alpha;
                    if (first == 0.0f && last == 0.0f)
                    {
                        menu.ID = menu.Items[menu.ItemNumber].LinkID;
                    }
                    else if (first == 1.0f && last == 1.0f)
                    {
                        isTransistioning = false;
                        foreach (MenuItem item in menu.Items)
                        {
                            item.Image.RestoreEffects();
                        }
                    }
                }
            }
        }
        public MenuManager()
        {
            menu = new Menu();
            menu.onMenuChange += menu_OnMenuChange;
        }

        void menu_OnMenuChange(object sender, EventArgs e)
        {
            XmlManager<Menu> xmlMenuManager = new XmlManager<Menu>();
            menu.UnloadContent();
            menu = xmlMenuManager.Load(menu.ID);
            menu.LoadContent();
            menu.onMenuChange += menu_OnMenuChange;
            menu.Transistion(0.0f);
            foreach (MenuItem item in menu.Items)
            {
                item.Image.StoreEffects();
            }
        }
        public void LoadContent(string MenuPath)
        {
            if (MenuPath != string.Empty)
                menu.ID = MenuPath;
        }

        public void UnloadContent()
        {
            menu.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            if(!isTransistioning)
                menu.Update(gameTime);
            if(InputManager.Instance.KeyPressed(Keys.Enter) && !isTransistioning)
            {
                if(menu.Items[menu.ItemNumber].LinkType == "Screen")
                {
                    start = true;
                    Console.WriteLine(start);
                    ScreenManager.Instance.ChangeScreens(menu.Items[menu.ItemNumber].LinkID);
                }
                else
                {
                    isTransistioning = true;
                    menu.Transistion(1.0f);
                    foreach (MenuItem item in menu.Items)
                    {
                        item.Image.StoreEffects();
                        item.Image.ActivateEffect("FadeEffect");
                    }
                }
            }
            Transisition(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            menu.Draw(spriteBatch);

        }
    }
}
