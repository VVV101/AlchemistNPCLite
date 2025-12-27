using AlchemistNPCLite.NPCs;
using AlchemistNPCLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.Localization;

namespace AlchemistNPCLite.Interface
{
    class ShopChangeUI : UIState
    {
        public UIPanel BrewerShopsPanel;
        public static bool visible = false;
        public static uint timeStart;
        public static string Shop = Brewer.SHOP_1;
		UIText text = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.ShopB1"));
		UIText text2 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.ShopB2"));
		UIText text3 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.ShopB3"));
		UIText text4 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.ShopB4"));
		UIText text5 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.ShopB5"));
		UIText text6 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.ShopB6"));

        public override void OnInitialize()
        {
            BrewerShopsPanel = new();
            BrewerShopsPanel.SetPadding(0);
            BrewerShopsPanel.Left.Set(575f, 0f);
            BrewerShopsPanel.Top.Set(275f, 0f);
            BrewerShopsPanel.Width.Set(385f, 0f);
            BrewerShopsPanel.Height.Set(190f, 0f);
            BrewerShopsPanel.BackgroundColor = new(49, 51, 117, 210);

            BrewerShopsPanel.OnLeftMouseDown += new(DragStart);
            BrewerShopsPanel.OnLeftMouseUp += new(DragEnd);

            text.Left.Set(35, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(60, 0f);
            text.Height.Set(22, 0f);
			text.TextColor = CheckColor(1);
            BrewerShopsPanel.Append(text);
            
            text2.Left.Set(35, 0f);
            text2.Top.Set(40, 0f);
            text2.Width.Set(120, 0f);
            text2.Height.Set(22, 0f);
			text2.TextColor = CheckColor(2);
            BrewerShopsPanel.Append(text2);

            text3.Left.Set(35, 0f);
            text3.Top.Set(70, 0f);
            text3.Width.Set(100, 0f);
            text3.Height.Set(22, 0f);
			text3.TextColor = CheckColor(3);
            BrewerShopsPanel.Append(text3);

            text4.Left.Set(35, 0f);
            text4.Top.Set(100, 0f);
            text4.Width.Set(70, 0f);
            text4.Height.Set(22, 0f);
			text4.TextColor = CheckColor(4);
            BrewerShopsPanel.Append(text4);

            text5.Left.Set(35, 0f);
            text5.Top.Set(130, 0f);
            text5.Width.Set(150, 0f);
            text5.Height.Set(22, 0f);
			text5.TextColor = CheckColor(5);
            BrewerShopsPanel.Append(text5);

            text6.Left.Set(35, 0f);
            text6.Top.Set(160, 0f);
            text6.Width.Set(72, 0f);
            text6.Height.Set(22, 0f);
			text6.TextColor = CheckColor(6);
            BrewerShopsPanel.Append(text6);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("AlchemistNPCLite/Interface/ButtonSet");
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
            UIImageButton playButton3 = new(buttonPlayTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(70, 0f);
            playButton3.Width.Set(22, 0f);
            playButton3.Height.Set(22, 0f);
            playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked3);
            BrewerShopsPanel.Append(playButton3);
            UIImageButton playButton4 = new(buttonPlayTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(100, 0f);
            playButton4.Width.Set(22, 0f);
            playButton4.Height.Set(22, 0f);
            playButton4.OnLeftClick += new MouseEvent(PlayButtonClicked4);
            BrewerShopsPanel.Append(playButton4);
            UIImageButton playButton5 = new(buttonPlayTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(130, 0f);
            playButton5.Width.Set(22, 0f);
            playButton5.Height.Set(22, 0f);
            playButton5.OnLeftClick += new MouseEvent(PlayButtonClicked5);
            BrewerShopsPanel.Append(playButton5);
            UIImageButton playButton6 = new(buttonPlayTexture);
            playButton6.Left.Set(10, 0f);
            playButton6.Top.Set(160, 0f);
            playButton6.Width.Set(22, 0f);
            playButton6.Height.Set(22, 0f);
            playButton6.OnLeftClick += new MouseEvent(PlayButtonClicked6);
            BrewerShopsPanel.Append(playButton6);

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("AlchemistNPCLite/Interface/ButtonClose");
            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(355, 0f);
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
                Brewer.Shops = 1;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_1, ref visible);
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shops = 2;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_2, ref visible);
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shops = 3;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_3, ref visible);
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
               Brewer.Shops = 4;
			   ReCheckColor();
               AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_4, ref visible);
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shops = 5;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Brewer.SHOP_5, ref visible);
            }
        }

        private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Brewer.Shops = 6;
				ReCheckColor();
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
		
		private Color CheckColor(int i)
		{
			if (Brewer.Shops == i) return Color.Lime;
			return Color.White;
		}
		
		private void ReCheckColor()
		{
			text.TextColor = CheckColor(1);
			text2.TextColor = CheckColor(2);
			text3.TextColor = CheckColor(3);
			text4.TextColor = CheckColor(4);
			text5.TextColor = CheckColor(5);
			text6.TextColor = CheckColor(6);
		}
    }
}
