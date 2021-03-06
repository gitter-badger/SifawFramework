﻿/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



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

using Sifaw.Views.Components;
using Sifaw.Views;
using Sifaw.Views.Components.Filters;
using Sifaw.Views.Kit;

using Sifaw.WPF.CCL;


namespace Sifaw.WPF.Filters
{
	/// <summary>
	/// Representa un control que implementa el componente <see cref="BoolFilterComponent"/>.
	/// </summary>
	public class BoolFilterControl : CheckBox, BoolFilterComponent
	{
		#region Constructors

		static BoolFilterControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(BoolFilterControl), new FrameworkPropertyMetadata(typeof(BoolFilterControl)));
		}

        public BoolFilterControl()
            : base()
        {
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

		#region Methods sobreescritos

		protected override void OnChecked(RoutedEventArgs e)
		{
			base.OnChecked(e);

			if (!filtering)
			{
				BeginFilter();

				try
				{
					UIFilterChangedEventArgs args = new UIFilterChangedEventArgs();

					OnFilterChanged(args);

					if (args.Cancel)
						Filter = false;
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

		protected override void OnUnchecked(RoutedEventArgs e)
		{
			base.OnUnchecked(e);

			if (!filtering)
			{
				BeginFilter();

				try
				{
					UIFilterChangedEventArgs args = new UIFilterChangedEventArgs();

					OnFilterChanged(args);

					if (args.Cancel)
						Filter = true;
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

		#region BoolComponentFilter Members

		public string Text
		{
			set { Content = value; }
		}

		#endregion

		#region ComponentFilter<bool> Members

		public bool Filter
		{
			get { return IsChecked.HasValue ? IsChecked.Value : false; }
			set { IsChecked = value; }
		}

		public event UIFilterChangedEventHandler FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs e)
		{
			if (FilterChanged != null)
				FilterChanged(this as TextFilterComponent, e);
		}

		#endregion

		#region UIElement Members

		public void Refresh()
		{
			/* Emtpy */
		}

		public void Reset()
		{
			/* Emtpy */
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

        #region UISettings

		private BoolFilterControlSettings _uiSettings = null;
		public BoolFilterSettings UISettings
		{
			get 
			{
				if (_uiSettings == null)
					_uiSettings = new BoolFilterControlSettings(this);

				return _uiSettings;
			}
		}

        ComponentSettings Views.UIComponent.UISettings
        {
			get { return UISettings; }
        }

        UISettings Views.UIElement.UISettings
        {
            get { return UISettings; }
        }

        #endregion

        #region Miscellany

        [Serializable]
        public class BoolFilterControlSettings : ControlSettings, BoolFilterSettings
        {
            #region Fields

            private string _textDisplay = string.Empty;

            #endregion

            #region Properties

            /// <summary>
            /// Obtiene o establece el texto a mostrar.
            /// </summary>
            public string TextDisplay
            {
                get { return _textDisplay; }
                set
                {
                    if (_textDisplay != value)
                    {
                        _textDisplay = value;
                        OnPropertyChanged(() => TextDisplay);
                    }
                }
            }

            #endregion

            #region Constructor

            public BoolFilterControlSettings(BoolFilterControl control)
                : base(control)
            {
                UtilWPF.BindField(this, "TextDisplay", control, BoolFilterControl.ContentProperty, BindingMode.TwoWay);
            }

            #endregion
        }

        #endregion
    }
}