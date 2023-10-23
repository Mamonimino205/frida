﻿using StructuredXmlEditor.Data;
using StructuredXmlEditor.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StructuredXmlEditor.Tools
{
	public class ToolBase : NotifyPropertyChanged
	{
		public enum ToolPosition
		{
			ProjectView,
			Document,
			Default
		}

		public string Title { get; set; }

		public bool IsVisible
		{
			get { return m_isVisible; }
			set
			{
				m_isVisible = value;
				RaisePropertyChangedEvent();
			}
		}
		private bool m_isVisible = false;

		public bool IsActive { get; set; } = true;

		public Workspace Workspace { get; set; }

		public Command<object> CloseCMD { get { return new Command<object>((obj) => { IsVisible = false; }); } }

		public ToolPosition DefaultPositionDocument { get; set; } = ToolPosition.Default;

		public bool VisibleByDefault { get; set; } = true;

		//-----------------------------------------------------------------------
		public string Icon
		{
			get
			{
				return null;
			}
		}

		//-----------------------------------------------------------------------
		public Brush FontColour
		{
			get
			{
				return Brushes.LightGray;
			}
		}

		public ToolBase(Workspace workspace, string title)
		{
			this.Workspace = workspace;
			this.Title = title;
		}
	}
}
