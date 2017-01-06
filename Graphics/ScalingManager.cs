﻿using System;
#if MONOMAC
using System.Drawing;
#endif

using Microsoft.Xna.Framework;

namespace BareKit.Graphics
{
    public class ScalingManager
    {
		GameWindow window;
		GraphicsDeviceManager graphics;

        Vector2 initialSize;
        Vector2 currentSize;
        float contentScale;
        DisplayOrientation orientation;

        public event EventHandler<EventArgs> Resized;

		public ScalingManager(GraphicsDeviceManager graphics, GameWindow window, Vector3 size, float scale = 1, bool fullscreen = false)
        {
			this.graphics = graphics;
			this.window = window;

            window.ClientSizeChanged += OnResized;
            window.OrientationChanged += OnResized;
			window.AllowUserResizing = true;

			initialSize = new Vector2(size.X, size.X / size.Y * size.Z);
			graphics.PreferredBackBufferWidth = (int)(initialSize.X * scale);
			graphics.PreferredBackBufferHeight = (int)(initialSize.Y * scale);

            OnResized(window, EventArgs.Empty);
        }

        void OnResized(object sender, EventArgs e)
        {
            currentSize = new Vector2(window.ClientBounds.Width, window.ClientBounds.Height);
            contentScale = Math.Min(currentSize.X / initialSize.X, currentSize.Y / initialSize.Y);

            orientation = window.CurrentOrientation;

            Resized?.Invoke(this, EventArgs.Empty);
        }

		public void Center()
		{
#if MONOMAC
			Vector2 desktopSize = new Vector2(graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Width,
											  graphics.GraphicsDevice.Adapter.CurrentDisplayMode.Height
										     );

			Vector2 newPosition = new Vector2((desktopSize.X - currentSize.X) / 2, (desktopSize.Y - currentSize.Y) / 2);

			float titleBarHeight = window.Window.Frame.Height - currentSize.Y;

			PointF tempPosition = new PointF(newPosition.X, newPosition.Y);
			SizeF tempSize = new SizeF(new PointF(currentSize.X, currentSize.Y + titleBarHeight));
			RectangleF tempRect = new RectangleF(tempPosition, tempSize);

			window.Window.SetFrame(tempRect, true);
#endif
		}

		public float Fit(float number)
		{
			return number * contentScale;
		}

		public Vector2 Fit(Vector2 vector)
		{
			return vector * contentScale;
		}

		public float UnFit(float number)
		{
			return number / contentScale;
		}

		public Vector2 UnFit(Vector2 vector)
		{
			return vector / contentScale;
		}

        public Vector2 Size
        {
            get { return currentSize; }
        }

        public Vector2 Scale
        {
            get { return new Vector2(contentScale); }
        }

        public DisplayOrientation Orientation
        {
            get { return orientation; }
        }
    }
}
