﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers;

using Sifaw.Views;


namespace Sifaw.WPF.Test
{
	public class UIAssistantTestViewController
		: UIShellViewController
		< UIAssistantTestViewController.Input
		, UIAssistantTestViewController.Output
		, UIAssistantTestViewController.UISettingsContainer
		, UIComponent>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, UISettingsContainer, UIComponent>.Input
		{
			#region Constructors

			public Input()
				: this(true)
			{
			}

			public Input(bool showView)
				: base(showView:showView)
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new class Output : UIShellViewController<Input, Output, UISettingsContainer, UIComponent>.Output
		{
			#region Fields

			private bool _cancelled;

			#endregion

			#region Properties

			/// <summary>
			/// Indica si el proceso fue cancelado
			/// </summary>
			public bool Cancelled
			{
				get { return _cancelled; }
			}

			#endregion

			#region Constructors

			public Output(bool cancelled)
				: base()
			{
				this._cancelled = cancelled;
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public new class UISettingsContainer : UIShellViewController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.UISettingsContainer
		{
			#region Constructors

			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Inclusions

		private UIAssistantTestController _uiAssistantTestController = null;
		private UIAssistantTestController UIAssistantTestController
		{
			get
			{
				if (_uiAssistantTestController == null)
				{
					_uiAssistantTestController = new UIAssistantTestController();
					_uiAssistantTestController.Finished += new CLFinishedEventHandler<Test.UIAssistantTestController.Output>(_uiAssistantTestController_Finished);
				}

				return _uiAssistantTestController;
			}
		}

		#endregion

		#region Constructors

		public UIAssistantTestViewController()
			: base()
		{
		}

		public UIAssistantTestViewController(AbstractUILinker<ShellView> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default Input / Output

		protected override Output GetDefaultOutput()
		{
			return new Output(true);
		}

		public override Input GetDefaultInput()
		{
			return new Input();
		}

		public override Input GetResetInput()
		{
			return null;
		}

		#endregion

		#region UIElement Methods

		protected override void OnApplyUISettings()
		{
			base.OnApplyUISettings();			
		}

        protected override void OnAfterApplyUISettings()
        {
            base.OnAfterApplyUISettings();

            // Aplicamos configuración a componentes internos ...
            //   - Se aplica al iniciar la controladora
            //UIAssistantTestController.UISettings.Apply();
        }

		protected override void OnAfterUIShow()
		{
			base.OnAfterUIShow();

			UIAssistantTestController.RunWorker();
		}

		#endregion

		#region UIShell Methods
		
		protected override uint GetNumberOfRows()
		{
			return 1;
		}

		protected override uint GetNumberOfCellsAt(uint row)
		{
			return 1;
		}

		protected override void GetRowSettings(uint row, out double height, out Views.UILengthModes mode)
		{
			height = 400;
			mode = Views.UILengthModes.WeightedProportion;
		}

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out Views.UILengthModes mode, out Views.UIComponent component)
		{
			width = 400;
			mode = Views.UILengthModes.WeightedProportion;
			component = UIAssistantTestController.GetUIComponent();
		}

        #endregion

        #region Start Methods

        protected override void StartController()
		{			
			UIAssistantTestController.Start();
		}

		protected override bool AllowReset()
		{
			return false;
		}

		protected override void ResetController()
		{
			/* Empty */
		}

		#endregion

		#region Inclusions Events Handlers

		private void _uiAssistantTestController_Finished(object sender, CLFinishedEventArgs<UIAssistantTestController.Output> e)
		{
			FinishController(new Output(e.Output.Cancelled));
		}

		#endregion
	}
}