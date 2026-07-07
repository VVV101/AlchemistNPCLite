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
    // Gregg: Tinkerer's shop-tab picker (Movement/Misc, Combat, Custom Items) — mirrors ShopChangeUIO, trimmed to 3 rows.
    class ShopChangeUIT : UIState
    {
        public UIPanel TinkererShopsPanel;
        public static bool visible = false;
        public static uint timeStart;
        public static string Shop = Tinkerer.Shop1;
        UIText text = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.TinkererButton1"));
        UIText text1 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.TinkererButton2"));
        UIText text2 = new UIText(Language.GetTextValue("Mods.AlchemistNPCLite.TinkererCustomShop"));

        public override void OnInitialize()
        {
            TinkererShopsPanel = new UIPanel();
            TinkererShopsPanel.SetPadding(0);
            TinkererShopsPanel.Left.Set(575f, 0f);
            TinkererShopsPanel.Top.Set(275f, 0f);
            TinkererShopsPanel.Width.Set(375f, 0f);
            TinkererShopsPanel.Height.Set(130f, 0f);
            TinkererShopsPanel.BackgroundColor = new(49, 51, 117, 210);

            TinkererShopsPanel.OnLeftMouseDown += new MouseEvent(DragStart);
            TinkererShopsPanel.OnLeftMouseUp += new MouseEvent(DragEnd);

            text.Left.Set(35, 0f);
            text.Top.Set(10, 0f);
            text.Width.Set(120, 0f);
            text.Height.Set(22, 0f);
            text.TextColor = CheckColor(1);
            text.TextOriginX = 0f; // Gregg: left-align — UIText centers by default, drifting short labels right
            TinkererShopsPanel.Append(text);

            text1.Left.Set(35, 0f);
            text1.Top.Set(40, 0f);
            text1.Width.Set(120, 0f);
            text1.Height.Set(22, 0f);
            text1.TextColor = CheckColor(2);
            text1.TextOriginX = 0f;
            TinkererShopsPanel.Append(text1);

            text2.Left.Set(35, 0f);
            text2.Top.Set(70, 0f);
            text2.Width.Set(120, 0f);
            text2.Height.Set(22, 0f);
            text2.TextColor = CheckColor(3);
            text2.TextOriginX = 0f;
            TinkererShopsPanel.Append(text2);

            Asset<Texture2D> buttonPlayTexture = ModContent.Request<Texture2D>("AlchemistNPCLite/Interface/ButtonSet");
            UIImageButton playButton = new(buttonPlayTexture);
            playButton.Left.Set(10, 0f);
            playButton.Top.Set(10, 0f);
            playButton.Width.Set(22, 0f);
            playButton.Height.Set(22, 0f);
            playButton.OnLeftClick += new(PlayButtonClicked1);
            TinkererShopsPanel.Append(playButton);
            UIImageButton playButton1 = new(buttonPlayTexture);
            playButton1.Left.Set(10, 0f);
            playButton1.Top.Set(40, 0f);
            playButton1.Width.Set(22, 0f);
            playButton1.Height.Set(22, 0f);
            playButton1.OnLeftClick += new(PlayButtonClicked2);
            TinkererShopsPanel.Append(playButton1);
            UIImageButton playButton2 = new(buttonPlayTexture);
            playButton2.Left.Set(10, 0f);
            playButton2.Top.Set(70, 0f);
            playButton2.Width.Set(22, 0f);
            playButton2.Height.Set(22, 0f);
            playButton2.OnLeftClick += new(PlayButtonClicked3);
            TinkererShopsPanel.Append(playButton2);

            Asset<Texture2D> buttonDeleteTexture = ModContent.Request<Texture2D>("AlchemistNPCLite/Interface/ButtonClose");
            UIImageButton closeButton = new(buttonDeleteTexture);
            closeButton.Left.Set(345, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnLeftClick += new(CloseButtonClicked);
            TinkererShopsPanel.Append(closeButton);
            base.Append(TinkererShopsPanel);
        }

        private void PlayButtonClicked1(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Tinkerer.Shops = 1;
                ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Tinkerer.Shop1, ref visible);
            }
        }

        private void PlayButtonClicked2(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Tinkerer.Shops = 2;
                ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Tinkerer.Shop2, ref visible);
            }
        }

        private void PlayButtonClicked3(UIMouseEvent evt, UIElement listeningElement)
        {
            if (Main.GameUpdateCount - timeStart >= AlchemistNPCLite.modConfiguration.ShopChangeDelay)
            {
                Tinkerer.Shops = 3;
                ReCheckColor();
                AlchemistHelper.OpenShop(ref Shop, Tinkerer.TCustomShop, ref visible);
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
            offset = new Vector2(evt.MousePosition.X - TinkererShopsPanel.Left.Pixels, evt.MousePosition.Y - TinkererShopsPanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            TinkererShopsPanel.Left.Set(end.X - offset.X, 0f);
            TinkererShopsPanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (TinkererShopsPanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                TinkererShopsPanel.Left.Set(MousePosition.X - offset.X, 0f);
                TinkererShopsPanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }

        private Color CheckColor(int i)
        {
            if (Tinkerer.Shops == i) return Color.Lime;
            return Color.White;
        }

        private void ReCheckColor()
        {
            text.TextColor = CheckColor(1);
            text1.TextColor = CheckColor(2);
            text2.TextColor = CheckColor(3);
        }
    }
}
