using ReLogic.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.Audio;
using System;
using Terraria.ID;
using System.Linq;
using AlchemistNPCLite.NPCs;
using AlchemistNPCLite.Utilities;
using ReLogic.Content;
using Terraria.Localization;

namespace AlchemistNPCLite.Interface
{
    class ShopChangeUIM : UIState
    {
        public UIPanel MusicianShopsPanel;
        public static bool visible = false;
        public static uint timeStart;
		public static string Shop = Musician.Sh1;
		UIText text = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.Shop1"));
		UIText text2 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.Shop2"));
		UIText text3 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.Shop3"));
		UIText text4 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.Shop4"));
		UIText text5 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.Shop5"));
		
        public override void OnInitialize()
        {
            MusicianShopsPanel = new UIPanel();
            MusicianShopsPanel.SetPadding(0);
            MusicianShopsPanel.Left.Set(575f, 0f);
            MusicianShopsPanel.Top.Set(275f, 0f);
            MusicianShopsPanel.Width.Set(325f, 0f);
            MusicianShopsPanel.Height.Set(165f, 0f);
            MusicianShopsPanel.BackgroundColor = new(49, 51, 117, 210);

            MusicianShopsPanel.OnLeftMouseDown += new UIElement.MouseEvent(DragStart);
            MusicianShopsPanel.OnLeftMouseUp += new UIElement.MouseEvent(DragEnd);

            text.Left.Set(35, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(90, 0f);
            text.Height.Set(22, 0f);
			text.TextColor = CheckColor(1);
            MusicianShopsPanel.Append(text);

            text2.Left.Set(35, 0f);
            text2.Top.Set(40, 0f);
            text2.Width.Set(90, 0f);
            text2.Height.Set(22, 0f);
			text2.TextColor = CheckColor(2);
            MusicianShopsPanel.Append(text2);

            text3.Left.Set(35, 0f);
            text3.Top.Set(70, 0f);
            text3.Width.Set(90, 0f);
            text3.Height.Set(22, 0f);
			text3.TextColor = CheckColor(3);
            MusicianShopsPanel.Append(text3);
			
            text4.Left.Set(35, 0f);
            text4.Top.Set(100, 0f);
            text4.Width.Set(90, 0f);
            text4.Height.Set(22, 0f);
			text4.TextColor = CheckColor(4);
            MusicianShopsPanel.Append(text4);
			
            text5.Left.Set(35, 0f);
            text5.Top.Set(130, 0f);
            text5.Width.Set(90, 0f);
            text5.Height.Set(22, 0f);
			text5.TextColor = CheckColor(5);
            MusicianShopsPanel.Append(text5);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("AlchemistNPCLite/Interface/ButtonSet");
            UIImageButton playButton = new UIImageButton(buttonPlayTexture);
            playButton.Left.Set(10, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            playButton.OnLeftClick += new MouseEvent(PlayButtonClicked1);
            MusicianShopsPanel.Append(playButton);
            UIImageButton playButton2 = new UIImageButton(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(40, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnLeftClick += new MouseEvent(PlayButtonClicked2);
            MusicianShopsPanel.Append(playButton2);
            UIImageButton playButton3 = new UIImageButton(buttonPlayTexture);
            playButton3.Left.Set(10, 0f);
            playButton3.Top.Set(70, 0f);
            playButton3.Width.Set(22, 0f);
            playButton3.Height.Set(22, 0f);
            playButton3.OnLeftClick += new MouseEvent(PlayButtonClicked3);
            MusicianShopsPanel.Append(playButton3);
			UIImageButton playButton4 = new UIImageButton(buttonPlayTexture);
            playButton4.Left.Set(10, 0f);
            playButton4.Top.Set(100, 0f);
            playButton4.Width.Set(22, 0f);
            playButton4.Height.Set(22, 0f);
            playButton4.OnLeftClick += new MouseEvent(PlayButtonClicked4);
            MusicianShopsPanel.Append(playButton4);
			UIImageButton playButton5 = new UIImageButton(buttonPlayTexture);
            playButton5.Left.Set(10, 0f);
            playButton5.Top.Set(130, 0f);
            playButton5.Width.Set(22, 0f);
            playButton5.Height.Set(22, 0f);
            playButton5.OnLeftClick += new MouseEvent(PlayButtonClicked5);
            MusicianShopsPanel.Append(playButton5);

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("AlchemistNPCLite/Interface/ButtonClose");
            UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
            closeButton.Left.Set(295, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new MouseEvent(CloseButtonClicked);
            MusicianShopsPanel.Append(closeButton);
            base.Append(MusicianShopsPanel);
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Musician.Shops = 1;
                ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Musician.Sh1, ref visible);
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Musician.Shops = 2;
                ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Musician.Sh2, ref visible);
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Musician.Shops = 3;
                ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Musician.Sh3, ref visible);
            }
        }
		
		private void PlayButtonClicked4(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Musician.Shops = 4;
                ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Musician.Sh4, ref visible);
            }
        }
		
		private void PlayButtonClicked5(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Musician.Shops = 5;
                ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Musician.Sh5, ref visible);
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
            offset = new Vector2(evt.MousePosition.X - MusicianShopsPanel.Left.Pixels, evt.MousePosition.Y - MusicianShopsPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            MusicianShopsPanel.Left.Set(end.X - offset.X, 0f);
            MusicianShopsPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (MusicianShopsPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                MusicianShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
                MusicianShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
		
		private Color CheckColor(int i)
		{
			if (Musician.Shops == i) return Color.Lime;
			return Color.White;
		}
		
		private void ReCheckColor()
		{
			text.TextColor = CheckColor(1);
			text2.TextColor = CheckColor(2);
			text3.TextColor = CheckColor(3);
			text4.TextColor = CheckColor(4);
			text5.TextColor = CheckColor(5);
		}
    }
}
