﻿///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// TextFilter.cs
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 06/02/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Sifaw.WPF.CCL;
using Sifaw.Views.Components;
using Sifaw.Views;
using Sifaw.Views.Components.Filters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que implementa el componente <see cref="TextFilterComponent"/>.
	/// </summary>
	public class TextFilterControl : SearchTextField, TextFilterComponent
	{
		#region Constructors

		static TextFilterControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextFilterControl), new FrameworkPropertyMetadata(typeof(TextFilterControl)));
		}

		#endregion

		#region Helpers

		/// <summary>
		/// Flag que indica si se está aplicando un filtro.
		/// </summary>
		private bool filtering = false;

		private void BeginFilter()
		{
			filtering = true;
		}

		private void EndFilter()
		{
			filtering = false;
		}

		#endregion

		#region Overrides Methods

		/// <summary>
		/// Último filtro válido aplicado.
		/// </summary>
		private string Former = string.Empty;

		protected override void OnSearch(RoutedEventArgs e)
		{
			base.OnSearch(e);

			if (!filtering)
			{
				BeginFilter();

				try
				{
					UIFilterChangedEventArgs args = new UIFilterChangedEventArgs();

					OnFilterChanged(args);

					if (args.Cancel)
						Filter = Former;
					else
						Former = Filter;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					EndFilter();
				}
			}
		}

		#endregion

		#region FilterComponent<string> Members

		public string Filter
		{
			get { return Text; }
			set { Text = value; }
		}

		public event UIFilterChangedEventHandler FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs e)
		{
			if (FilterChanged != null)
				FilterChanged(this as TextFilterComponent, e);
		}

		#endregion

		#region UIElement Members

		#region Properties

		private string _denomination = string.Empty;
		public string Denomination
		{
			get { return _denomination; }
			set { _denomination = value; }
		}

		private string _description = string.Empty;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		#endregion

		#region Methods

		public void Refresh()
		{
			/* Emtpy */
		}

		public void Reset()
		{
			Text = string.Empty;
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

		#endregion
	}
}