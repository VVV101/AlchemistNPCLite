using AlchemistNPCLite.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace AlchemistNPCLite.Interface
{
    // Gregg: tiny draggable "< K / N >" pager shown while a paginated Operator/etc. shop is open.
    // Arrows flip the page via ShopPaginator, which refills the open grid in place (seamless).
    class ShopPageUI : UIState
    {
        private UIPanel panel;
        private UIText label;

        public override void OnInitialize()
        {
            panel = new UIPanel();
            panel.SetPadding(0);
            panel.Left.Set(76f, 0f);
            panel.Top.Set(470f, 0f); // Gregg: below the shop grid by default (draggable)
            panel.Width.Set(150f, 0f);
            panel.Height.Set(36f, 0f);
            panel.BackgroundColor = new Color(49, 51, 117, 210);
            panel.OnLeftMouseDown += new MouseEvent(DragStart);
            panel.OnLeftMouseUp += new MouseEvent(DragEnd);

            UIPanel prev = MakeArrowButton("<", 4f);
            prev.OnLeftClick += new MouseEvent(PrevClicked);
            panel.Append(prev);

            UIPanel next = MakeArrowButton(">", 118f);
            next.OnLeftClick += new MouseEvent(NextClicked);
            panel.Append(next);

            label = new UIText("1 / 1");
            label.Left.Set(58f, 0f);
            label.Top.Set(10f, 0f);
            panel.Append(label);

            base.Append(panel);
        }

        private UIPanel MakeArrowButton(string glyph, float left)
        {
            UIPanel b = new UIPanel();
            b.SetPadding(0);
            b.Left.Set(left, 0f);
            b.Top.Set(4f, 0f);
            b.Width.Set(28f, 0f);
            b.Height.Set(28f, 0f);
            b.BackgroundColor = new Color(73, 77, 138, 220);

            UIText t = new UIText(glyph);
            t.IgnoresMouseInteraction = true;
            t.Left.Set(9f, 0f);
            t.Top.Set(5f, 0f);
            b.Append(t);
            return b;
        }

        private void PrevClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            SoundEngine.PlaySound(SoundID.MenuTick);
            ShopPaginator.PrevPage();
        }

        private void NextClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            SoundEngine.PlaySound(SoundID.MenuTick);
            ShopPaginator.NextPage();
        }

        Vector2 offset;
        public bool dragging = false;

        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - panel.Left.Pixels, evt.MousePosition.Y - panel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;
            panel.Left.Set(end.X - offset.X, 0f);
            panel.Top.Set(end.Y - offset.Y, 0f);
            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            label.SetText((ShopPaginator.CurrentPage + 1) + " / " + ShopPaginator.ActivePageCount);

            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (panel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                panel.Left.Set(MousePosition.X - offset.X, 0f);
                panel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
