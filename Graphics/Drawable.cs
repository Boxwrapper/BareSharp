﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BareKit.Graphics
{
    public class Drawable
    {
        ScalingManager scaling;

        Vector2 position;
        float rotation;
        Vector2 scale;
        Vector2 origin;

        Color color;
        float alpha;
		bool isVisible;

        Container parent;

        public Drawable()
        {
            position = new Vector2(0);
            rotation = 0;
            scale = new Vector2(1);
            origin = new Vector2(0);

            color = Color.White;
            alpha = 1;
			isVisible = true;
        }

		/// <summary>
		/// Initializes the Drawable instance.
		/// </summary>
		/// <param name="scaling">ScalingManager the instance scale is being controled by.</param>
		public virtual void Initialize(ScalingManager scaling)
		{
			this.scaling = scaling;
		}		

		/// <summary>
		/// Sends drawcalls to a specific SpriteBatch buffer.
		/// </summary>
		/// <param name="buffer">SpriteBatch buffer to which the calls are being send.</param>
        public virtual void Draw(SpriteBatch buffer)
        {
			// Add your own drawcalls here
			// ex.: buffer.Draw(Texture);
        }

		/// <summary>
		/// Gets the attached ScalingManager.
		/// </summary>
		/// <value>The attached ScalingManger.</value>
        protected ScalingManager Scaling
        {
            get { return scaling; }
        }

		/// <summary>
		/// Gets or sets the position vector.
		/// </summary>
		/// <value>The position vector.</value>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

		/// <summary>
		/// Gets or sets the x-coordinate of the position vector.
		/// </summary>
		/// <value>The x-coordinate of the position vector.</value>
        public float PositionX
        {
            get { return position.X; }
            set { position.X = value; }
        }

		/// <summary>
		/// Gets or sets the y-coordinate of the position vector.
		/// </summary>
		/// <value>The y-coordinate of the position vector.</value>
        public float PositionY
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

		/// <summary>
		/// Gets or sets the rotation.
		/// </summary>
		/// <value>The rotation.</value>
        public float Rotation 
        {
            get { return rotation; }
			set { rotation = value; }
        }

		/// <summary>
		/// Gets or sets the scale vector.
		/// </summary>
		/// <value>The scale vector.</value>
        public Vector2 Scale
        {
            get { return scale; }
            set { scale = value; }
        }

		/// <summary>
		/// Gets or sets the x-coordinate of the scale vector.
		/// </summary>
		/// <value>The x-coordinate of the scale vector.</value>
        public float ScaleX
        {
            get { return scale.X; }
            set { scale.X = value; }
        }

		/// <summary>
		/// Gets or sets the y-coordinate of the scale vector.
		/// </summary>
		/// <value>The y-coordinate of the scale vector.</value>
        public float ScaleY
        {
            get { return scale.Y; }
            set { scale.Y = value; }
        }

		/// <summary>
		/// Gets or sets the origin vector.
		/// </summary>
		/// <value>The origin vector.</value>
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

		/// <summary>
		/// Gets or sets the x-coordinate of the origin vector.
		/// </summary>
		/// <value>The x-coordinate of the origin vector.</value>
        public float OriginX
        {
            get { return origin.X; }
            set { origin.X = value; }
        }

		/// <summary>
		/// Gets or sets the y-coordinate of the origin vector.
		/// </summary>
		/// <value>The y-coordinate of the origin vector.</value>
        public float OriginY
        {
            get { return origin.Y; }
            set { origin.Y = value; }
        }

		/// <summary>
		/// Gets or sets the displayed color.
		/// </summary>
		/// <value>The displayed color.</value>
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

		/// <summary>
		/// Gets or sets the red value of the displayed color.
		/// </summary>
		/// <value>The red value of the displayed color.</value>
        public int ColorR
        {
            get { return color.R; }
            set { color.R = (byte)value; }
        }

		/// <summary>
		/// Gets or sets the green value of the displayed color.
		/// </summary>
		/// <value>The green value of the displayed color.</value>
        public int ColorG
        {
            get { return color.G; }
            set { color.G = (byte)value; }
        }

		/// <summary>
		/// Gets or sets the blue value of the displayed color.
		/// </summary>
		/// <value>The blue value of the displayed color.</value>
        public int ColorB
        {
            get { return color.B; }
            set { color.B = (byte)value; }
        }

		/// <summary>
		/// Gets or sets the alpha value of the displayed color.
		/// </summary>
		/// <value>The alpha value of the displayed color.</value>
        public float Alpha
        {
			get { return isVisible ? alpha : 0; }
            set { alpha = value; }
        }

		/// <summary>
		/// Gets or sets a value indicating whether the Drawable is visible.
		/// </summary>
		/// <value>The visibility indicating value.</value>
		public bool IsVisible
		{
			get { return isVisible; }
			set { isVisible = value; }
		}

		/// <summary>
		/// Gets or sets the parent component.
		/// </summary>
		/// <value>The parent component.</value>
        public Container Parent
        {
            get { return parent; }
            set
            {
                if (value == null || value.Children.Contains(this))
                    parent = value;
            }
        }
    }
}
