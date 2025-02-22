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
    class ShopChangeUI : UIState
    {
        public UIPanel BrewerShopsPanel;
        public static bool visible = false;
        public static uint timeStart;
        public static string Shop = Brewer.SHOP_1;

        public override void OnInitialize()
        {
            BrewerShopsPanel = new();
            BrewerShopsPanel.SetPadding(0);
            BrewerShopsPanel.Left.Set(575f, 0f);
            BrewerShopsPanel.Top.Set(275f, 0f);
            BrewerShopsPanel.Width.Set(385f, 0f);
            BrewerShopsPanel.Height.Set(190f, 0f);
            BrewerShopsPanel.BackgroundColor = new(73, 94, 171);

            BrewerShopsPanel.OnLeftMouseDown += new(DragStart);
            BrewerShopsPanel.OnLeftMouseUp += new(DragEnd);

            UIText text = new("Vanilla");
            text.Left.Set(35, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(60, 0f);
            text.Height.Set(22, 0f);
            BrewerShopsPanel.Append(text);

            UIText text2 = new("Mod/Calamity");
            text2.Left.Set(35, 0f);
            text2.Top.Set(40, 0f);
            text2.Width.Set(120, 0f);
            text2.Height.Set(22, 0f);
            BrewerShopsPanel.Append(text2);

            UIText text21 = new("Thorium/RG/MoR");
            text21.Left.Set(35, 0f);
            text21.Top.Set(70, 0f);
            text21.Width.Set(100, 0f);
            text21.Height.Set(22, 0f);
            BrewerShopsPanel.Append(text21);

            UIText text3 = new("MorePotions/Atheria");
            text3.Left.Set(35, 0f);
            text3.Top.Set(100, 0f);
            text3.Width.Set(70, 0f);
            text3.Height.Set(22, 0f);
            BrewerShopsPanel.Append(text3);

            UIText text4 = new("UnuBattleRods/Tacklebox/Tremor");
            text4.Left.Set(35, 0f);
            text4.Top.Set(130, 0f);
            text4.Width.Set(150, 0f);
            text4.Height.Set(22, 0f);
            BrewerShopsPanel.Append(text4);

            UIText text5 = new("Wildlife/Sacred/Spirit/Cristilium/ExpSentr");
            text5.Left.Set(35, 0f);
            text5.Top.Set(160, 0f);
            text5.Width.Set(200, 0f);
            text5.Height.Set(22, 0f);
            BrewerShopsPanel.Append(text5);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonPlay");
            UIImageButton playButton = new(buttonPlayTexture);
            playButton.Left.Set(10, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            playButton.OnLeftClick += new MouseEvent(PlayButtonClicked1);
            BrewerShopsPanel.Append(playButton);
            UIImageButton playButton2 = new(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(40, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked2);
            BrewerShopsPanel.Append(playButton2);
            UIImageButton playButton21 = new(buttonPlayTexture);
            playButton21.Left.Set(10, 0f);
            playButton21.Top.Set(70, 0f);
            playButton21.Width.Set(22, 0f);
            playButton21.Height.Set(22, 0f);
            playButton21.OnLeftClick += new MouseEvent(PlayButtonClicked3);
            BrewerShopsPanel.Append(playButton21);
            UIImageButton playButton3 = new(buttonPlayTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(100, 0f);
            playButton3.Width.Set(22, 0f);
            playButton3.Height.Set(22, 0f);
            playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked4);
            BrewerShopsPanel.Append(playButton3);
            UIImageButton playButton4 = new(buttonPlayTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(130, 0f);
            playButton4.Width.Set(22, 0f);
            playButton4.Height.Set(22, 0f);
            playButton4.OnLeftClick += new MouseEvent(PlayButtonClicked5);
            BrewerShopsPanel.Append(playButton4);
            UIImageButton playButton5 = new(buttonPlayTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(160, 0f);
            playButton5.Width.Set(22, 0f);
            playButton5.Height.Set(22, 0f);
            playButton5.OnLeftClick += new MouseEvent(PlayButtonClicked6);
            BrewerShopsPanel.Append(playButton5);

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("Terraria/Images/UI/ButtonDelete");
            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(350, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            BrewerShopsPanel.Append(closeButton);
            Append(BrewerShopsPanel);
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shop1 = true;
                Brewer.Shop2 = false;
                Brewer.Shop3 = false;
                Brewer.Shop4 = false;
                Brewer.Shop5 = false;
                Brewer.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_1, ref visible);
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shop1 = false;
                Brewer.Shop2 = true;
                Brewer.Shop3 = false;
                Brewer.Shop4 = false;
                Brewer.Shop5 = false;
                Brewer.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_2, ref visible);
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shop1 = false;
                Brewer.Shop2 = false;
                Brewer.Shop3 = true;
                Brewer.Shop4 = false;
                Brewer.Shop5 = false;
                Brewer.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_3, ref visible);
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shop1 = false;
                Brewer.Shop2 = false;
                Brewer.Shop3 = false;
                Brewer.Shop4 = true;
                Brewer.Shop5 = false;
                Brewer.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_4, ref visible);
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shop1 = false;
                Brewer.Shop2 = false;
                Brewer.Shop3 = false;
                Brewer.Shop4 = false;
                Brewer.Shop5 = true;
                Brewer.Shop6 = false;
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_5, ref visible);
            }
        }

        private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shop1 = false;
                Brewer.Shop2 = false;
                Brewer.Shop3 = false;
                Brewer.Shop4 = false;
                Brewer.Shop5 = false;
                Brewer.Shop6 = true;
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_6, ref visible);
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
            offset = new Vector2(evt.MousePosition.X - BrewerShopsPanel.Left.Pixels, evt.MousePosition.Y - BrewerShopsPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            BrewerShopsPanel.Left.Set(end.X - offset.X, 0f);
            BrewerShopsPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (BrewerShopsPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                BrewerShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
                BrewerShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
