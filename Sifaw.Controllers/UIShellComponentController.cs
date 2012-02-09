﻿///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
/// con componentes tipo shell.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 09/01/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
	/// donde intervienen componentes tipo shell que actuan como contenedores de otros componentes.
	/// </summary>
	/// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora.</typeparam>
	/// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
	public abstract class UIShellComponentController<TInput, TOutput, TUISettings, TGuest>
		: UIComponentController
		< TInput
		, TOutput
		, TUISettings
		, ShellComponent>
		where TInput      : UIShellComponentController<TInput, TOutput, TUISettings, TGuest>.Input
		where TOutput     : UIShellComponentController<TInput, TOutput, TUISettings, TGuest>.Output
		where TUISettings : UIShellComponentController<TInput, TOutput, TUISettings, TGuest>.UISettingsContainer<ShellComponent>
						  , new()
		where TGuest      : UIComponent
	{
		#region Entrada / Salida

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIComponentController<TInput, TOutput, TUISettings, ShellComponent>.Input
		{
			#region Constructor

			protected Input()
				: base()
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public abstract new class Output : UIComponentController<TInput, TOutput, TUISettings, ShellComponent>.Output
		{
			#region Constructor

			protected Output()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public class UISettingsContainer : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, ShellComponent>.UISettingsContainer<ShellComponent>
		{
			#region Constructor

			public UISettingsContainer()
				: base()
			{
			}

			#endregion

			#region Métodos públicos

			public override void Apply()
			{
				base.Apply();
			}

			#endregion
		}

		#endregion

		#region Constructor

		protected UIShellComponentController()
			: base()
		{
		}

		protected UIShellComponentController(AbstractUILinker<ShellComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Métodos abstractos

		/// <summary>
		/// Deuvelve el número de filas de la shell.
		/// </summary>		
		protected abstract uint GetNumberOfRows();

		/// <summary>
		/// Devuelve el número de celdas por fila de la shell.
		/// </summary>
		/// <param name="row">Fila.</param>
		/// <returns>Número de columnas.</returns>
		protected abstract uint GetNumberOfCellsAt(uint row);

		/// <summary>
		/// Devuelve la configuración de una fila de la shell.
		/// </summary>
		/// <param name="row">Fila</param>
		/// <param name="height">Aultura de la fila.</param>
		/// <param name="heighthMode">Mode de ajuste de la fila.</param>
		protected abstract void GetRowSettings(uint row, out double height, out UILengthModes mode);

		/// <summary>
		/// Devuelve la configuracion de una celda de la shell.
		/// </summary>
		/// <param name="row">Fila de columna.</param>
		/// <param name="cell">Celda.</param>
		/// <param name="width">Ancho de la celda.</param>
		/// <param name="widthMode">Modo de ajuste de la celda.</param>
		/// <param name="component">Contenido de la celda.</param>
		protected abstract void GetCellSettings(uint row, uint cell, out double width, out UILengthModes mode, out TGuest guest);

		#endregion

		#region Métodos sobreescritos

		protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			ShellManager.SetSettings<TGuest>(
				  GetNumberOfRows
				, GetNumberOfCellsAt
				, GetRowSettings
				, GetCellSettings
				, UIElement.SetSettings);
		}

		#endregion
	}
}