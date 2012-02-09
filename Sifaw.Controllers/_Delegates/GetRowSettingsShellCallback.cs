﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Representa el callbak que es invocado cuando se solicita desde una 
	/// shell la configuración de una fila de la shell.
	/// </summary>
	/// <param name="row">Fila.</param>
	/// <param name="height">Alto de la fila.</param>
	/// <param name="mode">Modo de ajuste de la fila.</param>
	public delegate void GetRowSettingsShellCallback(uint row, out double height, out UILengthModes mode);
}
