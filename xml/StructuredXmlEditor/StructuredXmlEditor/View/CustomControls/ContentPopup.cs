﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace StructuredXmlEditor.View
{
	public class ContentPopup : Button
	{
		//-----------------------------------------------------------------------
		public PlacementMode Placement
		{
			get { return (PlacementMode)GetValue(PlacementProperty); }
			set { SetValue(PlacementProperty, value); }
		}

		//-----------------------------------------------------------------------
		public static readonly DependencyProperty PlacementProperty =
			DependencyProperty.Register("Placement", typeof(PlacementMode), typeof(ContentPopup), new PropertyMetadata(PlacementMode.Bottom));

		//-----------------------------------------------------------------------
		public object PopupContent
		{
			get { return (object)GetValue(PopupContentProperty); }
			set { SetValue(PopupContentProperty, value); }
		}

		//-----------------------------------------------------------------------
		public static readonly DependencyProperty PopupContentProperty =
			DependencyProperty.Register("PopupContent", typeof(object), typeof(ContentPopup), new PropertyMetadata(null));


		//-----------------------------------------------------------------------
		public DataTemplate PopupContentTemplate
		{
			get { return (DataTemplate)GetValue(PopupContentTemplateProperty); }
			set { SetValue(PopupContentTemplateProperty, value); }
		}

		//-----------------------------------------------------------------------
		public static readonly DependencyProperty PopupContentTemplateProperty =
			DependencyProperty.Register("PopupContentTemplate", typeof(DataTemplate), typeof(ContentPopup), new PropertyMetadata(null));

		//-----------------------------------------------------------------------
		static ContentPopup()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentPopup),
				new FrameworkPropertyMetadata(typeof(ContentPopup)));
		}

		//-----------------------------------------------------------------------
		public ContentPopup()
		{
			IsEnabledChanged += OnIsEnabledChanged;
		}

		//-----------------------------------------------------------------------
		void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if ((bool)e.NewValue == false && m_popup != null && m_popup.IsOpen)
			{
				m_popup.IsOpen = false;
			}
		}

		//-----------------------------------------------------------------------
		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			m_popup = GetTemplateChild("PART_Popup") as Popup;

			if (m_popup != null)
			{
				m_popup.StaysOpen = false;
				m_popup.PlacementTarget = this;
				m_popup.Placement = Placement;
			}
		}

		//-----------------------------------------------------------------------
		protected override void OnClick()
		{
			base.OnClick();

			m_popup.IsOpen = true;
		}

		Popup m_popup;
	}
}
