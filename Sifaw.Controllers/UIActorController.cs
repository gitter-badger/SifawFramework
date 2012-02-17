﻿/*
 * Sifaw.Controllers.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 17/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base que implemnenta una interfaz que permite la selección de un
	/// componente de interfaz <see cref="UIComponent"/> a mostrar de entre una colección
	/// de componentes embebidos.
	/// </summary>
	/// <typeparam name="TInput">
	/// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.Input"/>.
	/// </typeparam>
	/// <typeparam name="TOutput">
	/// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.Output"/>.
	/// </typeparam>
	/// <typeparam name="TUISettings">
	/// Tipo para establecer el contenedor de ajustes encargado de establecer las configuración del elemento de interfaz 
	/// de usuario o de componentes embebidos. Ha de ser serializable, proveer de consturctor público y derivar 
	/// de <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.UISettingsContainer"/>.
	/// </typeparam>
	/// <typeparam name="TComponent">
	/// Tipo para establecer el elemento de interfaz de usuario de la controladora. Ha de implementar <see cref="UIActorComponent"/>.
	/// </typeparam>
	/// <typeparam name="TGuest">
	/// Tipo de los componentes que puede alojar. Ha de implementar <see cref="UIComponent"/>.
	/// </typeparam>
	public abstract class UIActorController<TInput, TOutput, TUISettings, TComponent, TGuest> : UIComponentController
		< TInput
		, TOutput
		, TUISettings
		, TComponent >
		where TInput      : UIActorController<TInput, TOutput, TUISettings, TComponent, TGuest>.Input
		where TOutput     : UIActorController<TInput, TOutput, TUISettings, TComponent, TGuest>.Output
		where TUISettings : UIActorController<TInput, TOutput, TUISettings, TComponent, TGuest>.UISettingsContainer
						  , new()
		where TComponent  : UIActorComponent
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, TComponent>.Input
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.Input"/>.
			/// </summary>
			protected Input()
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public abstract new class Output : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, TComponent>.Output
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.Output"/>.
			/// </summary>
			protected Output()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, TComponent>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.UISettingsContainer"/>.
			/// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Events

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/// <summary>
		/// Se produce cuando cambia el progreso del proceso.
		/// </summary>
		public event CLComponentChangedEventHandler ComponentChanged;

		/// <summary>
		/// Provoca el evento <see cref="ComponentChanged"/>. 
		/// </summary>
		/// <param name="e"><see cref="Sifaw.Controllers.CLComponentChangedEventArgs"/> que contiene los datos del evento.</param>
		private void OnComponentChanged(CLComponentChangedEventArgs e)
		{
			if (ComponentChanged != null)
				ComponentChanged(this, e);
		}

		/*
		 * Desencadenadores protegidos.
		 *  • Pueden ser lanzados por controladoras hijas.
		 */

		/* Empty */

		/*
		 * Desencadenadores protegidos virtuales sin manejadores asociados.
		 *  • Pueden ser sobreescritos por controladoras hijas para
		 *    completar funcionalidad.
		 */

		/// <summary>
		/// Se llama al método <see cref="OnBeforeComponentChanged"/> antes de finalizar las
		/// controladoras embebidas. El método permite que las clases derivadas controlen
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeComponentChanged"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeComponentChanged"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeComponentChanged()
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnAfterComponentChanged"/> después de finalizar las
		/// controladoras embebidas. El método permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterComponentChanged"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterComponentChanged"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterComponentChanged()
		{
			/* Emtpy */
		}	

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}"/>.
        /// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="AbstractUIProviderManager{TLinker}"/>.
        /// </summary>
		protected UIActorController()
			: base()
		{
		}

        /// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Linker"/> donde <c>TUIElement</c> 
		/// implementa <see cref="UIActorComponent"/>.
        /// </summary>
		protected UIActorController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Abstract Methods

		/// <summary>		
		/// Devuelve el número total de componentes que presentará la controladora al usuario.
		/// </summary>
		protected abstract byte GetNumberOfComponents();

		/// <summary>
		/// Devuelve el componente a mostrar según la posición y componente mostrado actualmente.
		/// </summary>
		/// <param name="key">Clave que indica la posición del componente en la secuencia.</param>
		/// <param name="current">Vista que actualmente esta mostrando el asistente.</param>
		protected abstract TGuest GetComponentAt(byte key, TGuest current);

		/// <summary>
		/// Actualiza el componente a mostrar.
		/// </summary>
		/// <param name="key">Clave que indica la posición del componente en la secuencia.</param>
		protected abstract void UpdateUIComponent(byte key);

		#endregion

		#region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUISettings, TComponent}.OnAfterUIElementLoad()"/>.
		/// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */
			UIElement.UIComponentChanged += new UIComponentChangedEventHandler(UIElement_UIComponentChanged);
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUISettings, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUISettings, TView}.UIElement"/> 
		/// del tipo <see cref="UIActorComponent"/>.
		/// </summary>
		protected override void OnApplyUISettings()
		{
			base.OnApplyUISettings();
		}

		#endregion

		#region Start Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeStartController()"/>.
		/// </summary>
		protected override void OnAfterStartController()
		{
			base.OnAfterStartController();

			UIElement.NumComponents = GetNumberOfComponents();
		}

		#endregion

		#region UIElement Event Handlers

		private void UIElement_UIComponentChanged(object sender, UIComponentChangedEventArgs e)
		{
			OnBeforeComponentChanged();
			UpdateUIComponent(e.Key);
			OnComponentChanged(new CLComponentChangedEventArgs());
			OnAfterComponentChanged();
		}

		#endregion
	}
}