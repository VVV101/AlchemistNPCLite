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
using Terraria.Localization;

namespace AlchemistNPCLite.Interface
{
    class ShopChangeUIA : UIState
    {
        public UIPanel ArchitectShopsPanel;
        public static bool visible = false;
        public static uint timeStart;
        public static string Shop = Architect.Filler;
		UIText text = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS1"));
		UIText text2 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS2"));
		UIText text3 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS3"));
		UIText text4 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS4"));
		UIText text5 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS5"));
		UIText text6 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS6"));
		UIText text7 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS7"));
		UIText text8 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS8"));
		UIText text9 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS9"));
		UIText text10 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.AS10"));

        public override void OnInitialize()
        {
            ArchitectShopsPanel = new UIPanel();
            ArchitectShopsPanel.SetPadding(0);
            ArchitectShopsPanel.Left.Set(575f, 0f);
            ArchitectShopsPanel.Top.Set(275f, 0f);
            ArchitectShopsPanel.Width.Set(300f, 0f);
            ArchitectShopsPanel.Height.Set(310f, 0f);
            ArchitectShopsPanel.BackgroundColor = new Color(73, 94, 171);

            ArchitectShopsPanel.OnLeftMouseDown += new(DragStart);
            ArchitectShopsPanel.OnLeftMouseUp += new(DragEnd);

            text.Left.Set(35, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(70, 0f);
            text.Height.Set(22, 0f);
			text.TextColor = CheckColor(1);
            ArchitectShopsPanel.Append(text);

            text2.Left.Set(35, 0f);
            text2.Top.Set(40, 0f);
            text2.Width.Set(70, 0f);
            text2.Height.Set(22, 0f);
			text2.TextColor = CheckColor(2);
            ArchitectShopsPanel.Append(text2);

            text3.Left.Set(35, 0f);
            text3.Top.Set(70, 0f);
            text3.Width.Set(70, 0f);
            text3.Height.Set(22, 0f);
			text2.TextColor = CheckColor(3);
            ArchitectShopsPanel.Append(text3);

            text4.Left.Set(35, 0f);
            text4.Top.Set(100, 0f);
            text4.Width.Set(70, 0f);
            text4.Height.Set(22, 0f);
			text4.TextColor = CheckColor(4);
            ArchitectShopsPanel.Append(text4);

            text5.Left.Set(35, 0f);
            text5.Top.Set(130, 0f);
            text5.Width.Set(50, 0f);
            text5.Height.Set(22, 0f);
			text5.TextColor = CheckColor(5);
            ArchitectShopsPanel.Append(text5);

            text6.Left.Set(35, 0f);
            text6.Top.Set(160, 0f);
            text6.Width.Set(50, 0f);
            text6.Height.Set(22, 0f);
			text6.TextColor = CheckColor(6);
            ArchitectShopsPanel.Append(text6);

            text7.Left.Set(35, 0f);
            text7.Top.Set(190, 0f);
            text7.Width.Set(50, 0f);
            text7.Height.Set(22, 0f);
			text7.TextColor = CheckColor(7);
            ArchitectShopsPanel.Append(text7);

            text8.Left.Set(35, 0f);
            text8.Top.Set(220, 0f);
            text8.Width.Set(60, 0f);
            text8.Height.Set(22, 0f);
			text8.TextColor = CheckColor(8);
            ArchitectShopsPanel.Append(text8);

            text9.Left.Set(35, 0f);
            text9.Top.Set(250, 0f);
            text9.Width.Set(70, 0f);
            text9.Height.Set(22, 0f);
			text9.TextColor = CheckColor(9);
            ArchitectShopsPanel.Append(text9);

            text10.Left.Set(35, 0f);
            text10.Top.Set(280, 0f);
            text10.Width.Set(70, 0f);
            text10.Height.Set(22, 0f);
			text10.TextColor = CheckColor(10);
            ArchitectShopsPanel.Append(text10);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("AlchemistNPCLite/Interface/ButtonSet");
            UIImageButton playButton = new(buttonPlayTexture);
            playButton.Left.Set(10, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            playButton.OnLeftClick += new(PlayButtonClicked1);
            ArchitectShopsPanel.Append(playButton);
            UIImageButton playButton2 = new(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(40, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnLeftClick += new(PlayButtonClicked2);
            ArchitectShopsPanel.Append(playButton2);
            UIImageButton playButton3 = new(buttonPlayTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(70, 0f);
            playButton3.Width.Set(22, 0f);
            playButton3.Height.Set(22, 0f);
            playButton3.OnLeftClick += new(PlayButtonClicked3);
            ArchitectShopsPanel.Append(playButton3);
            UIImageButton playButton4 = new(buttonPlayTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(100, 0f);
            playButton4.Width.Set(22, 0f);
            playButton4.Height.Set(22, 0f);
            playButton4.OnLeftClick += new(PlayButtonClicked4);
            ArchitectShopsPanel.Append(playButton4);
            UIImageButton playButton5 = new(buttonPlayTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(130, 0f);
            playButton5.Width.Set(22, 0f);
            playButton5.Height.Set(22, 0f);
            playButton5.OnLeftClick += new(PlayButtonClicked5);
            ArchitectShopsPanel.Append(playButton5);
            UIImageButton playButton6 = new(buttonPlayTexture);
            playButton6.Left.Set(10, 0f);
            playButton6.Top.Set(160, 0f);
            playButton6.Width.Set(22, 0f);
            playButton6.Height.Set(22, 0f);
            playButton6.OnLeftClick += new(PlayButtonClicked6);
            ArchitectShopsPanel.Append(playButton6);
            UIImageButton playButton7 = new(buttonPlayTexture);
            playButton7.Left.Set(10, 0f);
            playButton7.Top.Set(190, 0f);
            playButton7.Width.Set(22, 0f);
            playButton7.Height.Set(22, 0f);
            playButton7.OnLeftClick += new(PlayButtonClicked7);
            ArchitectShopsPanel.Append(playButton7);
            UIImageButton playButton8 = new(buttonPlayTexture);
            playButton8.Left.Set(10, 0f);
            playButton8.Top.Set(220, 0f);
            playButton8.Width.Set(22, 0f);
            playButton8.Height.Set(22, 0f);
            playButton8.OnLeftClick += new(PlayButtonClicked8);
            ArchitectShopsPanel.Append(playButton8);
            UIImageButton playButton9 = new(buttonPlayTexture);
            playButton9.Left.Set(10, 0f);
            playButton9.Top.Set(250, 0f);
            playButton9.Width.Set(22, 0f);
            playButton9.Height.Set(22, 0f);
            playButton9.OnLeftClick += new(PlayButtonClicked9);
            ArchitectShopsPanel.Append(playButton9);
            UIImageButton playButton10 = new(buttonPlayTexture);
            playButton10.Left.Set(10, 0f);
            playButton10.Top.Set(280, 0f);
            playButton10.Width.Set(22, 0f);
            playButton10.Height.Set(22, 0f);
            playButton10.OnLeftClick += new(PlayButtonClicked10);
            ArchitectShopsPanel.Append(playButton10);

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("AlchemistNPCLite/Interface/ButtonClose");
            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(270, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new(CloseButtonClicked);
            ArchitectShopsPanel.Append(closeButton);
            Append(ArchitectShopsPanel);
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 1;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.Filler, ref visible);
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 2;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.Building, ref visible);
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 3;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.BasicFurn, ref visible);
            }
        }

        private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 4;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.AdvFurn, ref visible);
            }
        }

        private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 5;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.Torch, ref visible);
            }
        }

        private void PlayButtonClicked6(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 6;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.Candle, ref visible);
            }
        }

        private void PlayButtonClicked7(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 7;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.Lamp, ref visible);
            }
        }

        private void PlayButtonClicked8(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 8;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.Lantern, ref visible);
            }
        }

        private void PlayButtonClicked9(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 9;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.Chandelier, ref visible);
            }
        }

        private void PlayButtonClicked10(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Architect.Shops = 10;
				ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Architect.Candelabra, ref visible);
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
            offset = new Vector2(evt.MousePosition.X - ArchitectShopsPanel.Left.Pixels, evt.MousePosition.Y - ArchitectShopsPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            ArchitectShopsPanel.Left.Set(end.X - offset.X, 0f);
            ArchitectShopsPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (ArchitectShopsPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                ArchitectShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
                ArchitectShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
		
		private Color CheckColor(int i)
		{
			if (Architect.Shops == i) return Color.Lime;
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
			text7.TextColor = CheckColor(7);
			text8.TextColor = CheckColor(8);
			text9.TextColor = CheckColor(9);
			text10.TextColor = CheckColor(10);
		}
    }
}
