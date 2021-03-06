﻿/*
 * Sifaw.Views.Components
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


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Define un método generalizado, que implementa una clase o tipo de valor con
	/// el fin de que un objeto pueda ser interpretado por un componente que derive 
	/// de <see cref="FilterBaseComponent{TFilter}"/>.
	/// </summary>
	/// <remarks>
	/// Los objetos que implementen la interfaz <see cref="IFilterable"/> han de proporcionar
	/// una implementación específica para <see cref="System.Object.Equals(object)"/> para asegurar
	/// que los componentes concretos de las interfaces de usario pueden comparar correctamente 
	/// distintas instancias de estos objetos.
	/// </remarks>
	public interface IFilterable : IComparable, IComparable<IFilterable>, IEquatable<IFilterable>
	{
		/// <summary>
		/// Obtiene la denominación del item <see cref="IFilterable"/>.
		/// </summary>
		string DisplayFilter { get; }

        /// <summary>
        /// Obtiene el orden de presentación del filtro.
        /// </summary>
        int? Order { get; }

		/// <summary>
		/// Determina si un objeto <see cref="IFilterable"/> proporcionado es equivalente al objeto <see cref="IFilterable"/> actual.
		/// </summary>
		/// <param name="obj">Un objeto a comparar con el actual objeto.</param>
		/// <returns></returns>
		bool Equals(object obj);
	}
}