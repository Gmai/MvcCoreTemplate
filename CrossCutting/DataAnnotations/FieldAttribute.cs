using CrossCutting.Enums;
using CrossCutting.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CrossCutting.DataAnnotations
{
	public class FieldAttribute : Attribute
	{
		Field _field;

		public FieldAttribute() { }

		public FieldAttribute(bool required = false, string label = "", FieldType type = FieldType.NONE) {
			_field = new Field()
			{
				Type = type,
				Label = label,
				Required = required
			};
		}

		public Field GetFieldData() {
			return _field;
		}
	}

	

	

	
}
