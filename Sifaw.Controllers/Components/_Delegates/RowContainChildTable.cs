﻿/*
 * Sifaw.Controllers.Components
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


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Representa el callbak que es invocado cuando se solicita, desde un componente
	/// que gestiona un objeto <see cref="UITable"/>, que indica si la fila de la 
	/// sección especificada tiene una tabla secundaria asociada. 
	/// </summary>
	/// <param name="name">Nombre de la tabla.</param>
	/// <param name="section">Índice de la sección.</param>
	/// <param name="row">Índice de la fila.</param>
	/// <returns>
	/// <c>true</c> si la fila tiene una tabla secundaria asociada; 
	/// <c>false</c> en otro caso.
	/// </returns>
	internal delegate bool RowContainChildTable(string name, int section, int row);
}