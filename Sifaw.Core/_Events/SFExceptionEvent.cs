﻿/*
 * Librería de eventos de Sifaw.Core.
 * 
 * Diseñador:     David López Rguez
 * Programadores: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011 -- Creación de la clase.
 * ===============================================================================================
 * 
 * Observaciones:
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Core
{
	/*
	 * Argumento y manejador para los eventos que comunican el una excepción.
	 */

	/// <summary>
	/// Proporciona datos para eventos que informan de una excepción.
	/// </summary>
	public class SFExceptionEventArgs : EventArgs
	{
		/// <summary>
		/// Devuelve una excepción.
		/// </summary>
		public readonly Exception Exception;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="SFExceptionEventArgs"/>, estableciendo un valor a la propiedad <see cref="Exception"/>.
		/// </summary>
		/// <param name="ex">Excepción.</param>
		public SFExceptionEventArgs(Exception ex)
			: base()
		{
			this.Exception = ex;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que informan de una excepción.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="SFExceptionEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void SFExceptionEventHandler(object sender, SFExceptionEventArgs e);
}