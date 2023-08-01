using AlchemistNPCLite.NPCs;
using AlchemistNPCLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace AlchemistNPCLite.Interface
{
    class ShopChangeUIO : UIState
    {
        public UIPanel OperatorShopsPanel;
        public static bool visible = false;
        public static uint timeStart;
        public static string Shop = Operator.MaterialShop;

        public override void OnInitialize()
        {
            OperatorShopsPanel = new UIPanel();
            OperatorShopsPanel.SetPadding(0);
            OperatorShopsPanel.Left.Set(575f, 0f);
            OperatorShopsPanel.Top.Set(275f, 0f);
            OperatorShopsPanel.Width.Set(300f, 0f);
            OperatorShopsPanel.Height.Set(190f, 0f);
            OperatorShopsPanel.BackgroundColor = new Color(73, 94, 171);

            OperatorShopsPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            OperatorShopsPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIText text = new("Vanilla Materials/Boss Drops");
            text.Left.Set(35, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(90, 0f);
            text.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text);

            UIText text1 = new("Modded Materials/Boss Drops");
            text1.Left.Set(35, 0f);
            text1.Top.Set(40, 0f);
            text1.Width.Set(90, 0f);
            text1.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text1);

            UIText text2 = new("Vanilla Treasure Bags");
            text2.Left.Set(35, 0f);
            text2.Top.Set(70, 0f);
            text2.Width.Set(70, 0f);
            text2.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text2);

            UIText text3 = new("Modded Treasure Bags #1");
            text3.Left.Set(35, 0f);
            text3.Top.Set(100, 0f);
            text3.Width.Set(120, 0f);
            text3.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text3);

            UIText text4 = new("Modded Treasure Bags #2");
            text4.Left.Set(35, 0f);
            text4.Top.Set(130, 0f);
            text4.Width.Set(120, 0f);
            text4.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text4);

            UIText text5 = new("Modded Treasure Bags #3");
            text5.Left.Set(35, 0f);
            text5.Top.Set(160, 0f);
            text5.Width.Set(120, 0f);
            text5.Height.Set(22, 0f);
            OperatorShopsPanel.Append(text5);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            UIImageButton playButton = new(buttonPlayTexture);
            playButton.Left.Set(10, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            playButton.OnLeftClick += new(PlayButtonClicked1);
            OperatorShopsPanel.Append(playButton);
            UIImageButton playButton1 = new(buttonPlayTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(40, 0f);
            playButton1.Width.Set(22, 0f);
            playButton1.Height.Set(22, 0f);
            playButton1.OnLeftClick += new(PlayButtonClicked2);
            OperatorShopsPanel.Append(playButton1);
            UIImageButton playButton2 = new(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(70, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnLeftClick += new(PlayButtonClicked3);
            OperatorShopsPanel.Append(playButton2);
            UIImageButton playButton3 = new(buttonPlayTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(100, 0f);
            playButton3.Width.Set(22, 0f);
            playButton3.Height.Set(22, 0f);
            playButton3.OnLeftClick += new(PlayButtonClicked4);
            OperatorShopsPanel.Append(playButton3);
            UIImageButton playButton4 = new(buttonPlayTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(130, 0f);
            playButton4.Width.Set(22, 0f);
            playButton4.Height.Set(22, 0f);
            playButton4.OnLeftClick += new(PlayButtonClicked5);
            OperatorShopsPanel.Append(playButton4);
            UIImageButton playButton5 = new(buttonPlayTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(160, 0f);
            playButton5.Width.Set(22, 0f);
            playButton5.Height.Set(22, 0f);
            playButton5.OnLeftClick += new(PlayButtonClicked6);
            OperatorShopsPanel.Append(playButton5);

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(270, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new(CloseButtonClicked);
            OperatorShopsPanel.Append(closeButton);
            base.Append(OperatorShopsPanel);
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = true;
                Operator.Shop2 = false;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Operator.MaterialShop, ref visible);
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = true;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Operator.ModMaterialShop, ref visible);
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.Shop3 = true;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Operator.VanillaBagsShop, ref visible);
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.Shop3 = false;
                Operator.Shop4 = true;
                Operator.Shop5 = false;
                Operator.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Operator.Bags1Shop, ref visible);
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = true;
                Operator.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Operator.Bags2Shop, ref visible);
            }
        }

        private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Operator.Shop1 = false;
                Operator.Shop2 = false;
                Operator.Shop3 = false;
                Operator.Shop4 = false;
                Operator.Shop5 = false;
                Operator.Shop6 = true;
                AlchemistHelper.OpenShop(ref Shop, Operator.Bags3Shop, ref visible);
            }
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                visible = false;
            }
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - OperatorShopsPanel.Left.Pixels, evt.MousePosition.Y - OperatorShopsPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            OperatorShopsPanel.Left.Set(end.X - offset.X, 0f);
            OperatorShopsPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (OperatorShopsPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                OperatorShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
                OperatorShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
