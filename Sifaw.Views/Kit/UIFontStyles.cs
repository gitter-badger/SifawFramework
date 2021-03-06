﻿/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 04/10/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sifaw.Views.Kit
{
    /// <summary>
    /// Especifica la información de estilo que se aplica al texto.
    /// </summary>
    [Flags]
    public enum UIFontStyles
    {
        /// <summary>
        /// Texto normal.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Texto en cursiva.
        /// </summary>
        Italic = 1,

        /// <summary>
        /// Texto en obliquo.
        /// </summary>
        Oblique = 2
    }
}