﻿/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core;


namespace Sifaw.Controllers
{
    /*
     * Argumento y manejador para los eventos que solicitan mostrar un mensaje
     * al usuario.
     */

    /// <summary>
    /// Proporciona datos para eventos que solicitan mostrar un mensaje de advertencia.
    /// </summary>
    public class CLShowWarningEventArgs : CLShowMessageEventArgs
    {
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLShowWarningEventArgs"/>, estableciendo un mensaje de advertencia.
		/// </summary>
        public CLShowWarningEventArgs(string message)
            : base(MessagesLevels.Warning, message)
        {
        }

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLShowWarningEventArgs"/>, estableciendo un título y un mensaje de advertencia.
		/// </summary>
        public CLShowWarningEventArgs(string title, string message)
            : base(MessagesLevels.Warning, title, message)
        {
        }
    }

    /// <summary>
    /// Representa el método que maneja el evento que solicita mostrar un mensaje de advertencia.
    /// </summary>
    /// <param name="sender">Origen del evento.</param>
    /// <param name="e"><see cref="CLConfirmMessageEventArgs"/> que contiene los datos de eventos.</param>
    public delegate void CLShowWarningEventHandler(object sender, CLShowWarningEventArgs e);
}